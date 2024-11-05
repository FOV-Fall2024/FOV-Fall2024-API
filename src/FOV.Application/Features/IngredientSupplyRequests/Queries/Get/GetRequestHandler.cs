using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.IngredientSupplyRequests.Responses;
using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using FOV.Domain.Entities.IngredientSupplyRequestAggregator.Enum;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientSupplyRequests.Queries.Get;
public sealed record GetRequestCommand(PagingRequest? PagingRequest, SupplyRequestType Type, string? RequestCode) : IRequest<PagedResult<SupplyRequestRespond>>;

public class GetRequestHandler : IRequestHandler<GetRequestCommand, PagedResult<SupplyRequestRespond>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;

    public GetRequestHandler(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;
    }

    public async Task<PagedResult<SupplyRequestRespond>> Handle(GetRequestCommand request, CancellationToken cancellationToken)
    {
        // Fetch all supply requests for the restaurant
        var supplies = await _unitOfWorks.IngredientSupplyRequestRepository
            .WhereAsync(x => x.RestaurantId == _claimService.RestaurantId, x => x.IngredientSupplyRequestDetails);

        // Filter based on the request parameters (Type and RequestCode)
        var filteredSupplies = supplies.AsQueryable()
            .Where(x => (request.Type == null || x.Type == request.Type) &&
                        (string.IsNullOrEmpty(request.RequestCode) || x.RequestCode.Contains(request.RequestCode, StringComparison.OrdinalIgnoreCase)));

        // Map the filtered supplies to response DTOs
        var mappedSupplies = filteredSupplies.Select(x => new SupplyRequestRespond(
            x.Id,
            x.RequestCode,
            x.Created,
            x.IngredientSupplyRequestDetails.Count
        )).ToList();

        // Get pagination and sorting values
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        // Sort and paginate the results
        var sortedResults = PaginationHelper<SupplyRequestRespond>.Sorting(sortType, mappedSupplies, sortField);
        var result = PaginationHelper<SupplyRequestRespond>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
