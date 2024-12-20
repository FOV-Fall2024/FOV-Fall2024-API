﻿using System;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.CancelOrder;

public record CancelOrderCommand(Guid OrderId) : IRequest<Guid>;

public class CancelOrderHandler : IRequestHandler<CancelOrderCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IDatabase _database;
    private readonly OrderHub _orderHub;
    private readonly IClaimService _claimService;
    private readonly UserManager<User> _userManager;

    public CancelOrderHandler(IUnitOfWorks unitOfWorks, IDatabase database, OrderHub orderHub, IClaimService claimService, UserManager<User> userManager)
    {
        _unitOfWorks = unitOfWorks;
        _database = database;
        _orderHub = orderHub;
        _claimService = claimService;
        _userManager = userManager;
    }

    public async Task<Guid> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var userId = _claimService.UserId;
        var employee = await _userManager.FindByIdAsync(userId.ToString())
            ?? throw new AppException("Employee not found");

        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Order not found");
        var table = await _unitOfWorks.TableRepository.GetByIdAsync(order.TableId)
            ?? throw new Exception("Table not found");
        var responsibilities = new List<OrderResponsibility>();

        foreach (var orderDetail in order.OrderDetails)
        {
            var responsibility = new OrderResponsibility
            {
                OrderId = order.Id,
                OrderDetailId = orderDetail.Id,
                EmployeeCode = employee.EmployeeCode,
                EmployeeName = employee.FullName,
                OrderResponsibilityType = OrderResponsibilityType.Cancel
            };
            responsibilities.Add(responsibility);

            orderDetail.Status = OrderDetailsStatus.Canceled;
            _unitOfWorks.OrderDetailRepository.Update(orderDetail);

            if (orderDetail.ComboId.HasValue)
            {
                var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(orderDetail.ComboId.Value, c => c.DishCombos);
                if (combo != null)
                {
                      foreach (var dishCombo in combo.DishCombos)
                    {
                        await ReleaseIngredientLocks(dishCombo.DishId, orderDetail.Quantity);
                    }
                }
            }
            else if (orderDetail.ProductId.HasValue)
            {
                await ReleaseIngredientLocks(orderDetail.ProductId.Value, orderDetail.Quantity);
            }
        }
        table.TableStatus = Domain.Entities.TableAggregator.Enums.TableStatus.Available;
        _unitOfWorks.TableRepository.Update(table);

        order.OrderStatus = OrderStatus.Canceled;
        _unitOfWorks.OrderRepository.Update(order);
        await _unitOfWorks.OrderResponsibilityRepository.AddRangeAsync(responsibilities);

        await _unitOfWorks.SaveChangeAsync();
        await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());

        return order.Id;
    }

    private async Task ReleaseIngredientLocks(Guid dishId, int quantity)
    {
        var dish = await _unitOfWorks.DishRepository.GetByIdAsync(dishId, d => d.DishIngredients);
        if (dish == null) return;

        foreach (var dishIngredient in dish.DishIngredients)
        {
            var releaseAmount = dishIngredient.Quantity * quantity;
            string ingredientLockKey = $"lock:ingredient:{dishIngredient.IngredientId}";

            var lockedAmount = (int)(await _database.StringGetAsync(ingredientLockKey));
            var newLockedAmount = Math.Max(0, lockedAmount - releaseAmount);

            if (newLockedAmount > 0)
            {
                await _database.StringSetAsync(ingredientLockKey, (long)newLockedAmount);
            }
            else
            {
                await _database.KeyDeleteAsync(ingredientLockKey);
            }
        }
    }
}
