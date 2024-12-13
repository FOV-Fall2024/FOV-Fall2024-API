using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Dishes.Commons.Active;
using FOV.Application.Features.Dishes.Commons.Add;
using FOV.Application.Features.Dishes.Commons.Inactive;
using FOV.Application.Features.Dishes.Commons.Update;
using FOV.Application.Features.Dishes.Queries.GetDetail;
using FOV.Application.Features.Dishes.Queries.GetMenu;
using FOV.Application.Features.Dishes.Queries.GetProduct;
using FOV.Application.Features.Dishes.Responses;
using FOV.Application.Features.Restaurants.Queries.Detail;
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

    [Authorize(Roles = Role.Manager)]
    [HttpPost("{id:guid}/active")]
    [SwaggerOperation(Summary = "Activates a product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Active(Guid id)
    {
        var response = await _mediator.Send(new ActiveProductCommand(id));
        return Ok(new UPDATED_Result("Món ăn hoạt động thành công", response));
    }

    [Authorize(Roles = Role.Manager)]
    [HttpPost("{id:guid}/inactive")]
    [SwaggerOperation(Summary = "Deactivates a product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Inactive(Guid id)
    {
        var response = await _mediator.Send(new InactiveProductCommand(id));
        return Ok(new UPDATED_Result("Món ăn ngưng hoạt động", response));
    }


    /// <summary>
    /// Retrieves the menu of products.
    /// </summary>
    /// <param name="command">The command containing query parameters for the menu.</param>
    /// <returns>A list of products in the menu.</returns>
    [HttpGet("dish")]
    [SwaggerOperation(Summary = "Retrieves the menu of products.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMenu([FromQuery] GetMenuCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
        catch (AppException ex)
        {
            return BadRequest(new Error<string>("Lấy thông tin nhà hàng thất bại", ErrorStatusCodeConfig.BAD_REQUEST, new List<string> { ex.Message }));
        }
    }

    [HttpGet("{id:guid}/detail")]
    [SwaggerOperation(Summary = "Retrieves detailed information about a specific product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProductDetail(Guid id)
    {
        var response = await _mediator.Send(new GetDetailCommand(id));
        return Ok(response);
    }

    /// <summary>
    /// Retrieves a specific product.
    /// </summary>
    /// <param name="command">The command containing product query parameters.</param>
    /// <returns>The details of the requested product.</returns>
    //[Authorize]
    //[HttpGet]
    //[SwaggerOperation(Summary = "Retrieves a specific product.")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<IActionResult> Get([FromQuery] GetProductCommand command)
    //{
    //    var response = await _mediator.Send(command);
    //    return Ok(response);
    //}

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name = "id" > The ID of the product to update.</param>
    /// <param name = "command" > The command containing updated product details.</param>
    /// <returns>The result of the update operation.</returns>
    [Authorize(Roles = Role.Manager)]
    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Updates an existing product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
    {
        command.ProductId = id;
        var response = await _mediator.Send(command);
        return Ok(new UPDATED_Result("Cập nhật món ăn thành công", response));
    }
}
