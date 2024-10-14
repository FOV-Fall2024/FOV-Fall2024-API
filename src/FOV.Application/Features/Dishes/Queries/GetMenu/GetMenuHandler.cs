using FOV.Application.Features.Dishes.Responses;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Queries.GetMenu
{
    public sealed record GetMenuCommand(string? ProductName, string? ProductDescription, string? RestaurantId, PagingRequest? PagingRequest) : IRequest<PagedResult<GetMenuResponse>>;

    public class GetMenuHandler : IRequestHandler<GetMenuCommand, PagedResult<GetMenuResponse>>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public GetMenuHandler(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<PagedResult<GetMenuResponse>> Handle(GetMenuCommand request, CancellationToken cancellationToken)
        {
            // Fetch all dishes and combos from the repository
            var products = await _unitOfWorks.DishRepository.GetAllAsync();
            var combos = await _unitOfWorks.ComboRepository.GetAllAsync(x => x.DishCombos);

            // Filter products based on the request parameters
            var filteredProducts = products
                .Where(x =>
                    (string.IsNullOrEmpty(request.ProductName) || x.DishGeneral.DishName.Contains(request.ProductName, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(request.ProductDescription) || x.DishGeneral.DishDescription.Contains(request.ProductDescription, StringComparison.OrdinalIgnoreCase)) &&
                    (!Guid.TryParse(request.RestaurantId, out var restaurantGuid) || x.RestaurantId == restaurantGuid) &&
                    x.Status == Status.Active)
                .Select(x => new GetMenuResponse(x.Id, x.DishGeneral.DishName, x.DishGeneral.DishDescription, x.Created, "Product"))
                .ToList();

            // Filter combos based on the request parameters
            var filteredCombos = combos
                .Where(x =>
                    (string.IsNullOrEmpty(request.ProductName) || x.ComboName.Contains(request.ProductName, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(request.ProductDescription) || x.ComboDescription.Contains(request.ProductDescription, StringComparison.OrdinalIgnoreCase)) &&
                    (!Guid.TryParse(request.RestaurantId, out var restaurantGuid) || x.RestaurantId == restaurantGuid) &&
                    x.Status == Status.Active)
                .Select(x => new GetMenuResponse(x.Id, x.ComboName, x.ComboDescription, x.Created, "Combo"))
                .ToList();

            // Merge filtered products and combos into a single list
            var combinedResults = filteredProducts.Concat(filteredCombos).ToList();

            // Get pagination values
            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            // Sort and paginate the combined results
            var sortedResults = PaginationHelper<GetMenuResponse>.Sorting(sortType, combinedResults, sortField);
            var pagedResult = PaginationHelper<GetMenuResponse>.Paging(sortedResults, page, pageSize);

            // Return the paged result
            return pagedResult;
        }
    }
}
