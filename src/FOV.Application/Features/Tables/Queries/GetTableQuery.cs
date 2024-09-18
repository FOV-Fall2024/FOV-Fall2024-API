using FOV.Domain.Common;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Queries;

public record GetTableCommand(PagingRequest? PagingRequest, Guid? Id, int? TableNumber, string? TableCode, Status? TableStatus, Guid? RestaurantId, SortOrder? Sort) : IRequest<PagedResult<GetTableResponse>>;

public record GetTableResponse(Guid Id, int TableNumber, string TableCode, Status TableStatus, Guid RestaurantId);

public class GetTableQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetTableCommand, PagedResult<GetTableResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<PagedResult<GetTableResponse>> Handle(GetTableCommand command, CancellationToken cancellationToken)
    {
        var tables = (await _unitOfWorks.TableRepository.GetAllAsync()).OrderByDescending(t => t.Created);
        var filterEntity = new Table
        {
            Id = command.Id ?? Guid.Empty,
            TableNumber = command.TableNumber ?? 0,
            TableCode = command.TableCode ?? string.Empty,
            TableStatus = command.TableStatus ?? Status.Active,
            RestaurantId = command.RestaurantId ?? Guid.Empty
        };

        var filteredTables = tables.AsQueryable().CustomFilterV1(filterEntity);

        var mappedTables = filteredTables.Select(table => new GetTableResponse(
            table.Id,
            table.TableNumber,
            table.TableCode,
            table.TableStatus,
            table.RestaurantId
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(command.PagingRequest);

        var sortedResult = PaginationHelper<GetTableResponse>.Sorting(sortType, mappedTables, sortField);
        var result = PaginationHelper<GetTableResponse>.Paging(sortedResult, page, pageSize);
        return result;
    }
}
