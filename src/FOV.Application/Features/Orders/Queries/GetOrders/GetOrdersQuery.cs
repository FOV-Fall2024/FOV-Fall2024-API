using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrders;
public record GetOrdersRequest(Guid? Id, OrderStatus? OrderStatus, OrderType? OrderType, DateTime? OrderTime, Guid? TableId) : IRequest<List<GetOrdersResponse>>;
public record GetOrdersResponse(Guid Id, OrderStatus OrderStatus, OrderType OrderType, decimal TotalPrice, DateTime OrderTime, Guid TalbeId);
public class GetOrdersQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetOrdersRequest, List<GetOrdersResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<GetOrdersResponse>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
    {
        var orders = await _unitOfWorks.OrderRepository.GetAllAsync();
        var filterEntity = new Domain.Entities.OrderAggregator.Order
        {
            Id = request.Id ?? Guid.Empty,
            OrderStatus = request.OrderStatus ?? OrderStatus.Finish,
            OrderType = request.OrderType ?? OrderType.OrderAtTable,
            OrderTime = request.OrderTime ?? DateTime.MinValue,
            TableId = request.TableId ?? Guid.Empty
        };
        var filteredOrder = orders.AsQueryable().CustomFilterV1(filterEntity);
        return filteredOrder.Select(o => new GetOrdersResponse(
                       o.Id,
                                  o.OrderStatus ?? OrderStatus.Finish,
                                             o.OrderType ?? OrderType.OrderAtTable,
                                                        o.TotalPrice,
                                                                   o.OrderTime ?? DateTime.MinValue,
                                                                              o.TableId)).ToList();
    }
}
