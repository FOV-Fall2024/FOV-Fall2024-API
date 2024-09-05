using FOV.Domain.Common;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Queries;

public record GetTableCommand(Guid? Id, int? TableNumber, string? TableCode, Status? TableStatus, Guid? RestaurantId, SortOrder? Sort) : IRequest<List<GetTableResponse>>;

public record GetTableResponse(Guid Id, int TableNumber, string TableCode, Status TableStatus, Guid RestaurantId);

public class GetTableQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetTableCommand, List<GetTableResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<GetTableResponse>> Handle(GetTableCommand command, CancellationToken cancellationToken)
    {
        var tables = await _unitOfWorks.TableRepository.GetAllAsync();
        var filterEntity = new Table
        {
            Id = command.Id ?? Guid.Empty,
            TableNumber = command.TableNumber ?? 0,
            TableCode = command.TableCode ?? string.Empty,
            TableStatus = command.TableStatus ?? Status.Active,
            RestaurantId = command.RestaurantId ?? Guid.Empty
        };

        var filteredTables = tables.AsQueryable().CustomFilterV1(filterEntity);
        return [.. filteredTables.Select(t => new GetTableResponse(
                t.Id,
                t.TableNumber,
                t.TableCode,
                t.TableStatus,
                t.RestaurantId))];
    }
}
