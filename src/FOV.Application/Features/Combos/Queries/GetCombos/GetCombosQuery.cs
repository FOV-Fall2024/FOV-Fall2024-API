using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.Combos.Reponses;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Queries.GetCombos;
public sealed record GetCombosCommand(PagingRequest? PagingRequest, Guid? RestaurantId) : IRequest<PagedResult<GetCombosResponse>>;

public class GetCombosQuery(IUnitOfWorks unitOfWorks,IClaimService claimService) : IRequestHandler<GetCombosCommand, PagedResult<GetCombosResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<PagedResult<GetCombosResponse>> Handle(GetCombosCommand request, CancellationToken cancellationToken)
    {
        var combos = (await _unitOfWorks.ComboRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId))
                     .OrderByDescending(c => c.Created);

        var filteredCombos = combos
            .Where(c => request.RestaurantId == null || c.RestaurantId == request.RestaurantId)
            .AsQueryable();

        var mappedCombos = filteredCombos.Select(combo => new GetCombosResponse(
            combo.Id,
            combo.RestaurantId,
            combo.ComboName,
            combo.Price,
            combo.Created
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = PaginationHelper<GetCombosResponse>.Sorting(sortType, mappedCombos, sortField);
        var pagedResult = PaginationHelper<GetCombosResponse>.Paging(sortedResult, page, pageSize);

        return pagedResult;
    }
}
