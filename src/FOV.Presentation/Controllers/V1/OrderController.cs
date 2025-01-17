﻿using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Orders.Commands.AddFeedback;
using FOV.Application.Features.Orders.Commands.AddProduct;
using FOV.Application.Features.Orders.Commands.CancelOrder;
using FOV.Application.Features.Orders.Commands.ChangeState;
using FOV.Application.Features.Orders.Commands.ChangeStateOrder;
using FOV.Application.Features.Orders.Commands.CreateOrder;
using FOV.Application.Features.Orders.Commands.RefundOrder;
using FOV.Application.Features.Orders.Queries.GetOrderDetails;
using FOV.Application.Features.Orders.Queries.GetOrderResponsibility;
using FOV.Application.Features.Orders.Queries.GetOrders;
using FOV.Application.Features.Orders.Queries.GetRefundableDishToServe;
using FOV.Application.Features.Orders.Queries.SuggestDishesForHeadchef;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        return Ok(new OK_Result<Guid>("Đặt hàng thành công", response));
    }
    [Authorize(Roles = $"{Role.Waiter},{Role.Manager},{Role.Administrator}")]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetOrdersRequest command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [Authorize(Roles = Role.Waiter)]
    [HttpPatch("{orderId:guid}/cook")]
    public async Task<IActionResult> ConfirmOrderToCook(Guid orderId)
    {
        var command = new ConfirmOrderToCookCommand(orderId);
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [Authorize(Roles = Role.HeadChef)]
    [HttpPatch("{orderId:guid}/cooked")]
    public async Task<IActionResult> ConfirmOrderToCooked(Guid orderId, Guid orderDetailsId)
    {
        var command = new ConfirmOrderCookedCommand(orderId, orderDetailsId);
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [Authorize(Roles = Role.Waiter)]
    [HttpPatch("{orderId:guid}/refundable-dish")]
    public async Task<IActionResult> ConfirmRefundableDish(Guid orderId, Guid orderDetailsId)
    {
        var command = new ConfirmRefundableDishServeCommand(orderId, orderDetailsId);
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [Authorize(Roles = Role.Waiter)]
    [HttpPatch("{orderId:guid}/serve")]
    public async Task<IActionResult> ConfirmOrderToServe(Guid orderId, Guid OrderDetailsId)
    {
        var command = new ConfirmOrderToServeCommand(orderId, OrderDetailsId);
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
        return Ok(new OK_Result<Guid>("Đặt thêm món thành công", response));
    }
    [Authorize(Roles = Role.Waiter)]
    [HttpPatch("{orderId:guid}/refund")]
    public async Task<IActionResult> RefundOrder(Guid orderId, [FromQuery] Guid orderDetailId, [FromQuery] int refundQuantity)
    {
        var command = new RefundOrderCommand(orderId, orderDetailId, refundQuantity);
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
    [Authorize(Roles = Role.Waiter)]
    [HttpGet("serve-refundable-dishes")]
    public async Task<IActionResult> ServeRefundableDishes(GetRefundableDishToServeCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpPatch("{orderId:guid}/cancel")]
    public async Task<IActionResult> CancelOrder(Guid orderId)
    {
        try
        {
            var command = new CancelOrderCommand(orderId);
            var response = await _sender.Send(command);
            return Ok(new OK_Result<Guid>("Đơn hàng đã hủy thành công", response));
        }
        catch (AppException ex)
        {
            return BadRequest(new Error<FieldError>("Hủy đơn hàng thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
        }
    }
    [HttpPatch("{orderId:guid}/feedback")]
    public async Task<IActionResult> AddFeedbackToOrder(Guid orderId, [FromBody] AddFeedBackToOrderCommand command)
    {
        command = new AddFeedBackToOrderCommand(command.Feedback)
        {
            OrderId = orderId
        };
        var response = await _sender.Send(command);
        return Ok(new OK_Result<Guid>("Thêm phản hồi thành công", response));
    }
    [HttpPatch("{orderId:guid}/cancel-add-more")]
    public async Task<IActionResult> CancelOrderDetail(Guid orderId)
    {
        var command = new CancelOrderDetailCommand(orderId);
        var response = await _sender.Send(command);
        return Ok(new OK_Result<Guid>("Hủy món ăn thành công", response));
    }
    [HttpGet("{orderId:guid}/order-responsibility")]
    public async Task<IActionResult> OrderResponsibility(Guid orderId)
    {
        var command = new OrderResponsibilitiesCommand(orderId);
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
