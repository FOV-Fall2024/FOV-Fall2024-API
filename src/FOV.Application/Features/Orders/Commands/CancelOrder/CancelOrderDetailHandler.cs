using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
public record CancelOrderDetailCommand(Guid OrderId) : IRequest<Guid>;
public class CancelOrderDetailHandler : IRequestHandler<CancelOrderDetailCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IDatabase _database;
    private readonly OrderHub _orderHub;
    private readonly IClaimService _claimService;
    private readonly UserManager<User> _userManager;

    public CancelOrderDetailHandler(IUnitOfWorks unitOfWorks, IDatabase database, OrderHub orderHub, IClaimService claimService, UserManager<User> userManager)
    {
        _unitOfWorks = unitOfWorks;
        _database = database;
        _orderHub = orderHub;
        _claimService = claimService;
        _userManager = userManager;
    }

    public async Task<Guid> Handle(CancelOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var userId = _claimService.UserId;
        var employee = await _userManager.FindByIdAsync(userId.ToString())
            ?? throw new AppException("Employee not found");

        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails);
        if (order == null)
        {
            throw new Exception("Order not found.");
        }

        var addMoreOrderDetails = order.OrderDetails
            .Where(od => od.IsAddMore && od.Status == OrderDetailsStatus.Prepare)
            .ToList();

        if (!addMoreOrderDetails.Any())
        {
            throw new AppException("Hiện tại không có món ăn nào được thêm, vui lòng kiểm tra lại.");
        }

        var responsibilities = new List<OrderResponsibility>();
        foreach (var orderDetail in addMoreOrderDetails)
        {
            orderDetail.Status = OrderDetailsStatus.Canceled;
            _unitOfWorks.OrderDetailRepository.Update(orderDetail);

            var responsibility = new OrderResponsibility
            {
                OrderId = order.Id,
                OrderDetailId = orderDetail.Id,
                EmployeeCode = employee.EmployeeCode,
                EmployeeName = employee.FullName,
                OrderResponsibilityType = OrderResponsibilityType.Cancel
            };
            responsibilities.Add(responsibility);

            var refundAmount = orderDetail.Quantity * orderDetail.Price;
            order.TotalPrice -= refundAmount;

            if (orderDetail.ProductId.HasValue)
            {
                await ReleaseIngredientLocks(orderDetail.ProductId.Value, orderDetail.Quantity);
            }
            else if (orderDetail.ComboId.HasValue)
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
            _unitOfWorks.OrderDetailRepository.Update(orderDetail);
        }

        if (order.OrderDetails.All(od => !od.IsAddMore || od.Status == OrderDetailsStatus.Canceled))
        {
            order.OrderStatus = OrderStatus.Service;
            _unitOfWorks.OrderRepository.Update(order);
        }
        await _unitOfWorks.OrderResponsibilityRepository.AddRangeAsync(responsibilities);

        await _unitOfWorks.SaveChangeAsync();
        await _orderHub.CancelAddMoreOrder(order.Id, "Canceled");
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
