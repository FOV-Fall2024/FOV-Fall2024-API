using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

namespace FOV.Application.Features.Orders.Commands.RefundOrder;
public record RefundOrderCommand(Guid OrderId, Guid OrderDetailId, int RefundQuantity) : IRequest<Guid>;
public class RefundOrderHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, IClaimService claimService, UserManager<User> userManager) : IRequestHandler<RefundOrderCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;
    private readonly IClaimService _claimService = claimService;
    private readonly UserManager<User> _userManager = userManager;
    public async Task<Guid> Handle(RefundOrderCommand request, CancellationToken cancellationToken)
    {
        var userId = _claimService.UserId;
        var employee = await _userManager.FindByIdAsync(userId.ToString())
            ?? throw new AppException("Employee not found");

        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng nào");

        var orderDetail = order.OrderDetails.FirstOrDefault(od => od.Id == request.OrderDetailId)
            ?? throw new Exception("Không tìm thấy món ăn này trong đơn hàng");

        if (!orderDetail.IsRefund)
        {
            throw new Exception("Món ăn này không thể hoàn tiền");
        }

        if (request.RefundQuantity > (orderDetail.Quantity - orderDetail.RefundQuantity))
        {
            throw new Exception("Số lượng hoàn tiền vượt quá số lượng đã đặt");
        }

        var productIdOrComboId = orderDetail.ProductId ?? orderDetail.ComboId;
        if (orderDetail.ProductId != null)
        {
            var dish = await _unitOfWorks.DishRepository.GetByIdAsync(orderDetail.ProductId.Value, d => d.RefundDishInventory);
            if (dish == null) throw new Exception("Không tìm thấy thông tin món ăn để hoàn tiền");

            dish.RefundDishInventory.QuantityAvailable += request.RefundQuantity;
            _unitOfWorks.DishRepository.Update(dish);
        }
        else if (orderDetail.ComboId != null)
        {
            var combo = await _unitOfWorks.ComboRepository.GetByIdAsync(orderDetail.ComboId.Value, c => c.DishCombos);
            if (combo == null) throw new Exception("Không tìm thấy thông tin combo để hoàn tiền");

            foreach (var dishCombo in combo.DishCombos)
            {
                var dish = await _unitOfWorks.DishRepository.GetByIdAsync(dishCombo.DishId, d => d.RefundDishInventory);
                if (dish != null)
                {
                    dish.RefundDishInventory.QuantityAvailable += request.RefundQuantity * dishCombo.Quantity;
                    _unitOfWorks.DishRepository.Update(dish);
                }
            }
        }

        var refundAmount = orderDetail.Price * request.RefundQuantity;
        order.TotalPrice -= refundAmount;
        orderDetail.RefundQuantity += request.RefundQuantity;

        var orderResponsibility = new OrderResponsibility
        {
            OrderId = order.Id,
            EmployeeCode = employee.EmployeeCode,
            EmployeeName = $"{employee.FullName}",
            OrderResponsibilityType = OrderResponsibilityType.Refund,
            OrderDetailId = orderDetail.Id
        };
        await _unitOfWorks.OrderResponsibilityRepository.AddAsync(orderResponsibility);

        if (order.OrderDetails.All(od => !od.IsAddMore || od.Status == OrderDetailsStatus.Canceled))
        {
            order.OrderStatus = OrderStatus.Service;
            _unitOfWorks.OrderRepository.Update(order);
        }

        _unitOfWorks.OrderRepository.Update(order);
        await _unitOfWorks.SaveChangeAsync();

        await _orderHub.RefundOrderDetails(order.Id, productIdOrComboId.Value, request.RefundQuantity);

        return order.Id;
    }
}
