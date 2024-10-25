using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Orders.Commands.AddProduct;
using FOV.Application.Features.Orders.Commands.ChangeStateOrder;
using FOV.Application.Features.Orders.Commands.CreateOrder;
using FOV.Application.Features.Orders.Commands.RefundOrder;
using FOV.Application.Features.Orders.Queries.GetOrderDetails;
using FOV.Application.Features.Orders.Queries.GetOrders;
using FOV.Application.Features.Orders.Queries.SuggestDishesForHeadchef;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class OrderController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    [HttpPost("{tableId:guid}/table")]
    public async Task<IActionResult> Add(Guid tableId, [FromBody] CreateOrderWithTableIdCommand command)
    {
        try
        {
            command.TableId = tableId;
            var response = await _sender.Send(command);
            return Ok(new OK_Result<Guid>("Đặt hàng thành công", response));
        }
        catch (AppException ex)
        {
            return BadRequest(new Error<FieldError>("Đặt hàng thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
        }
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetOrdersRequest command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPatch("{orderId:guid}/cook")]
    public async Task<IActionResult> ConfirmOrderToCook(Guid orderId)
    {
        var command = new ConfirmOrderToCookCommand(orderId);
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPatch("{orderId:guid}/serve")]
    public async Task<IActionResult> ConfirmOrderToServe(Guid orderId)
    {
        var command = new ConfirmOrderToServeCommand(orderId);
        var response = await _sender.Send(command);
        return Ok(response);
    }
        
    [HttpGet("{orderId:guid}/details")]
    public async Task<IActionResult> GetOrderDetails(Guid orderId)
    {
        var command = new GetOrderDetailsCommand(orderId);
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPost("{orderId:guid}/add-products")]
    public async Task<IActionResult> AddProductsToOrder(Guid orderId, [FromBody] AddProductsToOrdersCommand command)
    {
        command.OrderId = orderId;
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpPatch("{orderId:guid}/refund")]
    public async Task<IActionResult> RefundOrder(Guid orderId, [FromBody] RefundOrderCommand command)
    {
        command = command with { OrderId = orderId };
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpGet("{restaurantId:guid}/suggest-dishes")]
    public async Task<IActionResult> SuggestDishesForHeadchef(Guid restaurantId, [FromQuery] PagingRequest pagingRequest)
    {
        var command = new SuggestDishesForHeadchefCommand(pagingRequest, restaurantId);
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
