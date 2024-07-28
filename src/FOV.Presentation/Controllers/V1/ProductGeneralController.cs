using FOV.Application.Features.ProductGenerals.Commands.Active;
using FOV.Application.Features.ProductGenerals.Commands.Create;
using FOV.Application.Features.ProductGenerals.Commands.Inactive;
using FOV.Application.Features.ProductGenerals.Commands.Update;
using FOV.Application.Features.ProductGenerals.Commands.UpdateIngredientQuantity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;


public class ProductGeneralController(ISender sender) : DefaultController
{

    private readonly ISender _sender = sender;

    // [ ] Create 
    [HttpPost]
    public async Task<IActionResult> Add(CreateProductGeneralCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }

    // [ ] Update Ingredient quantity
    [HttpPatch("{productId}/ingredient/{ingredientId}")]
    public async Task<IActionResult> UpdateQuantity(Guid productId, Guid ingredientId, UpdateIngredientQuantityCommand command)
    {
        var response = await _sender.Send(new UpdateIngredientQuantityCommand { ProductId = productId, IngredientId = ingredientId, Quantity = command.Quantity });
        return Ok(response);
    }
    // [ ] Update

    [HttpPost("{productId}")]
    public async Task<IActionResult> Update(Guid productId, UpdateProductGeneralCommand command)
    {
        command.Id = productId;
        var response = await _sender.Send(command);
        return Ok(response);
    }

    // [ ] Active 

    [HttpPost("{id:guid}/active")]
    public async Task<IActionResult> Actvie(Guid id)
    {
        var response = await _sender.Send(new ActiveProductGeneralCommand(id));
        return Ok(response);
    }

    // [ ] Inactive
    [HttpPost("{id:guid}/inactive")]
    public async Task<IActionResult> Inactive(Guid id)
    {
        var response = await _sender.Send(new InactiveProductGeneralCommand(id));
        return Ok(response);
    }


    // [ ] Get
    // [ ] Detail 






}
