using FOV.Application.Features.Products.Commons.Active;
using FOV.Application.Features.Products.Commons.Add;
using FOV.Application.Features.Products.Commons.Inactive;
using FOV.Application.Features.Products.Commons.Update;
using FOV.Application.Features.Products.Queries.GetMenu;
using FOV.Application.Features.Products.Queries.GetProduct;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : DefaultController
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="command">The command containing product details.</param>
    /// <returns>The result of the add operation.</returns>
    [HttpPost("addProduct")]
    [SwaggerOperation(Summary = "Adds a new product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddNewProduct(AddProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Created("", new CREATED_Result("Product created successfully", response));
    }

    /// <summary>
    /// Activates a product.
    /// </summary>
    /// <param name="command">The command containing product activation details.</param>
    /// <returns>The result of the activation operation.</returns>
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
        return Ok(new OK_Result<List<GetMenuResponse>>("Menu retrieved successfully", response));
    }

    /// <summary>
    /// Retrieves a specific product.
    /// </summary>
    /// <param name="command">The command containing product query parameters.</param>
    /// <returns>The details of the requested product.</returns>
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves a specific product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] GetProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(new OK_Result<List<GetProductResponse>>("Product retrieved successfully", response));
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="command">The command containing updated product details.</param>
    /// <returns>The result of the update operation.</returns>
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Updates an existing product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
    {
        command.ProductId = id;
        var response = await _mediator.Send(command);
        return Ok(new UPDATED_Result("Product updated successfully", response));
    }
}
