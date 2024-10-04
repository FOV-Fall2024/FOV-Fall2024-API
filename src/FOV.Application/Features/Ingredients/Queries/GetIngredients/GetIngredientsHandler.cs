using FOV.Application.Features.Ingredients.Responses;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Ingredients.Queries.GetIngredients;

public sealed record GetIngredientsCommand(string? IngredientName, PagingRequest? PagingRequest) : IRequest<PagedResult<GetIngredientsResponse>>;
public class GetIngredientsHandler : IRequestHandler<GetIngredientsCommand, PagedResult<GetIngredientsResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public GetIngredientsHandler(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<PagedResult<GetIngredientsResponse>> Handle(GetIngredientsCommand request, CancellationToken cancellationToken)
    {
        // Fetch all ingredients from the repository
        var allIngredients = await _unitOfWorks.IngredientRepository.GetAllAsync();

        // Filter ingredients based on the request parameters
        var filteredIngredients = allIngredients.AsQueryable()
            .Where(x => string.IsNullOrEmpty(request.IngredientName) ||
                        x.IngredientName.Contains(request.IngredientName, StringComparison.OrdinalIgnoreCase));

        // Select and map to response DTO
        var mappedIngredients = filteredIngredients.Select(x => new GetIngredientsResponse(
            x.Id,
            x.RestaurantId ?? Guid.Empty,
            x.IngredientName ?? string.Empty,
            x.IngredientAmount)).ToList();

        // Get pagination and sorting values
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        // Sort and paginate the results
        var sortedResults = PaginationHelper<GetIngredientsResponse>.Sorting(sortType, mappedIngredients, sortField);
        var result = PaginationHelper<GetIngredientsResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
