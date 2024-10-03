using FOV.Domain.Common;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Queries;

public record GetTableCommand(PagingRequest? PagingRequest, Guid? Id, int? TableNumber, TableStatus? TableStatus, Guid? RestaurantId, SortOrder? Sort) : IRequest<PagedResult<GetTableResponse>>;

public record GetTableResponse(Guid Id, int TableNumber, string TableStatus, Guid RestaurantId);

public class GetTableQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetTableCommand, PagedResult<GetTableResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<PagedResult<GetTableResponse>> Handle(GetTableCommand command, CancellationToken cancellationToken)
    {
        var tables = (await _unitOfWorks.TableRepository.GetAllAsync()).OrderByDescending(x => x.Created);
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
            table.RestaurantId
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(command.PagingRequest);

        var sortedResult = PaginationHelper<GetTableResponse>.Sorting(sortType, mappedTables, sortField);
        var result = PaginationHelper<GetTableResponse>.Paging(sortedResult, page, pageSize);
        return result;
    }
}
