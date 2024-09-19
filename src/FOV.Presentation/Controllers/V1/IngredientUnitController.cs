using System.Linq.Dynamic.Core;
using FOV.Application.Features.IngredientUnits.Commands.CreateNewIngredientUnit;
using FOV.Application.Features.IngredientUnits.Commands.Update;
using FOV.Application.Features.IngredientUnits.Queries.GetIngredientUnit;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1;
public class IngredientUnitController : DefaultController
{
    private readonly ISender _sender;

    public IngredientUnitController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Retrieves an ingredient unit by ID.
    /// </summary>
    /// <param name="id">The ID of the ingredient unit.</param>
    /// <returns>The ingredient unit details.</returns>
    [HttpGet("{id:guid}")]
    [SwaggerOperation(Summary = "Retrieves an ingredient unit by ID.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _sender.Send(new GetIngredientUnitCommand(id));
        return Ok(new OK_Result<List<GetIngredientUnitResponse>>("Get Ingredient Unit Successfully", response));
    }

    /// <summary>
    /// Adds a new ingredient unit.
    /// </summary>
    /// <param name="command">The command containing ingredient unit details.</param>
    /// <returns>The ID of the newly created ingredient unit.</returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Adds a new ingredient unit.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add(CreateNewIngredientUnitCommand command)
    {
        var response = await _sender.Send(command);
        return CreatedAtAction(nameof(Get), new { id = response }, new CREATED_Result("Tạo nguyên liệu thành công", response));
    }

    /// <summary>
    /// Updates an existing ingredient unit.
    /// </summary>
    /// <param name="id">The ID of the ingredient unit to update.</param>
    /// <param name="command">The command with updated ingredient unit details.</param>
    /// <returns>No content.</returns>
    [HttpPut("{id:guid}")]
    [SwaggerOperation(Summary = "Updates an existing ingredient unit.")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, UpdateIngredientUnitCommand command)
    {
        command.IngredientUnitId = id;
        await _sender.Send(command);
        return NoContent(); // 204 No Content
    }

    // Additional endpoints (e.g., Remove) can be added here
}
