using FOV.Application.Features.Orders.Commands.Create;
using FOV.Application.Features.Orders.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class OrderController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    [HttpPost("{tableId:guid}/table")]
    public async Task<IActionResult> Add(Guid tableId, [FromBody] CreateOrderWithTableIdCommand command)
    {
        command.TableId = tableId;
        var response = await _sender.Send(command);
        return Ok(response);
    }

    //[HttpGet]
    //public async Task<IActionResult> Get([FromQuery] GetOrderCommand command)
    //{
    //    var response = await _sender.Send(command);
    //    return Ok(response);
    //}
    //[HttpPost("{orderId:guid}/details")]
    //public async Task<IActionResult> AddOrderDetail(Guid orderId, [FromBody] CreateOrderDetailCommand command)
    //{
    //    var createOrderDetailCommand = new CreateOrderDetailWithOrderIdCommand(orderId, command.ComboId, command.ProductId, command.Status, command.Quantity, command.Price);
    //    var response = await _sender.Send(createOrderDetailCommand);
    //    return Ok(response);
    //}
    [HttpPatch("{orderDetailId:guid}/details")]
    public async Task<IActionResult> UpdateOrderDetail(Guid orderDetailId, [FromBody] UpdateOrderDetailCommand command)
    {
        command.Id = orderDetailId;
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
