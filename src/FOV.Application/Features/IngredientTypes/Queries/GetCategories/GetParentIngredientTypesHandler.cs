using FOV.Application.Features.IngredientTypes.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Queries.GetParentCategories;

public sealed record GetCategoriesCommand(PagingRequest? PagingRequest, string? CategoryName) : IRequest<PagedResult<GetParentCategoriesResponse>>;


public class GetParentIngredientTypesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetCategoriesCommand, PagedResult<GetParentCategoriesResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetParentCategoriesResponse>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
    {
        var responses = await _unitOfWorks.CategoryRepository.GetAllAsync();

        var filterEntity = new Category
        {
            CategoryName = request.CategoryName ?? string.Empty,
            
        };

        // Apply custom filtering
        var filterCategory = responses.AsQueryable().CustomFilterV1(filterEntity);

        // Map to response DTO
        var mappedCategory = filterCategory.Select(x => new GetParentCategoriesResponse(x.Id, x.CategoryName)).ToList();

        // Get pagination and sorting values
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        // Sort the results
        var sortedResult = PaginationHelper<GetParentCategoriesResponse>.Sorting(sortType, mappedCategory, sortField);

        // Paginate the sorted results
        var result = PaginationHelper<GetParentCategoriesResponse>.Paging(sortedResult, page, pageSize);

        return result;
    }
}
