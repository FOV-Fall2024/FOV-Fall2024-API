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
        var responses = await _unitOfWorks.IngredientTypeRepository.GetAllAsync();

        var filterEntity = new Domain.Entities.IngredientAggregator.IngredientType
        {
            IngredientName = request.IngredientTypeName ?? string.Empty,
        };

        var filteredResults = responses.AsQueryable().CustomFilterV1(filterEntity);

        var mappedCategories = filteredResults
            .Select(x => new GetChildrenIngredientType(x.Id, x.IngredientName, x.IngredientDescription, x.Created))
            .ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = mappedCategories
            .ToList(); 

        var pagedResult = PaginationHelper<GetChildrenIngredientType>.Paging(sortedResult, page, pageSize);

        // Return the paginated result
        return pagedResult;
    }
}
