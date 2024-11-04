using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.ChangeStateOrder;

public record ConfirmOrderToServeCommand(Guid OrderId, Guid OrderDetailId) : IRequest<Guid>;

public class ConfirmOrderToServeHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, NotificationHub notificationHub) : IRequestHandler<ConfirmOrderToServeCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;
    private readonly NotificationHub _notificationHub = notificationHub;
    public async Task<Guid> Handle(ConfirmOrderToServeCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails, o => o.Employee)
            ?? throw new Exception("Order not found.");

        var orderDetail = order.OrderDetails.FirstOrDefault(d => d.Id == request.OrderDetailId);
        if (orderDetail == null)
        {
            throw new Exception("Order detail not found.");
        }
        var employee = order.Employee ?? throw new AppException("Không có nhân viên hợp lệ");
        var userId = employee.UserId ?? throw new AppException("User ID not found for the employee.");

        orderDetail.Status = OrderDetailsStatus.Service;
        _unitOfWorks.OrderDetailRepository.Update(orderDetail);

        var productIdOrComboId = orderDetail.ComboId ?? orderDetail.ProductId;
        var status = orderDetail.Status.ToString();
        await _orderHub.UpdateOrderDetailsStatus(order.Id, productIdOrComboId.Value, status);
        await _notificationHub.SendNotificationToWaiter(userId, order.Id, orderDetail.Id);

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
