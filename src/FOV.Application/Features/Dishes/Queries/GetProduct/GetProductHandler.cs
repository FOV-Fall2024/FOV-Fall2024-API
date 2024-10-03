using FOV.Application.Features.Dishes.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Queries.GetProduct;

public sealed record GetProductCommand(PagingRequest? PagingRequest, string? ProductName, string? ProductDescription, string? RestaurantId) : IRequest<PagedResult<GetProductResponse>>;

public class GetProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetProductCommand, PagedResult<GetProductResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<PagedResult<GetProductResponse>> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWorks.DishRepository.GetAllAsync();

        var filterEntity = new Dish
        {
            DishName = request.ProductName ?? string.Empty,
            DishDescription = request.ProductDescription ?? string.Empty,
            RestaurantId = Guid.TryParse(request.RestaurantId, out var restaurantGuid) ? restaurantGuid : Guid.Empty
        };

        // Apply filtering using a custom filter function
        var filteredProducts = products.AsQueryable().CustomFilterV1(filterEntity);
        var mappedProducts = filteredProducts.Select(x => new GetProductResponse(
            x.Id,
            x.RestaurantId,
            x.DishName,
            x.DishDescription)).ToList();

        // Get pagination and sorting values
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        // Apply sorting and pagination
        var sortedResult = PaginationHelper<GetProductResponse>.Sorting(sortType, mappedProducts, sortField);
        var pagedResult = PaginationHelper<GetProductResponse>.Paging(sortedResult, page, pageSize);

        return pagedResult;
    }
}
