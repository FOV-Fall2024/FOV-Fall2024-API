using FOV.Application.Features.Categories.Commands.AddNewChildCategory;
using FOV.Application.Features.Categories.Commands.Update;
using FOV.Application.Features.Categories.Queries.GetParentCategories;
using FOV.Application.Features.Categories.Reponses;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class CategoryController : DefaultController
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all parent categories.
    /// </summary>
    /// <returns>A list of parent categories.</returns>
  
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves all categories.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCategory([FromQuery] GetCategoriesCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    /// <summary>
    /// Adds a new child category.
    /// </summary>
    /// <param name="command">The command containing details of the new category.</param>
    /// <returns>The ID of the newly created child category.</returns>
    [Authorize(Roles = Role.Administrator)]
    [HttpPost]
    [SwaggerOperation(Summary = "Adds a new child category.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddChildCategory([FromBody] AddNewCategoryCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(new OK_Result<Guid>("Thêm danh mục con thành công", response));
    }

    /// <summary>
    /// Updates the name and description of a category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="name">The new name for the category.</param>
    /// <returns>The ID of the updated category.</returns>
    [Authorize(Roles = Role.Administrator)]
    [HttpPut("{id:guid}")]
    [SwaggerOperation(Summary = "Updates the name and description of a category.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command)
    {
        command.Id = id;
        var response = await _mediator.Send(command);
        return Ok(new OK_Result<string>("Cập nhật danh mục thành công", ""));
    }

   
}
