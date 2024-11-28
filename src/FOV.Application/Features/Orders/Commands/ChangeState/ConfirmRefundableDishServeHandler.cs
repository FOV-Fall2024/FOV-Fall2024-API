using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.ChangeState;
public record ConfirmRefundableDishServeCommand(Guid OrderId, Guid OrderDetailId) : IRequest<Guid>;
public class ConfirmRefundableDishServeHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub) : IRequestHandler<ConfirmRefundableDishServeCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;
    public async Task<Guid> Handle(ConfirmRefundableDishServeCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
                ?? throw new AppException("Order not found");

        var orderDetail = order.OrderDetails.FirstOrDefault(d => d.Id == request.OrderDetailId)
            ?? throw new AppException("Order detail not found");

        if (!orderDetail.IsRefund || orderDetail.Status != OrderDetailsStatus.Prepare)
        {
            throw new AppException("This dish is not refundable or not in a valid state for serving");
        }

        orderDetail.Status = OrderDetailsStatus.Service;

        if (order.OrderDetails.All(d => d.Status == OrderDetailsStatus.Service))
        {
            order.OrderStatus = OrderStatus.Service;
            await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());
            _unitOfWorks.OrderRepository.Update(order);
        }

        _unitOfWorks.OrderDetailRepository.Update(orderDetail);
        await _unitOfWorks.SaveChangeAsync();

        await _orderHub.UpdateOrderDetailsStatus(orderDetail.Id, orderDetail.ProductId.Value, orderDetail.Status.ToString());

        return order.Id;
    }
}   
