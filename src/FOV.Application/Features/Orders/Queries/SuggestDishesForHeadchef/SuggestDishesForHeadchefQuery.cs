using FOV.Domain.Entities.DishGeneralAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using System.Linq.Expressions;

namespace FOV.Application.Features.Orders.Queries.SuggestDishesForHeadchef;

public record SuggestDishesForHeadchefCommand(PagingRequest? PagingRequest, Guid RestaurantId) : IRequest<PagedResult<SuggestDishesForHeadchefResponse>>;
//them thang image, them quantity
public record SuggestDishesForHeadchefResponse(Guid? OrderId, Guid Id, int TableNumber, string? DishName, string? ComboName, string Image, int Quantity, string? Note, DateTime CreatedDate);
public class SuggestDishesForHeadchefQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<SuggestDishesForHeadchefCommand, PagedResult<SuggestDishesForHeadchefResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<PagedResult<SuggestDishesForHeadchefResponse>> Handle(SuggestDishesForHeadchefCommand request, CancellationToken cancellationToken)
    {
        Expression<Func<OrderDetail, bool>> filter = od =>
            (od.Dish != null || od.Combo != null) &&
            od.Status == OrderDetailsStatus.Cook &&
            !od.IsRefund &&
            od.Order != null &&
            od.Order.Table != null &&
            od.Order.Table.RestaurantId == request.RestaurantId &&
            od.Order.OrderStatus == OrderStatus.Cook;

        var includes = new Expression<Func<OrderDetail, object>>[]
        {
            od => od.Order.Table,
            od => od.Dish.DishGeneral.DishGeneralImages,
            od => od.Combo
        };

        var orderDishes = await _unitOfWorks.OrderDetailRepository.WhereAsync(filter, includes);

        var prioritizedDishes = orderDishes
            .OrderBy(d => d.Created)
            .Select(d => new SuggestDishesForHeadchefResponse(
                d.OrderId,
                d.Id,
                d.Order!.Table!.TableNumber,
                d.Dish?.DishGeneral?.DishName ?? null,
                d.Combo?.ComboName ?? null,
                d.Dish?.DishGeneral?.DishGeneralImages.FirstOrDefault()?.Url ?? d.Combo?.Thumbnail,
                d.Quantity,
                d.Note,
                d.Created))
            .ToList();

        if (!prioritizedDishes.Any())
        {
            return new PagedResult<SuggestDishesForHeadchefResponse>();
        }

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<SuggestDishesForHeadchefResponse>.Sorting(sortType, prioritizedDishes, sortField);
        var result = PaginationHelper<SuggestDishesForHeadchefResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
