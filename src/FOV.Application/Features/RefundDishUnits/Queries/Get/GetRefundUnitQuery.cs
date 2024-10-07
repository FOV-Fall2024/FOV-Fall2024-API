using System.Text.Json.Serialization;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.RefundDishUnits.Queries.Get;

public sealed record GetRefundUnitCommand(PagingRequest? PagingRequest, string UnitName) : IRequest<Infrastructure.Helpers.GetHelper.PagedResult<GetRefundUnitResponse>>
{
    [JsonIgnore]
    public Guid DishId { get; set; }
}

public sealed record GetRefundUnitResponse(Guid Id, string UnitName, decimal ConversionFactor);

public class GetRefundUnitQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetRefundUnitCommand, Infrastructure.Helpers.GetHelper.PagedResult<GetRefundUnitResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<PagedResult<GetRefundUnitResponse>> Handle(GetRefundUnitCommand request, CancellationToken cancellationToken)
    {
        // Retrieve all refund units
        var refundUnits = await _unitOfWorks.RefundDishUnitRepository.GetAllAsync(x => x.RefundDishInventory.DishId == request.DishId);

        // Apply filtering based on the request's UnitName
        var filteredUnits = refundUnits.AsQueryable().Where(unit =>
            string.IsNullOrEmpty(request.UnitName) || unit.UnitName.Contains(request.UnitName));

        // Map the result to the response DTO
        var mappedUnits = filteredUnits.Select(unit => new GetRefundUnitResponse(
            unit.Id,
            unit.UnitName ?? string.Empty,
            unit.ConversionFactor
        )).ToList();

        // Get pagination values
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        sortField = "UnitName";  // Default sorting by UnitName, adjust as needed

        // Apply sorting and paging
        var sortedResults = PaginationHelper<GetRefundUnitResponse>.Sorting(sortType, mappedUnits, sortField);
        var result = PaginationHelper<GetRefundUnitResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
