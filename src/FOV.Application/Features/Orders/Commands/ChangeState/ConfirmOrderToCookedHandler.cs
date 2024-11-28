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
public record ConfirmOrderCookedCommand(Guid OrderId, Guid OrderDetailId) : IRequest<Guid>;
public class ConfirmOrderToCookedHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub) : IRequestHandler<ConfirmOrderCookedCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;
    public async Task<Guid> Handle(ConfirmOrderCookedCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new AppException("Order not found");

        var orderDetail = order.OrderDetails.FirstOrDefault(d => d.Id == request.OrderDetailId)
            ?? throw new AppException("Order detail not found");

        if (orderDetail.Status != OrderDetailsStatus.Cook)
        {
            throw new AppException("Món ăn này chưa được confirm nên không thể confirm là nấu xong được");
        }

        orderDetail.Status = OrderDetailsStatus.Cooked;

        if (order.OrderDetails.All(d => d.Status == OrderDetailsStatus.Cooked))
        {
            order.OrderStatus = OrderStatus.Cooked;
            await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());
        }

        _unitOfWorks.OrderDetailRepository.Update(orderDetail);
        await _unitOfWorks.SaveChangeAsync();

        await _orderHub.UpdateOrderDetailsStatus(orderDetail.Id, orderDetail.ProductId ?? Guid.Empty, orderDetail.Status.ToString());

        return order.Id;
    }
}
