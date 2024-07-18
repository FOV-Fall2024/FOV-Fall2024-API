using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Application.Features.IngredientTypes.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.v1;

public class IngredientTypeController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    [HttpPost]
    public async Task<IActionResult> Add(CreateIngredientTypeCommand request)
    {
        var response = await _sender.Send(request);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateIngredientTypeCommand command)
    {
        command.Id = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }


    //[HttpGet]
    //public async Task<IActionResult> Get();



}
