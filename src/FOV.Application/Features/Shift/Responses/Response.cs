namespace FOV.Application.Features.Shift.Responses;
public record GetShiftResponse(Guid Id, string ShiftName, TimeSpan StartTime, TimeSpan EndTime, DateTime CreatedDate);

