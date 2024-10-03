using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FOV.Application.Features.Orders.Commands.CreateOrder;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using StackExchange.Redis;

namespace FOV.Application.Features.Orders.Commands.AddProduct;
public record AddProductsToOrdersCommand(List<GetOrderDetailDto> NewOrderDetails) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
}
public record GetOrderDetailDto(Guid? ComboId, Guid? ProductId, int Quantity, decimal Price)
{
    [JsonIgnore]
    public OrderDetailsStatus Status = OrderDetailsStatus.Prepare;
}
public class AddProductsToOrdersHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddProductsToOrdersCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(AddProductsToOrdersCommand request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng");

        foreach (var detail in request.NewOrderDetails)
        {
            var orderDetail = new OrderDetail(
                    detail.ComboId,
                    detail.ProductId,
                    null,
                    detail.Quantity,
                    detail.Price
                )
            {
                Status = detail.Status
            };

            orders.OrderDetails.Add(orderDetail);
        }
        orders.OrderStatus = Domain.Entities.OrderAggregator.Enums.OrderStatus.Cook;

        _unitOfWorks.OrderRepository.Update(orders);
        await _unitOfWorks.SaveChangeAsync();

        return orders.Id;
    }
}
