using FOV.Application.Features.IngredientTypes.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Queries.GetParentCategories;

public sealed record GetIngredientTypeCommand(PagingRequest? PagingRequest, Guid? Id, string? IngredientTypeName,DateTimeOffset jkon ) : IRequest<PagedResult<GetChildrenIngredientType>>;
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

        // Map to response DTO
        var mappedCategory = filteredResults.Select(x => new GetChildrenIngredientType(x.Id, x.IngredientName,x.IngredientDescription,x.Created ?? DateTime.Now)).ToList();

        // Extract pagination and sorting details
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        // Sort the results
        var sortedResult = PaginationHelper<GetChildrenIngredientType>.Sorting(sortType, mappedCategory.OrderByDescending(x => x.CreatedDate), sortField);

        // Apply pagination to the sorted results
        var pagedResult = PaginationHelper<GetChildrenIngredientType>.Paging(sortedResult, page, pageSize);

        // Return the paginated result
        return pagedResult;
    }
}
