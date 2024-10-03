using FOV.Application.Features.Combos.Reponses;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Queries.GetCombos;
public sealed record GetCombosCommand(PagingRequest? PagingRequest, Guid? RestaurantId) : IRequest<PagedResult<GetCombosResponse>>;

public class GetCombosQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetCombosCommand, PagedResult<GetCombosResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetCombosResponse>> Handle(GetCombosCommand request, CancellationToken cancellationToken)
    {
        var combos = (await _unitOfWorks.ComboRepository.GetAllAsync())
                     .OrderByDescending(c => c.Created);

        var filteredCombos = combos
            .Where(c => request.RestaurantId == null || c.RestaurantId == request.RestaurantId)
            .AsQueryable();

        var mappedCombos = filteredCombos.Select(combo => new GetCombosResponse(
            combo.Id,
            combo.RestaurantId,
            combo.ComboName,
            combo.Quantity,
            combo.Price,
            combo.ExpiredDate
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = PaginationHelper<GetCombosResponse>.Sorting(sortType, mappedCombos, sortField);
        var pagedResult = PaginationHelper<GetCombosResponse>.Paging(sortedResult, page, pageSize);

        return pagedResult;
    }
}
