using Azure;
using FOV.Application.Features.Attendances.Commands.CheckAttendance;
using FOV.Application.Features.Attendances.Commands.CheckIn;
using FOV.Application.Features.Attendances.Commands.CheckOut;
using FOV.Application.Features.Attendances.Commands.GenerateCheckInQRCode;
using FOV.Application.Features.Attendances.Queries.GetDailyAttendances;
using FOV.Application.Features.Attendances.Queries.GetQRShiftOfRestaurants;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class AttendanceController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [HttpPost("generate-checkin-qr-code")]
    public async Task<IActionResult> GenerateCheckInQRCode(GenerateCheckInQRCodeCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CheckAttendance(CheckAttendanceCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(new { message = result });
    }
    [HttpGet("daily")]
    public async Task<IActionResult> GetDailyAttendance([FromQuery] GetDailyAttendanceCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpPost("checkin")]
    public async Task<IActionResult> CheckIn([FromQuery] Guid restaurantId, [FromQuery] Guid shiftId, [FromQuery] Guid userId, [FromQuery] DateOnly date, [FromQuery] double latitude, [FromQuery] double longitude)
    {
        var checkInCommand = new CheckInCommand(restaurantId, shiftId, userId, date, DateTime.Now, latitude, longitude);

        var attendanceId = await _sender.Send(checkInCommand);
        return Ok(new OK_Result<Guid>("Điểm danh thành công", attendanceId));
    }
    [HttpPost("checkout")]
    public async Task<IActionResult> CheckOut([FromQuery] Guid shiftId, [FromQuery] DateOnly date, [FromBody] CheckOutCommand command)
    {
        command.ShiftId = shiftId;
        command.Date = date;
        command.CheckOutTime = DateTime.Now;
        var attendanceId = await _sender.Send(command);
        return Ok(new OK_Result<Guid>("Check-out thành công", attendanceId));
    }
    [HttpGet("qr")]
    public async Task<IActionResult> GetQrToCheckIn([FromQuery] GetQRShiftOfRestaurantCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
}
