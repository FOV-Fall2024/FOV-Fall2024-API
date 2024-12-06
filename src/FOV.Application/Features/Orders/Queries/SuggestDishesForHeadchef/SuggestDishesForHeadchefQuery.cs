using FOV.Domain.Entities.DishGeneralAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.SuggestDishesForHeadchef;
public record SuggestDishesForHeadchefCommand(PagingRequest? PagingRequest, Guid RestaurantId) : IRequest<PagedResult<SuggestDishesForHeadchefResponse>>;
public record SuggestDishesForHeadchefResponse(Guid? OrderId, Guid Id, int TableNumber, string? DishName, string? ComboName, string? Note, DateTime CreatedDate);
public class SuggestDishesForHeadchefQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<SuggestDishesForHeadchefCommand, PagedResult<SuggestDishesForHeadchefResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<SuggestDishesForHeadchefResponse>> Handle(SuggestDishesForHeadchefCommand request, CancellationToken cancellationToken)
    {
        var orderDishes = await _unitOfWorks.OrderRepository.GetOrderDishesAndCombo(request.RestaurantId);

        var prioritizedDishes = orderDishes
            .OrderBy(d => d.Created)
            .Select(d => new SuggestDishesForHeadchefResponse(
                d.OrderId,
                d.Id,
                d.Order.Table.TableNumber,
                d.Dish?.DishGeneral?.DishName,
                d.Combo?.ComboName,
                d.Note,
                d.Created))
            .ToList();

        if (prioritizedDishes == null)
        {
            return new PagedResult<SuggestDishesForHeadchefResponse>();
        }

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResults = PaginationHelper<SuggestDishesForHeadchefResponse>.Sorting(sortType, prioritizedDishes, sortField);
        var result = PaginationHelper<SuggestDishesForHeadchefResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
