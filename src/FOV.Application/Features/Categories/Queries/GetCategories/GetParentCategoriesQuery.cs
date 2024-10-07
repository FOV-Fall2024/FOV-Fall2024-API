using FOV.Application.Features.Categories.Reponses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Queries.GetParentCategories;

public sealed record GetCategoriesCommand(PagingRequest? PagingRequest, string? CategoryName) : IRequest<PagedResult<GetParentCategoriesResponse>>;
public class GetParentCategoriesQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetCategoriesCommand, PagedResult<GetParentCategoriesResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetParentCategoriesResponse>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
    {
        var responses = await _unitOfWorks.CategoryRepository.GetAllAsync();
        var filterEntity = new Category
        {
            CategoryName = request.CategoryName ?? string.Empty,

        };
        var filterCategory = responses.AsQueryable().CustomFilterV1(filterEntity);
        var mappedCategory = filterCategory.Select(x => new GetParentCategoriesResponse(x.Id, x.CategoryName,x.Created)).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = PaginationHelper<GetParentCategoriesResponse>.Sorting(sortType, mappedCategory, sortField);
        var result = PaginationHelper<GetParentCategoriesResponse>.Paging(sortedResult, page, pageSize);
        return result;
    }
}
