using FOV.Application.Features.Schedules.Commands.Create;
using FOV.Application.Features.Schedules.Commands.Delete;
using FOV.Application.Features.Schedules.Queries.GetDailySchedules;
using FOV.Application.Features.Schedules.Queries.GetEmployeeOfShiftOnSpecificDate;
using FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;
using FOV.Application.Features.Schedules.Queries.GetUnassignedEmployeesForShiftOnSpecificDate;
using FOV.Application.Features.Schedules.Queries.GetWeeklyShiftEmployeeCount;
using FOV.Domain.Entities.UserAggregator.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
            message = "Xóa lịch làm thành công"
        }) : BadRequest();
    }
    [SwaggerOperation(Summary = "Lấy lịch làm của 1 nhân viên trong tuần")]
    [HttpGet("employee")]
    public async Task<IActionResult> GetSchedule([FromQuery] GetEmployeeScheduleRequest request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
    [SwaggerOperation(Summary = "Lấy lịch làm của toàn bộ nhân viên trong 1 ngày")]
    [HttpGet("daily")]
    public async Task<IActionResult> GetDailySchedule([FromQuery] GetDailyScheduleCommand request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
    [Authorize(Roles = Role.Manager)]
    [HttpGet("shift-employees")]
    public async Task<IActionResult> GetEmployeeOfShiftOnSpecificDate([FromQuery] GetEmployeeOfShiftOnSpecificDateCommand request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
    [Authorize(Roles = Role.Manager)]
    [HttpGet("unassigned-employees")]
    public async Task<IActionResult> GetUnassignedEmployeesForShiftOnSpecificDate([FromQuery] GetUnassignedEmployeesForShiftOnSpecificDateCommand request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }
    [Authorize(Roles = Role.Manager)]
    [HttpGet("weekly-shift-count")]
    public async Task<IActionResult> GetWeeklyShiftCount([FromQuery] GetWeeklyShiftEmployeeCountCommand request)
    {
        var result = await _sender.Send(request);
        return Ok(result);
    }

}
