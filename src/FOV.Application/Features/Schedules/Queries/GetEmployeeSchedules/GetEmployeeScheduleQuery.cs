using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;
public record GetEmployeeScheduleRequest(Guid? ScheduleId, string? EmployeeId, Guid? ShiftId, DateOnly? Date) : IRequest<List<GetEmployeeScheduleResponse>>;
public record GetEmployeeScheduleResponse(Guid ScheduleId, string EmployeeId, ShiftDto shift, DateOnly Date);
public record ShiftDto(Guid ShiftId, string ShiftName);
public class GetEmployeeScheduleQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetEmployeeScheduleRequest, List<GetEmployeeScheduleResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetEmployeeScheduleResponse>> Handle(GetEmployeeScheduleRequest request, CancellationToken cancellationToken)
    {
        var schedule = await _unitOfWorks.WaiterScheduleRepository.GetAllAsync(s => s.Shift);
        var filterEntities = new WaiterSchedule
        {
            Id = request.ScheduleId.HasValue ? request.ScheduleId.Value : Guid.Empty,
            EmployeeId = string.IsNullOrEmpty(request.EmployeeId) ? string.Empty : request.EmployeeId,
            ShiftId = request.ShiftId.HasValue ? request.ShiftId.Value : Guid.Empty,
            DateTime = request.Date.HasValue ? request.Date.Value : new DateOnly()
        };
        var filterTable = schedule.AsQueryable().CustomFilterV1(filterEntities);
        return filterTable.Select(schedule => new GetEmployeeScheduleResponse(
                schedule.Id,
                schedule.EmployeeId ?? string.Empty,
                new ShiftDto(schedule.ShiftId, schedule.Shift.ShiftName),
                schedule.DateTime
            )).ToList();
    }
}
