using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.ChangeStateOrder;

public record ConfirmOrderToServeCommand(Guid OrderId, Guid OrderDetailId) : IRequest<Guid>;

public class ConfirmOrderToServeHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub) : IRequestHandler<ConfirmOrderToServeCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;

    public async Task<Guid> Handle(ConfirmOrderToServeCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Order not found.");

        var orderDetail = order.OrderDetails.FirstOrDefault(d => d.Id == request.OrderDetailId);
        if (orderDetail == null)
        {
            throw new Exception("Order detail not found.");
        }

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
