using System.ComponentModel.DataAnnotations;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.Combos.Reponses;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Queries.GetCombos;
public sealed record GetCombosCommand(PagingRequest? PagingRequest, string? ComboName, Status? ComboStatus) : IRequest<PagedResult<GetCombosResponse>>
{
    [Required]
    public required Guid RestaurantId { get; set; }
}

public class GetCombosQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetCombosCommand, PagedResult<GetCombosResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<PagedResult<GetCombosResponse>> Handle(GetCombosCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        var combos = await _unitOfWorks.ComboRepository.WhereAsync(x => x.RestaurantId == request.RestaurantId);
        if (userRole != Role.Manager)
        {
            combos = combos.Where(x => x.Status == Status.Active).ToList();
        }

        var filteredCombo = combos.AsQueryable().CustomFilterV1(new Combo
        {
            ComboName = string.IsNullOrEmpty(request.ComboName) ? string.Empty : request.ComboName,
        });

        if (request.ComboStatus != null)
        {
            filteredCombo =  filteredCombo.Where(x => x.Status == request.ComboStatus.Value);
        }

        var mappedCombos = filteredCombo.Select(combo => new GetCombosResponse(
            combo.Id,
            combo.RestaurantId,
            combo.ComboName,
            combo.Price,
            combo.Thumbnail,
            combo.Created,
            combo.Status
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResult = PaginationHelper<GetCombosResponse>.Sorting(sortType, mappedCombos, sortField);
        var pagedResult = PaginationHelper<GetCombosResponse>.Paging(sortedResult, page, pageSize);

        return pagedResult;
    }
}
