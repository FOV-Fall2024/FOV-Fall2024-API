using FOV.Application.Features.Ingredients.Commands.AddMultipleQuantity;
using FOV.Application.Features.Ingredients.Queries.GetIngredients;
using FOV.Application.Features.ProductGenerals.Queries.GetProductGeneralDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class IngredientController(IMediator mediator) : DefaultController
{
    private readonly IMediator _mediator = mediator;


    [HttpPost("multiple")]
    public async Task<IActionResult> AddMultiple(AddMultipleQuantityCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }



    [HttpPost("single")]
    public async Task<IActionResult> AddSingle(AddMultipleQuantityCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetIngredienetsCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }


}
