using FOV.Application.Features.Attendances.Commands.CheckAttendance;
using FOV.Application.Features.Attendances.Commands.CheckIn;
using FOV.Application.Features.Attendances.Commands.GenerateCheckInQRCode;
using FOV.Application.Features.Attendances.Queries.GetDailyAttendances;
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
    public async Task<IActionResult> CheckIn([FromQuery] CheckInCommand command)
    {
        var attendanceId = await _sender.Send(command);
        return Ok(new { attendanceId });
    }
}
