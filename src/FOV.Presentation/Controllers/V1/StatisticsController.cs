﻿using FOV.Application.Features.Statistics.Queries.GetCurrentStatistic;
using FOV.Application.Features.Statistics.Queries.GetDetailsRestaurants;
using FOV.Application.Features.Statistics.Queries.GetTopNCombo;
using FOV.Application.Features.Statistics.Queries.GetTopNDishGeneral;
using FOV.Application.Features.Statistics.Queries.GetTopRestaurantCustomers;
using FOV.Application.Features.Statistics.Queries.GetTopRestaurantOrders;
using FOV.Application.Features.Statistics.Queries.GetTopRestaurantRevenues;
using FOV.Application.Features.Statistics.Queries.GetTopUnpopular;
using FOV.Application.Features.Statistics.Queries.GetTotalCustomers;
using FOV.Application.Features.Statistics.Queries.GetTotalOrders;
using FOV.Application.Features.Statistics.Queries.GetTotalRevenues;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class StatisticsController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [HttpGet("top-dish")]
    public async Task<IActionResult> GetTopNDish([FromQuery] GetTopNDishGeneralCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("top-combo")]
    public async Task<IActionResult> GetTopNCombo([FromQuery] GetTopNComboCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("revenue")]
    public async Task<IActionResult> GetRevenue([FromQuery] GetTotalRevenuesCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("customers")]
    public async Task<IActionResult> GetTotalCustomers([FromQuery] GetTotalCustomerCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("orders")]
    public async Task<IActionResult> GetTotalOrders([FromQuery] GetTotalOrderCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("current-statistic")]
    public async Task<IActionResult> GetCurrentStatistic()
    {
        var result = await _sender.Send(new GetCurrentStatisticCommand());
        return Ok(result);
    }
    [HttpGet("top-restaurant-revenues")]
    public async Task<IActionResult> GetTopRestaurantRevenues([FromQuery] GetTopRestaurantRevenuesCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("top-restaurant-orders")]
    public async Task<IActionResult> GetTopRestaurantOrders([FromQuery] GetTopRestaurantOrdersCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("top-restaurant-customers")]
    public async Task<IActionResult> GetTopRestaurantCustomers([FromQuery] GetTopRestaurantCustomersCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("details-restaurant")]
    public async Task<IActionResult> GetDetailsRestaurants([FromQuery] GetDetailsRestaurantsDetailsCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("top-unpopular")]
    public async Task<IActionResult> GetTopUnpopular([FromQuery] GetTopUnpopularCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
}
