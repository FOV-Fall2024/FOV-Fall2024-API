using FOV.Application.Features.IngredientTypes.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Queries.GetParentCategories;

public sealed record GetIngredientTypeCommand(PagingRequest? PagingRequest, Guid? Id, string? IngredientTypeName) : IRequest<PagedResult<GetChildrenIngredientType>>;
//public sealed record GetIngredientTypeCommand(PagingRequest? PagingRequest, string? IngredientTypeName) : IRequest<PagedResult<GetChildrenIngredientType>>;

public class GetParentIngredientTypesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetIngredientTypeCommand, PagedResult<GetChildrenIngredientType>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetChildrenIngredientType>> Handle(GetIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        // Fetch all ingredient types from the repository
        var responses = await _unitOfWorks.IngredientTypeRepository.GetAllAsync();

        // Create a filter entity based on the command
        var filterEntity = new Domain.Entities.IngredientAggregator.IngredientType
        {
            IngredientName = request.IngredientTypeName ?? string.Empty,
        };

        // Apply custom filtering
        var filteredResults = responses.AsQueryable().CustomFilterV1(filterEntity);

        // Map filtered results to the DTO (GetChildrenIngredientType)
        var mappedCategories = filteredResults
            .Select(x => new GetChildrenIngredientType(x.Id, x.IngredientName, x.IngredientDescription, x.Created))
            .ToList();

        // Extract pagination and sorting details
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        // Sort by CreatedDate in descending order
        // Ensure that CreatedDate is ordered as DateTimeOffset
        var sortedResult = mappedCategories
            .OrderByDescending(x => x.CreatedDate) // Here x.CreatedDate should be DateTimeOffset
            .ToList(); // Ensure sorting is applied before pagination

        // Apply pagination to the sorted results
        var pagedResult = PaginationHelper<GetChildrenIngredientType>.Paging(sortedResult, page, pageSize);

        // Return the paginated result
        return pagedResult;
    }
}
