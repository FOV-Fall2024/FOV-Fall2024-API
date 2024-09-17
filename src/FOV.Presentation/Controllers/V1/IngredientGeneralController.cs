using FOV.Application.Features.IngredientGenerals.Commands.Active;
using FOV.Application.Features.IngredientGenerals.Commands.Create;
using FOV.Application.Features.IngredientGenerals.Commands.Inactive;
using FOV.Application.Features.IngredientGenerals.Commands.Update;
using FOV.Application.Features.IngredientGenerals.Queries.GetAllIngredientGeneral;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class IngredientGeneralController : DefaultController
{
    private readonly ISender _sender;

    public IngredientGeneralController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Creates a new ingredient general.
    /// </summary>
    /// <param name="command">The command containing ingredient details.</param>
    /// <returns>The ID of the newly created ingredient general.</returns>
    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new ingredient general.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateIngredientGeneralCommand command)
    {
        var response = await _sender.Send(command);
        return Created("", new CREATED_Result("Ingredient general created successfully"));
    }

    /// <summary>
    /// Updates an existing ingredient general.
    /// </summary>
    /// <param name="id">The ID of the ingredient general to update.</param>
    /// <param name="command">The command containing updated ingredient details.</param>
    /// <returns>The ID of the updated ingredient general.</returns>
    [HttpPut("{id:guid}")]
    [SwaggerOperation(Summary = "Updates an existing ingredient general.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, UpdateIngredientGeneralCommand command)
    {
        command.Id = id;
        var response = await _sender.Send(command);
        return Ok(new UPDATED_Result("Ingredient general updated successfully", response));
    }

    /// <summary>
    /// Activates an ingredient general.
    /// </summary>
    /// <param name="id">The ID of the ingredient general to activate.</param>
    /// <returns>A success message.</returns>
    [HttpPost("{id:guid}/active")]
    [SwaggerOperation(Summary = "Activates an ingredient general.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Active(Guid id)
    {
        var response = await _sender.Send(new ActiveIngredientGeneralCommand(id));
        return Ok(new OK_Result<string>("Ingredient general activated successfully", ""));
    }

    /// <summary>
    /// Deactivates an ingredient general.
    /// </summary>
    /// <param name="id">The ID of the ingredient general to deactivate.</param>
    /// <returns>A success message.</returns>
    [HttpPost("{id:guid}/inactive")]
    [SwaggerOperation(Summary = "Deactivates an ingredient general.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Inactive(Guid id)
    {
        var response = await _sender.Send(new InactiveIngredientGeneralCommand(id));
        return Ok(new OK_Result<string>("Ingredient general deactivated successfully", ""));
    }

    /// <summary>
    /// Retrieves all ingredient generals.
    /// </summary>
    /// <param name="command">The command containing query parameters for retrieval.</param>
    /// <returns>A list of ingredient generals.</returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves all ingredient generals.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] GetAllIngredientCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(new OK_Result<List<GetAllIngredientResponse>>("Retrieved ingredient generals successfully", response));
    }
}
