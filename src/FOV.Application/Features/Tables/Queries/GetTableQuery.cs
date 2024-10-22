using System.ComponentModel.DataAnnotations;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Common;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Queries;

public record GetTableCommand(PagingRequest? PagingRequest, Guid? Id, int? TableNumber, TableStatus? TableStatus, Guid? RestaurantId, SortOrder? Sort, bool? IsLogin) : IRequest<PagedResult<GetTableResponse>>;

public record GetTableResponse(Guid Id, int TableNumber, string TableStatus, Guid RestaurantId, DateTime CreatedDate, bool IsLogin);

public class GetTableQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetTableCommand, PagedResult<GetTableResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;

    public async Task<PagedResult<GetTableResponse>> Handle(GetTableCommand command, CancellationToken cancellationToken)
    {
        var tables = (await _unitOfWorks.TableRepository.GetAllAsync()).OrderByDescending(x => x.Created);

        if (_claimService.UserRole != Role.Manager)
        {
            tables = tables.Where(t => !t.IsLogin).OrderByDescending(x => x.Created);
        }
        else if (command.IsLogin.HasValue)
        {
            tables = tables.Where(t => t.IsLogin == command.IsLogin.Value).OrderByDescending(x => x.Created);
        }

        if (command.TableNumber.HasValue && command.TableNumber.Value > 0)
        {
            tables = tables.Where(t => t.TableNumber == command.TableNumber.Value).OrderByDescending(x => x.Created);
        }

        var filterEntity = new Table
        {
            Id = command.Id.HasValue ? command.Id.Value : Guid.Empty,
            TableNumber = command.TableNumber ?? 0,
            TableStatus = command.TableStatus ?? TableStatus.Unknown,
            RestaurantId = command.RestaurantId.HasValue ? command.RestaurantId.Value : Guid.Empty
        };

        var filteredTables = tables.AsQueryable().CustomFilterV1(filterEntity);

        var mappedTables = filteredTables.Select(table => new GetTableResponse(
            table.Id,
            table.TableNumber,
            table.TableStatus.ToString(),
            table.RestaurantId,
            table.Created,
            table.IsLogin
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(command.PagingRequest);

        var sortedResult = PaginationHelper<GetTableResponse>.Sorting(sortType, mappedTables, sortField);
        var result = PaginationHelper<GetTableResponse>.Paging(sortedResult, page, pageSize);
        return result;
    }
}
