using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.DishGeneralAggregator.Enums;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.SuggestDishesForHeadchef;
public record SuggestDishesForHeadchefCommand(PagingRequest? PagingRequest, Guid RestaurantId) : IRequest<PagedResult<SuggestDishesForHeadchefResponse>>;
public record SuggestDishesForHeadchefResponse(Guid Id, string DishName, PriorityDish PriorityDish, DateTime CreatedDate);
public class SuggestDishesForHeadchefQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<SuggestDishesForHeadchefCommand, PagedResult<SuggestDishesForHeadchefResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<SuggestDishesForHeadchefResponse>> Handle(SuggestDishesForHeadchefCommand request, CancellationToken cancellationToken)
    {
        var orderDishes = await _unitOfWorks.OrderRepository.GetOrderDishes(request.RestaurantId);

        var prioritizedDishes = orderDishes
            .OrderBy(d => d.PriorityDish)
            .ThenByDescending(d => d.Created)
            .Select(d => new SuggestDishesForHeadchefResponse(d.Id, d.DishName, d.PriorityDish, d.Created))
            .ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResults = PaginationHelper<SuggestDishesForHeadchefResponse>.Sorting(sortType, prioritizedDishes, sortField);
        var result = PaginationHelper<SuggestDishesForHeadchefResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
