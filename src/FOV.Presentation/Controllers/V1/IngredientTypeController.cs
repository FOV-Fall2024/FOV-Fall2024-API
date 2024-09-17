using FOV.Application.Features.IngredientTypes.Commands.Active;
using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Application.Features.IngredientTypes.Commands.CreateChild;
using FOV.Application.Features.IngredientTypes.Commands.Inactive;
using FOV.Application.Features.IngredientTypes.Commands.Update;
using FOV.Application.Features.IngredientTypes.Queries.GetChildCategories;
using FOV.Application.Features.IngredientTypes.Queries.GetParentCategories;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class IngredientTypeController : DefaultController
{
    private readonly ISender _sender;

    public IngredientTypeController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Retrieves a list of parent ingredient types.
    /// </summary>
    /// <returns>A list of parent ingredient types.</returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves a list of parent ingredient types.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        List<GetParentCategoriesResponse> response = await _sender.Send(new GetParentCategoriesCommand());
        return Ok(new OK_Result<List<GetParentCategoriesResponse>>("Get Parent IngredientType Successfully", response));
    }

    /// <summary>
    /// Retrieves child ingredient types for a specified parent ID.
    /// </summary>
    /// <param name="parentId">The ID of the parent ingredient type.</param>
    /// <returns>A list of child ingredient types.</returns>
    [HttpGet("{parentId}")]
    [SwaggerOperation(Summary = "Retrieves child ingredient types for a specified parent ID.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetChildrenIngredientType(Guid parentId)
    {
        List<GetChildrenIngredientType> response = await _sender.Send(new GetChildCategoriesCommand(parentId));
        return Ok(new OK_Result<List<GetChildrenIngredientType>>("Get Children IngredientType Successfully", response));
    }

    /// <summary>
    /// Creates a new parent ingredient type.
    /// </summary>
    /// <param name="request">The command containing ingredient type details.</param>
    /// <returns>The ID of the newly created parent ingredient type.</returns>
    [HttpPost("parent")]
    [SwaggerOperation(Summary = "Creates a new parent ingredient type.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add(CreateIngredientTypeCommand request)
    {
        Guid response = await _sender.Send(request);
        return Ok(new OK_Result<Guid>("Create Parent IngredientType Successfully", response));
    }

    /// <summary>
    /// Creates a new child ingredient type.
    /// </summary>
    /// <param name="command">The command containing child ingredient type details.</param>
    /// <returns>The ID of the newly created child ingredient type.</returns>
    [HttpPost("child")]
    [SwaggerOperation(Summary = "Creates a new child ingredient type.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddChild(CreateChildIngredientTypeCommand command)
    {
        Guid response = await _sender.Send(command);
        return Ok(new OK_Result<Guid>("Create Child IngredientType Successfully", response));
    }

    /// <summary>
    /// Updates an existing ingredient type.
    /// </summary>
    /// <param name="id">The ID of the ingredient type to update.</param>
    /// <param name="command">The command containing updated ingredient type details.</param>
    /// <returns>The ID of the updated ingredient type.</returns>
    [HttpPut("{id:guid}")]
    [SwaggerOperation(Summary = "Updates an existing ingredient type.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, UpdateIngredientTypeCommand command)
    {
        command.Id = id;
        Guid response = await _sender.Send(command);
        return Ok(new OK_Result<Guid>("Update IngredientType Successfully", response));
    }

    /// <summary>
    /// Activates an ingredient type.
    /// </summary>
    /// <param name="id">The ID of the ingredient type to activate.</param>
    /// <returns>A success message.</returns>
    [HttpPost("{id:guid}/active")]
    [SwaggerOperation(Summary = "Activates an ingredient type.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Active(Guid id)
    {
        var response = await _sender.Send(new ActiveIngredientTypeCommand(id));
        return Ok(new OK_Result<string>("Activate IngredientType Successfully", ""));
    }

    /// <summary>
    /// Deactivates an ingredient type.
    /// </summary>
    /// <param name="id">The ID of the ingredient type to deactivate.</param>
    /// <returns>A success message.</returns>
    [HttpPost("{id:guid}/inactive")]
    [SwaggerOperation(Summary = "Deactivates an ingredient type.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InActive(Guid id)
    {
        var response = await _sender.Send(new InactiveIngredientTypeCommand(id));
        return Ok(new OK_Result<string>("Deactivate IngredientType Successfully", ""));
    }
}
