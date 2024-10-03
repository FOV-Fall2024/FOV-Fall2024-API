using FOV.Application.Features.DishGenerals.Commands.Active;
using FOV.Application.Features.DishGenerals.Commands.Create;
using FOV.Application.Features.DishGenerals.Commands.Inactive;
using FOV.Application.Features.DishGenerals.Commands.Update;
using FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;
using FOV.Application.Features.DishGenerals.Queries.GetProductGeneral;
using FOV.Application.Features.DishGenerals.Queries.GetProductGeneralDetail;
using FOV.Application.Features.DishGenerals.Responses;
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
public class DishGeneralController : DefaultController
{
    private readonly ISender _sender;

    public DishGeneralController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Creates a new product general.
    /// </summary>
    /// <param name="command">The command containing product details.</param>
    /// <returns>The ID of the newly created product general.</returns>
    [Authorize(Role.Administrator)]
    [HttpPost]
    [SwaggerOperation(Summary = "Creates a new product general.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add(CreateProductGeneralCommand command)
    {
        var response = await _sender.Send(command);
        if (response == Guid.Empty)
        {
            return BadRequest("Failed to create product general.");
        }

        return CreatedAtAction(nameof(Add), new { id = response }, new CREATED_Result("Tạo product general thành công"));
    }

    /// <summary>
    /// Uploads an image.
    /// </summary>
    /// <param name="imageFile">The image file to upload.</param>
    /// <returns>The URL of the uploaded image.</returns>
    [HttpPost("upload")]
    [SwaggerOperation(Summary = "Uploads an image.")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UploadImage([FromForm] UpdateIngredientQuantityCommand imageFile)
    {

        return CreatedAtAction(nameof(UploadImage), await _sender.Send(imageFile));
    }

    /// <summary>
    /// Updates the ingredient quantity for a specific product.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <param name="ingredientId">The ID of the ingredient.</param>
    /// <param name="command">The command containing the new quantity.</param>
    /// <returns>A success message.</returns>
    [Authorize(Roles = Role.Administrator)]
    [HttpPatch("{productId}/ingredient/{ingredientId}")]
    [SwaggerOperation(Summary = "Updates the ingredient quantity for a specific product.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateQuantity(Guid productId, Guid ingredientId, [FromBody] UpdateIngredientQuantityCommand command)
    {
        command.ProductId = productId;
        command.IngredientId = ingredientId;
        var response = await _sender.Send(command);
        return Ok(new UPDATED_Result("Cập nhật số lượng nguyên liệu thành công"));
    }

    /// <summary>
    /// Updates an existing product general.
    /// </summary>
    /// <param name="productId">The ID of the product to update.</param>
    /// <param name="command">The command containing updated product details.</param>
    /// <returns>The ID of the updated product general.</returns>
    [Authorize(Roles = Role.Administrator)]
    [HttpPut("{productId}")]
    [SwaggerOperation(Summary = "Updates an existing product general.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(Guid productId, [FromBody] UpdateProductGeneralCommand command)
    {
        command.Id = productId;
        var response = await _sender.Send(command);
        return Ok(new UPDATED_Result("Cập nhật product general thành công", response));
    }

    /// <summary>
    /// Activates a product general.
    /// </summary>
    /// <param name="id">The ID of the product to activate.</param>
    /// <returns>A success message.</returns>
    [Authorize(Roles = Role.Administrator)]
    [HttpPost("{id:guid}/active")]
    [SwaggerOperation(Summary = "Activates a product general.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Active(Guid id)
    {
        var response = await _sender.Send(new ActiveProductGeneralCommand(id));
        return Ok(new UPDATED_Result("Kích hoạt product general thành công"));
    }

    /// <summary>
    /// Deactivates a product general.
    /// </summary>
    /// <param name="id">The ID of the product to deactivate.</param>
    /// <returns>A success message.</returns>
    [Authorize(Roles = Role.Administrator)]
    [HttpPost("{id:guid}/inactive")]
    [SwaggerOperation(Summary = "Deactivates a product general.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Inactive(Guid id)
    {
        var response = await _sender.Send(new InactiveProductGeneralCommand(id));
        return Ok(new DELETED_Result("Vô hiệu hóa product general thành công"));
    }

    /// <summary>
    /// Retrieves all product generals.
    /// </summary>
    /// <param name="command">The command containing query parameters for retrieval.</param>
    /// <returns>A list of product generals.</returns>
    [Authorize(Roles = Role.Administrator + "," + Role.Manager)]
    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves all product generals.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] GetProductGeneralCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(new OK_Result<PagedResult<GetProductGeneralResponse>>("Lấy product generals thành công", response));
    }

    /// <summary>
    /// Retrieves detailed information about a specific product general.
    /// </summary>
    /// <param name="id">The ID of the product general to retrieve.</param>
    /// <returns>The details of the specified product general.</returns>
    [Authorize(Roles = Role.Administrator + "," + Role.Manager)]
    [HttpGet("{id:guid}")]
    [SwaggerOperation(Summary = "Retrieves detailed information about a specific product general.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetDetail(Guid id)
    {
        var response = await _sender.Send(new GetProductGeneralDetailCommand(id));
        return Ok(new OK_Result<GetProductGeneralDetailResponse>("Lấy chi tiết product general thành công", response));
    }
}
