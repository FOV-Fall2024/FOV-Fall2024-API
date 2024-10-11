using FOV.Application.Features.Dishes.Commons.Active;
using FOV.Application.Features.Dishes.Commons.Add;
using FOV.Application.Features.Dishes.Commons.Inactive;
using FOV.Application.Features.Dishes.Queries.GetMenu;
using FOV.Application.Features.Dishes.Queries.GetProduct;
using FOV.Application.Features.Dishes.Responses;
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
public class DishController : DefaultController
{
    private readonly IMediator _mediator;

    public DishController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="command">The command containing product details.</param>
    /// <returns>The result of the add operation.</returns>
    [Authorize(Roles = Role.Manager)]
    [HttpPost("addProduct")]
    [SwaggerOperation(Summary = "Adds a new product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddNewProduct(AddProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Created("", new CREATED_Result("Tạo món ăn thành công", response));
    }

    /// <summary>
    /// Activates a product.
    /// </summary>
    /// <param name="command">The command containing product activation details.</param>
    /// <returns>The result of the activation operation.</returns>
    [Authorize(Roles = Role.Manager)]
    [HttpPost("active")]
    [SwaggerOperation(Summary = "Activates a product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Active(ActiveProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(new UPDATED_Result("Product activated successfully", response));
    }

    /// <summary>
    /// Deactivates a product.
    /// </summary>
    /// <param name="command">The command containing product deactivation details.</param>
    /// <returns>The result of the deactivation operation.</returns>
    [Authorize(Roles = Role.Manager)]
    [HttpPost("inactive")]
    [SwaggerOperation(Summary = "Deactivates a product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Inactive(InactiveProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(new UPDATED_Result("Product deactivated successfully", response));
    }

    /// <summary>
    /// Retrieves the menu of products.
    /// </summary>
    /// <param name="command">The command containing query parameters for the menu.</param>
    /// <returns>A list of products in the menu.</returns>
    [HttpGet("menu")]
    [SwaggerOperation(Summary = "Retrieves the menu of products.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMenu([FromQuery] GetMenuCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    /// <summary>
    /// Retrieves a specific product.
    /// </summary>
    /// <param name="command">The command containing product query parameters.</param>
    /// <returns>The details of the requested product.</returns>
    [Authorize]
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves a specific product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] GetProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="command">The command containing updated product details.</param>
    /// <returns>The result of the update operation.</returns>
    //[Authorize(Roles = Role.Manager)]
    //[HttpPut("{id}")]
    //[SwaggerOperation(Summary = "Updates an existing product.")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
    //{
    //    command.ProductId = id;
    //    var response = await _mediator.Send(command);
    //    return Ok(new UPDATED_Result("Cập nhật món ăn thành công", response));
    //}
}
