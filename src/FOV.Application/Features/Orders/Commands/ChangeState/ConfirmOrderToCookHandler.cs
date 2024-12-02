using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.ChangeStateOrder
{
    public record ConfirmOrderToCookCommand(Guid OrderId) : IRequest<Guid>;

    public class ConfirmOrderToCookHandler : IRequestHandler<ConfirmOrderToCookCommand, Guid>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly OrderHub _orderHub;
        private readonly NotificationHub _notificationHub;
        private readonly IDatabase _database;
        private readonly IClaimService _claimService;
        private readonly UserManager<User> _userManager;

        public ConfirmOrderToCookHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, IConnectionMultiplexer redis, IClaimService claimService, NotificationHub notificationHub, UserManager<User> userManager)
        {
            _unitOfWorks = unitOfWorks;
            _orderHub = orderHub;
            _database = redis.GetDatabase();
            _claimService = claimService;
            _notificationHub = notificationHub;
            _userManager = userManager;
        }

        public async Task<Guid> Handle(ConfirmOrderToCookCommand request, CancellationToken cancellationToken)
        {
            var userId = _claimService.UserId;
            var employee = await _userManager.FindByIdAsync(userId.ToString())
                ?? throw new AppException("Employee not found");

            var employeeRole = await _userManager.GetRolesAsync(employee);
            if (!employeeRole.Contains(Domain.Entities.UserAggregator.Enums.Role.Waiter.ToString()))
            {
                throw new AppException("You are not allowed to confirm the order");
            }

            var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails, o => o.Table)
                ?? throw new Exception("Order not found");

            if (order.OrderStatus != OrderStatus.Prepare)
            {
                throw new AppException("Hiện đơn hàng này không có món nào để chế biến");
            }
            var responsibility = new OrderResponsibility
            {
                OrderId = order.Id,
                EmployeeCode = employee.EmployeeCode,
                EmployeeName = $"{employee.FullName}",
                OrderResponsibilityType = OrderResponsibilityType.ConfirmOrder
            };
            await _unitOfWorks.OrderResponsibilityRepository.AddAsync(responsibility);

            order.OrderStatus = OrderStatus.Cook;

            var headChefs = await _userManager.GetUsersInRoleAsync(Domain.Entities.UserAggregator.Enums.Role.HeadChef.ToString());
            var headChef = headChefs.FirstOrDefault(hc => hc.RestaurantId == order.Table.RestaurantId);
            if (headChef == null)
            {
                throw new AppException("Head chef not found for this restaurant");
            }
            var ingredientUpdates = new Dictionary<Guid, int>();
            var refundableDishes = new List<OrderDetail>();

            foreach (var detail in order.OrderDetails)
            {
                if (detail.Status != OrderDetailsStatus.Prepare)
                {
                    continue;
                }

                if (detail.IsRefund)
                {
                    refundableDishes.Add(detail);
                }
                else
                {
                    detail.Status = OrderDetailsStatus.Cook;

                    if (detail.ProductId != null)
                    {
                        await ReduceDishIngredients((Guid)detail.ProductId, detail.Quantity, ingredientUpdates);
                    }
                    else if (detail.ComboId != null)
                    {
                        await ReduceComboIngredients((Guid)detail.ComboId, detail.Quantity, ingredientUpdates);
                    }
                }
            }

            await UpdateIngredients(ingredientUpdates);

            order.OrderStatus = OrderStatus.Cook;
            _unitOfWorks.OrderRepository.Update(order);
            await _unitOfWorks.SaveChangeAsync();

            if (refundableDishes.Any())
            {
                //Notification FCM to waiter at here
                //await _orderHub.NotifyWaiterAboutRefundableDishes(refundableDishes.Select(d => d.Id).ToList());
            }

            await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());
            return order.Id;
        }


        private async Task ReduceDishIngredients(Guid dishId, int quantity, Dictionary<Guid, int> ingredientUpdates)
        {
            var dish = await _unitOfWorks.DishRepository.GetByIdAsync(dishId, d => d.DishIngredients);
            if (dish == null) throw new Exception("Dish not found");

            foreach (var dishIngredient in dish.DishIngredients)
            {
                var ingredientId = dishIngredient.IngredientId;
                var requiredAmount = dishIngredient.Quantity * quantity;
                var lockKey = $"lock:ingredient:{ingredientId}";

                var currentLocked = await _database.StringGetAsync(lockKey);
                var lockedAmount = currentLocked.HasValue ? (int)currentLocked : 0;

                if (lockedAmount >= requiredAmount)
                {
                    if (ingredientUpdates.ContainsKey(ingredientId))
                    {
                        ingredientUpdates[ingredientId] += (int)requiredAmount;
                    }
                    else
                    {
                        ingredientUpdates[ingredientId] = (int)requiredAmount;
                    }

                    await _database.StringSetAsync(lockKey, (long)(lockedAmount - requiredAmount));
                }
                else
                {
                    throw new Exception($"Insufficient locked ingredient amount of {lockKey}. Required: {requiredAmount}, Locked: {lockedAmount}");
                }
            }
        }

        private async Task ReduceComboIngredients(Guid comboId, int quantity, Dictionary<Guid, int> ingredientUpdates)
        {
            var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(comboId, c => c.DishCombos);
            if (combo == null) throw new Exception("Combo not found");

            foreach (var dishCombo in combo.DishCombos)
            {
                await ReduceDishIngredients(dishCombo.DishId, quantity, ingredientUpdates);
            }
        }

        private async Task UpdateIngredients(Dictionary<Guid, int> ingredientUpdates)
        {
            foreach (var update in ingredientUpdates)
            {
                var ingredientId = update.Key;
                var amountToReduce = update.Value;

                var existingIngredient = await _unitOfWorks.IngredientRepository
                    .FirstOrDefaultAsync(e => e.Id == ingredientId);

                if (existingIngredient == null)
                {
                    throw new Exception($"Ingredient with ID {ingredientId} not found");
                }

                existingIngredient.IngredientAmount -= amountToReduce;
                _unitOfWorks.IngredientRepository.Update(existingIngredient);
            }
        }
    }
}
