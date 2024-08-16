using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Order.Commands.Create;

public record OrderDetailDto(Guid? ComboId, Guid? ProductId, string Status, int Quantity, decimal Price);
public record CreateOrderWithTableIdCommand(
    string OrderStatus,
    string OrderType,
    DateTime OrderTime,
    decimal TotalPrice,
    List<OrderDetailDto> OrderDetails) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid TableId { get; set; }
}
public class CreateOrderHandler : IRequestHandler<CreateOrderWithTableIdCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CreateOrderHandler(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<Guid> Handle(CreateOrderWithTableIdCommand request, CancellationToken cancellationToken)
    {
        var order = new Domain.Entities.OrderAggregator.Order(request.OrderStatus, request.OrderType, request.OrderTime, request.TotalPrice)
        {
            TableId = request.TableId,
            OrderDetails = new List<Domain.Entities.OrderAggregator.OrderDetail>()
        };

        foreach (var detail in request.OrderDetails)
        {
            var orderDetail = new Domain.Entities.OrderAggregator.OrderDetail(
                detail.ComboId,
                detail.ProductId,
                null,
                detail.Status,
                detail.Quantity,
                detail.Price
            );

            order.OrderDetails.Add(orderDetail);
        }

        await _unitOfWorks.OrderRepository.AddAsync(order);
        await _unitOfWorks.SaveChangeAsync();
        return order.Id;
    }
}
