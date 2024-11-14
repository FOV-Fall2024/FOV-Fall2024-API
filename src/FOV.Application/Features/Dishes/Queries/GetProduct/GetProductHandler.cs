using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.Dishes.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Queries.GetProduct;
public sealed record GetProductCommand(PagingRequest? PagingRequest, string? ProductName, string? ProductDescription, bool? IsRefundDish) : IRequest<PagedResult<GetProductResponse>>;

public class GetProductHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetProductCommand, PagedResult<GetProductResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;

    public async Task<PagedResult<GetProductResponse>> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        // Get all products from repository
        var products = await _unitOfWorks.DishRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId, x => x.DishGeneral);
        // Create filter entity, instantiate DishGeneral and assign values
        var filterEntity = new Dish
        {
            DishGeneral = new DishGeneral
            {
                DishName = request.ProductName ?? string.Empty,
                DishDescription = request.ProductDescription ?? string.Empty,
               
            },
        };
        if (request.IsRefundDish.HasValue)
        {
            filterEntity.DishGeneral.IsRefund = request.IsRefundDish.Value;
        }

        // Apply filtering using the CustomFilterV1 function
        var filteredProducts = products.AsQueryable().CustomFilterV1(filterEntity);
        // Map filtered products to the GetProductResponse DTO
        var mappedProducts = filteredProducts.Select(x => new GetProductResponse(
            x.Id,
            x.DishGeneral.DishGeneralImages.First().Url,
            x.DishGeneral.DishName,
            x.DishGeneral.DishDescription,
            x.Created)).ToList();
        // Get pagination and sorting values
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        // Apply sorting and pagination
        var sortedResult = PaginationHelper<GetProductResponse>.Sorting(sortType, mappedProducts, sortField);
        var pagedResult = PaginationHelper<GetProductResponse>.Paging(sortedResult, page, pageSize);
        return pagedResult;
    }
}
