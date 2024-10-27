using FOV.Application.Features.Orders.Responses;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrderDetails;

public record GetOrderDetailsCommand(Guid OrderId) : IRequest<GetOrderDetailsResponse>;
public class GetOrderDetailsQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetOrderDetailsCommand, GetOrderDetailsResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Order not found.");

        var orderDetailsDtos = order.OrderDetails.Select(o => new OrderDetailsDto(
            o.Id,
            o.ComboId,
            o.ProductId,
            o.Status.HasValue ? o.Status.Value.ToString() : null,
            o.Quantity,
            o.Price,
            o.Note
        )).ToList();

        return new GetOrderDetailsResponse(
            order.Id,
            order.OrderStatus.ToString(),
            order.TotalPrice,
            order.OrderTime,
            orderDetailsDtos
        );
    }
}
