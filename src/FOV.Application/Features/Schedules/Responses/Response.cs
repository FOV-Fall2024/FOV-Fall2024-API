using FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;

namespace FOV.Application.Features.Schedules.Responses;
public sealed record GetDailyScheduleResponse(Guid Id, EmployeeDto Employee, ShiftDto Shift, DateTime CreatedDate);
public record GetEmployeeScheduleResponse(Guid Id, ShiftDto Shift, DateOnly? Date, DateTime CreatedDate); // EmployeeDto Employee,
public record ShiftDto(Guid ShiftId, string ShiftName);
public record EmployeeDto(Guid EmployeeId, string EmployeeCode, string EmployeeName, Guid WaiterScheduleId);
public record UnassignedEmployeeDto(Guid EmployeeId, string EmployeeCode, string EmployeeName);

