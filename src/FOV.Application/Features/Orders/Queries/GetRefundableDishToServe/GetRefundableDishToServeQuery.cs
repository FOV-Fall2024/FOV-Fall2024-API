using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.Orders.Queries.SuggestDishesForHeadchef;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetRefundableDishToServe;
public record GetRefundableDishToServeCommand(PagingRequest? PagingRequest) : IRequest<PagedResult<GetRefundableDishToServeResponse>>;
public record GetRefundableDishToServeResponse(Guid? OrderId, Guid Id, string DishName, string? Note, DateTime CreatedDate);
public class GetRefundableDishToServeQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetRefundableDishToServeCommand, PagedResult<GetRefundableDishToServeResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<PagedResult<GetRefundableDishToServeResponse>> Handle(GetRefundableDishToServeCommand request, CancellationToken cancellationToken)
    {
        var restaurantId = _claimService.RestaurantId;

        var orderDetails = await _unitOfWorks.OrderDetailRepository.WhereAsync(x => x.Order.Table.RestaurantId == restaurantId && x.IsRefund && x.Status == OrderDetailsStatus.Cooked, x => x.Order.Table, x => x.Dish.DishGeneral);
        var refundableDishes = orderDetails.Select(d => new GetRefundableDishToServeResponse(d.OrderId, d.Id, d.Dish.DishGeneral.DishName, d.Note, d.Created)).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResults = PaginationHelper<GetRefundableDishToServeResponse>.Sorting(sortType, refundableDishes, sortField);
        var result = PaginationHelper<GetRefundableDishToServeResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
