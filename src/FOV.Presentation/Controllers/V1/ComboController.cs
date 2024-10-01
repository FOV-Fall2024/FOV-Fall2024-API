using FOV.Application.Features.Combos.Commands.Active;
using FOV.Application.Features.Combos.Commands.Create;
using FOV.Application.Features.Combos.Commands.Inactive;
using FOV.Application.Features.Combos.Queries.GetCombos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;
[ApiController]
[Route("api/v1/[controller]")]
public class ComboController : DefaultController
{
    private readonly IMediator _mediator;
    public ComboController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetCombo([FromQuery] GetCombosCommand query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> AddCombo([FromBody] CreateComboCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
    //[HttpPatch("{id:guid}")]
    //public async Task<IActionResult> UpdateCombo(Guid id, [FromBody] UpdateComboCommand command)
    //{
    //    command = command with { Id = id };
    //    var response = await _mediator.Send(command);
    //    return Ok(response);
    //}
    [HttpPatch("{id:guid}/active")]
    public async Task<IActionResult> ActiveCombo(Guid id)
    {
        var response = await _mediator.Send(new ActvieComboCommand(id));
        return Ok(response);
    }
    [HttpPatch("{id:guid}/inactive")]
    public async Task<IActionResult> InactiveCombo(Guid id)
    {
        var response = await _mediator.Send(new InactiveComboCommand(id));
        return Ok(response);
    }
}
