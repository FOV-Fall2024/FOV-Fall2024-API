using FOV.Application.Features.IngredientTypes.Commands.Active;
using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Application.Features.IngredientTypes.Commands.Inactive;
using FOV.Application.Features.IngredientTypes.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;



public class IngredientTypeController(ISender sender) : DefaultController
{

    //[ ] Get
    //[ ] Get Detail
    private readonly ISender _sender = sender;

    //[x] Create 
    [HttpPost("parent")]
    public async Task<IActionResult> Add(CreateIngredientTypeCommand request)
    {
        var response = await _sender.Send(request);
        return Ok(response);
    }

    //[HttpPost("child")]
    //public async Task<IActionResult> AddChild()
    //{

    //}


    //[x] Update 
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateIngredientTypeCommand command)
    {
        command.Id = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }

    //[x] Active
    [HttpPost("{id:guid}/active")]
    public async Task<IActionResult> Actvie(Guid id)
    {
        var response = await _sender.Send(new ActiveIngredientTypeCommand(id));
        return Ok(response);
    }

    //[x] Inactive
    [HttpPost("{id:guid}/inactive")]
    public async Task<IActionResult> InActive(Guid id)
    {
        var response = await _sender.Send(new InactiveIngredientTypeCommand(id));
        return Ok(response);
    }




    //[HttpGet]
    //public async Task<IActionResult> Get();



}
