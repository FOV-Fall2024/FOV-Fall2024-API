using FluentResults;
using FOV.Application.Features.IngredientGenerals.Commands.Active;
using FOV.Application.Features.IngredientGenerals.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.v1;

public class IngredientGeneralController(ISender sender) : DefaultController
{
    //[ ] Create 
    //[ ] Update 
    //[ ] Inactive
    //[ ] Active
    //[ ] Get
    //[ ] Get Detail
    private readonly ISender _sender = sender;
    [HttpPost]
    public async Task<IActionResult> Create(CreateIngredientGeneralCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPost("{id :guid}/active")]
    public async Task<IActionResult> Active(Guid id)
    {
        var response = await _sender.Send(new ActiveIngredientGeneralCommand(id));
        return Ok(response);
    }
}
