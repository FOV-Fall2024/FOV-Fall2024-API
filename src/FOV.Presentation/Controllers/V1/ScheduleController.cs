using FOV.Application.Features.Schedules.Commands.Create;
using FOV.Application.Features.Schedules.Commands.Delete;
using FOV.Application.Features.Schedules.Queries.GetDailySchedules;
using FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class ScheduleController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [HttpPost("register")]
    public async Task<IActionResult> RegisterSchedule(RegisterScheduleCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpDelete("unregister")]
    public async Task<IActionResult> UnregisterSchedule(UnregisterScheduleCommand command)
    {
        var result = await _sender.Send(command);
        return result == true ? Ok(new
        {
            message = "Schedule deleted successfully"
        }) : BadRequest();
    }
    [HttpGet]
    public async Task<IActionResult> GetSchedule([FromQuery] GetEmployeeScheduleRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
    [HttpGet("daily")]
    public async Task<IActionResult> GetDailySchedule([FromQuery] GetDailyScheduleCommand request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
}
