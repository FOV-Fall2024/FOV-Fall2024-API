using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrderDetails;
public record GetOrderDetailsCommand(Guid OrderId) : IRequest<GetOrderDetailsResponse>;
public record GetOrderDetailsResponse(Guid OrderId, List<OrderDetailsDto> OrderDetails);
public record OrderDetailsDto(Guid Id, Guid? ComboId, Guid? ProductId, OrderDetailsStatus? Status, int Quantity, decimal Price);
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
                                                                              o.Price
                                                                                     )).ToList());
    }
}
