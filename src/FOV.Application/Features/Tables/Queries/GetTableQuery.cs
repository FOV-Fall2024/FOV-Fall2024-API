using FOV.Domain.Common;
using FOV.Domain.Entities.TableAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Queries;

public record GetTableCommand(Guid? Id, string? TableNumber, string? TableCode, string? TableStatus, string? TableState, string? TableType, string? TableDescription, string? TableImage, Guid? RestaurantId, SortOrder? Sort) : IRequest<List<GetTableResponse>>;

public record GetTableResponse(Guid Id, string TableNumber, string TableCode, string TableStatus, string TableState, string TableType, string TableDescription, string TableImage, Guid RestaurantId);

public class GetTableQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetTableCommand, List<GetTableResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<GetTableResponse>> Handle(GetTableCommand command, CancellationToken cancellationToken)
    {
        var tables = await _unitOfWorks.TableRepository.GetAllAsync();
        var filterEntity = new Table
        {
            Id = command.Id ?? Guid.Empty,
            TableNumber = string.IsNullOrEmpty(command.TableNumber) ? null : command.TableNumber,
            TableCode = string.IsNullOrEmpty(command.TableCode) ? null : command.TableCode,
            TableStatus = string.IsNullOrEmpty(command.TableStatus) ? null : command.TableStatus,
            TableState = string.IsNullOrEmpty(command.TableState) ? null : command.TableState,
            TableType = string.IsNullOrEmpty(command.TableType) ? null : command.TableType,
            TableDescription = string.IsNullOrEmpty(command.TableDescription) ? null : command.TableDescription,
            RestaurantId = command.RestaurantId ?? Guid.Empty
        };

        var filteredTables = tables.AsQueryable().CustomFilterV1(filterEntity);
        return [.. filteredTables.Select(t => new GetTableResponse(
                t.Id,
                t.TableNumber ?? string.Empty,
                t.TableCode ?? string.Empty,
                t.TableStatus ?? string.Empty,
                t.TableState ?? string.Empty,
                t.TableType ?? string.Empty,
                t.TableDescription ?? string.Empty,
                t.TableImage ?? string.Empty,
                t.RestaurantId))];
    }
}
