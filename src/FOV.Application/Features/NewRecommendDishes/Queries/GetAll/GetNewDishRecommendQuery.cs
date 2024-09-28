using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.NewDishRecommendAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.NewRecommendDishes.Queries.GetAll;


public sealed record GetNewProductRecommendCommand(PagingRequest? PagingRequest) : IRequest<PagedResult<GetNewProductRecommendResponse>>;
//public sealed record NewProductRecommmend(Guid Id, Guid ProductGeneralId, Guid RestaurantId, string Status);
public sealed record GetNewProductRecommendResponse(Guid Id, string ProductName, string Status);
public sealed class GetNewDishRecommendQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetNewProductRecommendCommand, PagedResult<GetNewProductRecommendResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<PagedResult<GetNewProductRecommendResponse>> Handle(GetNewProductRecommendCommand request, CancellationToken cancellationToken)
    {
        List<NewDishRecommend> response = new List<NewDishRecommend>();

        if (_claimService.UserRole == Role.Administrator) response = await _unitOfWorks.NewProductRecommendRepository.GetAllAsync(x => x.DishGeneral);
        if (_claimService.UserRole == Role.Manager) response = await _unitOfWorks.NewProductRecommendRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId, x => x.DishGeneral);
        var result = response.Select(x => new GetNewProductRecommendResponse(x.Id, x.DishGeneral.DishName, x.Status.ToString()));

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        // Sort and paginate the results
        var sortedResults = PaginationHelper<GetNewProductRecommendResponse>.Sorting(sortType, result, sortField);
        var resulted = PaginationHelper<GetNewProductRecommendResponse>.Paging(sortedResults, page, pageSize);
        return resulted;
    }
}
