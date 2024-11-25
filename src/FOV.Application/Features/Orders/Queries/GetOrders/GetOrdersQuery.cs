using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrders;

public record GetOrdersRequest(Guid? Id, OrderStatus? OrderStatus, DateTime? OrderTime, Guid? TableId) : IRequest<List<GetOrdersResponse>>;
public record GetOrdersResponse(Guid Id, string OrderStatus, decimal TotalPrice, DateTime OrderTime, Guid TableId, int TableNumber);

public class GetOrdersQuery : IRequestHandler<GetOrdersRequest, List<GetOrdersResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;
    public GetOrdersQuery(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;
    }

    public async Task<List<GetOrdersResponse>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
    {
        var restaurantId = _claimService.RestaurantId;
        List<Order> orders = new List<Order>();
        if (_claimService.UserRole == Role.Administrator)
        {
            orders = await _unitOfWorks.OrderRepository.WhereAsync(x => x.Table.RestaurantId == restaurantId, x => x.Table);
        }
        else
        {
            orders = await _unitOfWorks.OrderRepository.WhereAsync(x => x.Table.RestaurantId == restaurantId, x => x.Table);
        }   

        var filterEntity = new Domain.Entities.OrderAggregator.Order
        {
            Id = request.Id ?? Guid.Empty,
            OrderStatus = request.OrderStatus ?? OrderStatus.Finish,
            OrderTime = request.OrderTime ?? DateTime.MinValue,
            TableId = request.TableId ?? Guid.Empty,
        };

        var filteredOrder = orders.AsQueryable().CustomFilterV1(filterEntity);

        return filteredOrder.Select(o => new GetOrdersResponse(
            o.Id,
            o.OrderStatus != null ? o.OrderStatus.ToString() : OrderStatus.Finish.ToString(),
            o.TotalPrice,
            o.OrderTime,
            o.TableId,
            o.Table.TableNumber)).ToList();
    }
}
