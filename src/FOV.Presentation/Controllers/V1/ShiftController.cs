using FOV.Application.Features.Shift.Commands.Active;
using FOV.Application.Features.Shift.Commands.Create;
using FOV.Application.Features.Shift.Commands.Inactive;
using FOV.Application.Features.Shift.Commands.Update;
using FOV.Application.Features.Shift.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class ShiftController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShiftCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateShiftCommand command)
    {
        var updateCommand = new UpdateShiftCommand(id, command.ShiftName, command.StartTime, command.EndTime);
        var response = await _sender.Send(updateCommand);
        return Ok(response);
    }
    [HttpPost("{id:guid}/active")]
    public async Task<IActionResult> Active(Guid id)
    {
        var response = await _sender.Send(new ActiveShiftCommand(id));
        return Ok(response);
    }
    [HttpPost("{id:guid}/inactive")]
    public async Task<IActionResult> Inactive(Guid id)
    {
        var response = await _sender.Send(new InactiveShiftCommand(id));
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetShiftRequest command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
