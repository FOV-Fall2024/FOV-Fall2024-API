using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Orders.Commands.ChangeStateOrder;

public record ConfirmOrderToServeCommand(Guid OrderId, Guid OrderDetailId) : IRequest<Guid>;

public class ConfirmOrderToServeHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, IClaimService claimService, NotificationHub notificationHub, UserManager<User> userManager) : IRequestHandler<ConfirmOrderToServeCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    private readonly OrderHub _orderHub = orderHub;
    private readonly UserManager<User> _userManager = userManager;
    public async Task<Guid> Handle(ConfirmOrderToServeCommand request, CancellationToken cancellationToken)
    {
        var userId = _claimService.UserId;
        var employee = await _userManager.FindByIdAsync(userId.ToString())
            ?? throw new AppException("Employee not found");

        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails, o => o.Table)
            ?? throw new Exception("Order not found.");

        var orderDetail = order.OrderDetails.FirstOrDefault(d => d.Id == request.OrderDetailId);
        if (orderDetail == null)
        {
            throw new Exception("Order detail not found.");
        }

        var orderResponsibility = new OrderResponsibility
        {
            OrderId = order.Id,
            EmployeeCode = employee.EmployeeCode,
            EmployeeName = $"{employee.FullName}",
            OrderResponsibilityType = OrderResponsibilityType.Serve,
            OrderDetailId = orderDetail.Id
        };
        await _unitOfWorks.OrderResponsibilityRepository.AddAsync(orderResponsibility);

        orderDetail.Status = OrderDetailsStatus.Service;
        _unitOfWorks.OrderDetailRepository.Update(orderDetail);

        var productIdOrComboId = orderDetail.ComboId ?? orderDetail.ProductId;
        var status = orderDetail.Status.ToString();
        await _orderHub.UpdateOrderDetailsStatus(order.Id, productIdOrComboId.Value, status);

        if (order.OrderDetails.All(d => d.Status == OrderDetailsStatus.Service))
        {
            order.OrderStatus = OrderStatus.Service;
            _unitOfWorks.OrderRepository.Update(order);
            await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());
        }

        await _unitOfWorks.SaveChangeAsync();

        return order.Id;
    }
}
