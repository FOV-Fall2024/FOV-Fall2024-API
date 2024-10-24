using FOV.Application.Features.Orders.Responses;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrderDetails;
public record GetOrderDetailsCommand(Guid OrderId) : IRequest<GetOrderDetailsResponse>;

public class GetOrderDetailsQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetOrderDetailsCommand, GetOrderDetailsResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var orderDetails = await _unitOfWorks.OrderDetailRepository.GetByOrderIdAsync(request.OrderId);
        return new GetOrderDetailsResponse(request.OrderId, orderDetails.Select(o => new OrderDetailsDto(
                       o.Id,
                                  o.ComboId,
                                             o.ProductId,
                                                        o.Status,
                                                                   o.Quantity,
                                                                              o.Price, o.Note
                                                                                     )).ToList());
    }
}
