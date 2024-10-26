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
public record ConfirmOrderToCookCommand(Guid OrderId) : IRequest<Guid>;
public class ConfirmOrderToCookHandler : IRequestHandler<ConfirmOrderToCookCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly OrderHub _orderHub;
    public ConfirmOrderToCookHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub)
    {
        _unitOfWorks = unitOfWorks;
        _orderHub = orderHub;
    }
    public async Task<Guid> Handle(ConfirmOrderToCookCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng");

        order.OrderStatus = OrderStatus.Cook;

        foreach (var detail in order.OrderDetails)
        {
            detail.Status = OrderDetailsStatus.Cook;
        }

        _unitOfWorks.OrderRepository.Update(order);
        await _unitOfWorks.SaveChangeAsync();
        await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());

        return order.Id;
    }
}
