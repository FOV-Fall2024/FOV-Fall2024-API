using FOV.Application.Features.Products.Commons.Active;
using FOV.Application.Features.Products.Commons.Add;
using FOV.Application.Features.Products.Commons.Inactive;
using FOV.Application.Features.Products.Commons.Update;
using FOV.Application.Features.Products.Queries.GetMenu;
using FOV.Application.Features.Products.Queries.GetProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class ProductController(IMediator mediator) : DefaultController
{
    private readonly IMediator _mediator = mediator;

    [HttpPost("addProduct")]
    public async Task<IActionResult> AddNewProduct(AddProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPost("active")]
    public async Task<IActionResult> Active(ActiveProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPost("inactive")]
    public async Task<IActionResult> InActive(InactiveProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("menu")]
    public async Task<IActionResult> GetMenu([FromQuery] GetMenuCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UpdateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
