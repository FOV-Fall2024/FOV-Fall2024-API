using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.Ingredients.Responses;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Ingredients.Queries.GetIngredients;

public sealed record GetIngredientsCommand(string? IngredientName, PagingRequest? PagingRequest) : IRequest<PagedResult<GetIngredientsResponse>>;
public class GetIngredientsHandler : IRequestHandler<GetIngredientsCommand, PagedResult<GetIngredientsResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;

    public GetIngredientsHandler(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;

    }

    public async Task<PagedResult<GetIngredientsResponse>> Handle(GetIngredientsCommand request, CancellationToken cancellationToken)
    {
        // Fetch all ingredients from the repository
        var allIngredients = await _unitOfWorks.IngredientRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId, x => x.IngredientUnits, x => x.IngredientType, x => x.IngredientUnits);

        // Filter ingredients based on the request parameters
        var filteredIngredients = allIngredients.AsQueryable()
            .Where(x => string.IsNullOrEmpty(request.IngredientName) ||
                        x.IngredientGeneral.IngredientName.Contains(request.IngredientName, StringComparison.OrdinalIgnoreCase));

        // Select and map to response DTO
        var mappedIngredients = filteredIngredients.Select(x => new GetIngredientsResponse(
            x.Id,
            x.RestaurantId ?? Guid.Empty,
            x.IngredientGeneral.IngredientName ?? string.Empty,
            x.IngredientType.IngredientName,
            x.IngredientGeneral.IngredientDescription,
            x.IngredientAmount,
            x.Created,
            x.IngredientUnits.Select(y => new GetIngredientUnitResponse(y.Id, y.IngredientUnitParentId, y.IngredientUnitParentId == null
            ? "Naruto"
            : x.IngredientUnits
                .Where(p => p.Id == y.IngredientUnitParentId)
                .Select(p => p.UnitName)
                .FirstOrDefault() ?? "Naruto", y.UnitName, y.ConversionFactor, y.Created)).OrderByDescending(x => x.CreatedDate).ToList()
            )).ToList();

        // Get pagination and sorting values
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        // Sort and paginate the results
        var sortedResults = PaginationHelper<GetIngredientsResponse>.Sorting(sortType, mappedIngredients, sortField);
        var result = PaginationHelper<GetIngredientsResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
