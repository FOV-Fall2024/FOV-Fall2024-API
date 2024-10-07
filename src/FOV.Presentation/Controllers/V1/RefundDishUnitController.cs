using FOV.Application.Features.IngredientUnits.Commands.CreateNewIngredientUnit;
using FOV.Application.Features.RefundDishUnits.Commands.Remove;
using FOV.Application.Features.RefundDishUnits.Commands.Update;
using FOV.Application.Features.RefundDishUnits.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class RefundDishUnitController : DefaultController
{
    private readonly ISender _sender;
    public RefundDishUnitController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> Add(CreateNewIngredientUnitCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var response = await _sender.Send(new RemoveNewRefundDishUnitCommand { Id = id });
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateRefundUnitCommand command)
    {
        command.Id = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpGet("dish/{id}")]
    public async Task<IActionResult> Add(Guid id, [FromQuery] GetRefundUnitCommand query)
    {
        query.DishId = id;
        var response = await _sender.Send(query);
        return Ok(response);
    }
}
