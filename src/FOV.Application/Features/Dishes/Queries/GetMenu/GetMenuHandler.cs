using FOV.Application.Features.Dishes.Responses;
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
            // Fetch all dishes from the repository
            var products = await _unitOfWorks.DishRepository.GetAllAsync();

            // Filter products based on the request parameters
            var filteredProducts = products
                .Where(x =>
                    (string.IsNullOrEmpty(request.ProductName) || x.DishName.Contains(request.ProductName, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(request.ProductDescription) || x.DishDescription.Contains(request.ProductDescription, StringComparison.OrdinalIgnoreCase)) &&
                    (!Guid.TryParse(request.RestaurantId, out var restaurantGuid) || x.RestaurantId == restaurantGuid) &&
                    !x.IsDeleted)
                .Select(x => new GetMenuResponse(x.Id, x.DishName, x.DishDescription, x.Created))
                .ToList();

            // Get pagination values
            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            // Sort and paginate the results
            var sortedResults = PaginationHelper<GetMenuResponse>.Sorting(sortType, filteredProducts, sortField);
            var pagedResult = PaginationHelper<GetMenuResponse>.Paging(sortedResults, page, pageSize);

            // Return the paged result
            return pagedResult;
        }
    }
}
