using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
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

        public ConfirmOrderToCookHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, IConnectionMultiplexer redis, IClaimService claimService, NotificationHub notificationHub)
        {
            _unitOfWorks = unitOfWorks;
            _orderHub = orderHub;
            _database = redis.GetDatabase();
            _claimService = claimService;
            _notificationHub = notificationHub;
        }

        public async Task<Guid> Handle(ConfirmOrderToCookCommand request, CancellationToken cancellationToken)
        {
            //var UserId = _claimService.UserId ?? throw new AppException("Employee not found.");
            //var employee = await _unitOfWorks.EmployeeRepository.FirstOrDefaultAsync(x => x.UserId == UserId);

            //var EmployeeRole = _claimService.UserRole;

            //if (EmployeeRole != Domain.Entities.UserAggregator.Enums.Role.Waiter)
            //{
            //    throw new AppException("You are not allowed to connfirm order");
            //}

            //var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            //    ?? throw new Exception("Order not found");

            //order.EmployeeId = employee.Id;
            //if (order.OrderStatus != OrderStatus.Prepare)
            //{
            //    throw new AppException("Hiện đơn hàng này không có món nào để chế biến");
            //}
            //order.OrderStatus = OrderStatus.Cook;

            //var ingredientUpdates = new Dictionary<Guid, int>();

            //foreach (var detail in order.OrderDetails)
            //{
            //    if (detail.Status != OrderDetailsStatus.Prepare)
            //    {
            //        continue;
            //    }

            //    detail.Status = OrderDetailsStatus.Cook;

            //    if (detail.ProductId != null)
            //    {
            //        await ReduceDishIngredients((Guid)detail.ProductId, detail.Quantity, ingredientUpdates);
            //    }
            //    else if (detail.ComboId != null)
            //    {
            //        await ReduceComboIngredients((Guid)detail.ComboId, detail.Quantity, ingredientUpdates);
            //    }
            //}

            //await UpdateIngredients(ingredientUpdates);

            //_unitOfWorks.OrderRepository.Update(order);
            //await _unitOfWorks.SaveChangeAsync();

            //await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());
            ////await _orderHub.SendOrderToHeadChef(order.Id);

            //return order.Id;
            throw new NotImplementedException();
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
