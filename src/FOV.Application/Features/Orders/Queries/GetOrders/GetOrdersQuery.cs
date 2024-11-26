using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.Migrations;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrders;

public record GetOrdersRequest(PagingRequest? PagingRequest, Guid? Id, OrderStatus? OrderStatus, string? PhoneNumber, DateTime? OrderTime, Guid? TableId) : IRequest<PagedResult<GetOrdersResponse>>;
public record GetOrdersResponse(Guid Id, string OrderStatus, decimal TotalPrice, decimal ReduceAmount, decimal FinalAmount, DateTime OrderTime, Guid TableId, int TableNumber, string CustomerName, string? PhoneNumber, string? Feedback, DateTime CreatedDate);

public class GetOrdersQuery : IRequestHandler<GetOrdersRequest, PagedResult<GetOrdersResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;
    public GetOrdersQuery(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;
    }

    public async Task<PagedResult<GetOrdersResponse>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
    {
        var restaurantId = _claimService.RestaurantId;

        var orders = await _unitOfWorks.OrderRepository.WhereAsync(
            x => x.Table.RestaurantId == restaurantId,
            x => x.Table,
            x => x.Customer,
            x => x.Payments
        );

        if (request.Id.HasValue)
        {
            orders = orders.Where(o => o.Id == request.Id.Value).ToList();
        }

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            orders = orders.Where(o => o.Customer != null && o.Customer.PhoneNumber == request.PhoneNumber).ToList();
        }

        if (request.OrderStatus.HasValue)
        {
            orders = orders.Where(o => o.OrderStatus == request.OrderStatus.Value).ToList();
        }

        if (request.OrderTime.HasValue)
        {
            orders = orders.Where(o => o.OrderTime.Date == request.OrderTime.Value.Date).ToList();
        }

        if (request.TableId.HasValue)
        {
            orders = orders.Where(o => o.TableId == request.TableId.Value).ToList();
        }
        var mappedOrder = orders.Select(o =>
        {
            var payment = o.Payments.FirstOrDefault(p => p.OrderId == o.Id);

            return new GetOrdersResponse(
                o.Id,
                o.OrderStatus != null ? o.OrderStatus.ToString() : OrderStatus.Finish.ToString(),
                o.TotalPrice,
                payment?.ReduceAmount ?? 0,
                payment?.FinalAmount ?? 0,
                o.OrderTime,
                o.TableId,
                o.Table.TableNumber,
                o.Customer != null ? o.Customer.FullName : "Khách",
                o.Customer?.PhoneNumber,
                o.Feedback,
                o.Created
            );
        }).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<GetOrdersResponse>.Sorting(sortType, mappedOrder, sortField);
        var result = PaginationHelper<GetOrdersResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }

}
