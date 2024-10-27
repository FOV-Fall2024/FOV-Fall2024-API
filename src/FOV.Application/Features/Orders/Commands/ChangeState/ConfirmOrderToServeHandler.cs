using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.ChangeStateOrder;
public record ConfirmOrderToServeCommand(Guid OrderId, Guid OrderDetails) : IRequest<Guid>;
public class ConfirmOrderToServeHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub) : IRequestHandler<ConfirmOrderToServeCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;

    public async Task<Guid> Handle(ConfirmOrderToServeCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng");

        var orderDetail = order.OrderDetails.FirstOrDefault(d => d.Id == request.OrderDetails);
        if (orderDetail == null)
        {
            throw new Exception("Không tìm thấy chi tiết đơn hàng");
        }

        orderDetail.Status = OrderDetailsStatus.Service;
        _unitOfWorks.OrderDetailRepository.Update(orderDetail);

        if (order.OrderDetails.All(d => d.Status == OrderDetailsStatus.Service))
        {
            order.OrderStatus = OrderStatus.Service;
            _unitOfWorks.OrderRepository.Update(order);
        }

        await _unitOfWorks.SaveChangeAsync();
        await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());

        return order.Id;
    }
}
