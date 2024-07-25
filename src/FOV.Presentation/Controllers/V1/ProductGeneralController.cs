using FOV.Application.Features.IngredientGenerals.Commands.Update;
using FOV.Application.Features.ProductGenerals.Commands.Create;
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
    [HttpPatch("{productId :guid}/ingredient/{ingredientId :guid}")]
    public async Task<IActionResult> UpdateQuantity(Guid productId, Guid ingredientId, [FromBody] decimal Quantity)
    {
        var response = await _sender.Send(new UpdateIngredientQuantityCommand(productId, ingredientId, Quantity));
        return Ok(response);
    }
    // [ ] Update

    [HttpPost("{productId: guid}")]
    public async Task<IActionResult> Update(Guid productId,UpdateProductGeneralCommand command)
    {
        command.Id = productId;
        var response = await _sender.Send(command);
        return Ok(response);
    }

    // [ ] Active 
    // [ ] Inactive
    // [ ] Get
    // [ ] Detail 





}
