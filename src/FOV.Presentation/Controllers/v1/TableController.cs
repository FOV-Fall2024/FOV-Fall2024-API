using FOV.Application.Features.Tables.Commands.Active;
using FOV.Application.Features.Tables.Commands.Create;
using FOV.Application.Features.Tables.Commands.Inactive;
using FOV.Application.Features.Tables.Commands.Update;
using FOV.Presentation.Controllers.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.v1;
public class TableController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    [HttpPost("{restaurantId:guid}")]
    public async Task<IActionResult> Add(Guid restaurantId, [FromBody] CreateTableCommand request)
    {
        request.RestaurantId = restaurantId;
        var response = await _sender.Send(request);
        return Ok(response);
    }
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTableCommand command)
    {
        command.Id = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpPost("{id:guid}/active")]
    public async Task<IActionResult> Active(Guid id)
    {
        var response = await _sender.Send(new ActiveTableCommand(id));
        return Ok(response);
    }
    [HttpPost("{id:guid}/inactive")]
    public async Task<IActionResult> Inactive(Guid id)
    {
        var response = await _sender.Send(new InactiveTableCommand(id));
        return Ok(response);
    }
}
