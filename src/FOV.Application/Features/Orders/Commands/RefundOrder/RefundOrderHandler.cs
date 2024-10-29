using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.RefundOrder;
public record RefundOrderCommand(Guid OrderDetailId, int RefundQuantity) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
}
public class RefundOrderHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub) : IRequestHandler<RefundOrderCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;
    public async Task<Guid> Handle(RefundOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng nào");

        var orderDetail = order.OrderDetails.FirstOrDefault(od => od.Id == request.OrderDetailId)
            ?? throw new Exception("Không tìm thấy món ăn này trong đơn hàng");

        var productIdOrComboId = orderDetail.ProductId ?? orderDetail.ComboId;

        if (orderDetail.IsRefund)
        {
            var dish = await _unitOfWorks.DishRepository.GetByIdAsync(orderDetail.ProductId.Value, d => d.RefundDishInventory);
            if (dish == null) throw new Exception("Không tìm thấy thông tin món ăn để hoàn tiền");

            dish.RefundDishInventory.QuantityAvailable += request.RefundQuantity;
            _unitOfWorks.DishRepository.Update(dish);

            orderDetail.RefundQuantity += request.RefundQuantity;

            _unitOfWorks.OrderRepository.Update(order);
            await _unitOfWorks.SaveChangeAsync();
        }
        else
        {
            throw new Exception("Món ăn này không thể hoàn tiền");
        }

        await _orderHub.RefundOrderDetails(order.Id, orderDetail.ProductId.Value, request.RefundQuantity);
        return order.Id;
    }
}
