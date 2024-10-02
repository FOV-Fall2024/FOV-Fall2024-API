using FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;

namespace FOV.Application.Features.Schedules.Responses;
public sealed record GetDailyScheduleResponse(Guid Id, EmployeeDto Employee, ShiftDto Shift);
public record GetEmployeeScheduleResponse(Guid Id, EmployeeDto Employee, ShiftDto Shift, DateOnly Date);
public record ShiftDto(Guid ShiftId, string ShiftName);
public record EmployeeDto(Guid EmployeeId, string EmployeeCode);
