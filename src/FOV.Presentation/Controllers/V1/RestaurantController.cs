﻿using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Restaurants.Commons.Active;
using FOV.Application.Features.Restaurants.Commons.Create;
using FOV.Application.Features.Restaurants.Commons.Inactive;
using FOV.Application.Features.Restaurants.Commons.Update;
using FOV.Application.Features.Restaurants.Queries.Detail;
using FOV.Application.Features.Restaurants.Queries.Get;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class RestaurantController(IMediator mediator) : DefaultController
{

    private readonly IMediator _mediator = mediator;

    // [ ] Add New Restaurant
    [Authorize(Roles = Role.Administrator)]
    [HttpPost]
    public async Task<IActionResult> AddRestaurant(CreateRestaurantCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return Ok(new OK_Result<CreateRestaurantResponse>("Thêm nhà hàng mới thành công", response));
        }
        catch (AppException ex)
        {
            return BadRequest(new Error<FieldError>("Thêm nhà hàng thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetMenu([FromQuery] GetRestaurantCommand query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [Authorize(Roles = Role.Administrator)]
    [HttpPost("{id:guid}/active")]
    public async Task<IActionResult> ActiveRestaurant(Guid id)
    {
        try
        {
            var response = await _mediator.Send(new ActiveRestaurantCommand(id));
            return Ok(new OK_Result<Guid>("Thay đổi trạng thái nhà hàng thành hoạt động thành công", response));
        }
        catch (Exception ex)
        {
            return BadRequest(new Error<string>("Kích hoạt thất bại", ErrorStatusCodeConfig.BAD_REQUEST, new List<string> { ex.Message }));
        }
    }

    [Authorize(Roles = Role.Administrator)]
    [HttpPost("{id:guid}/inactive")]
    public async Task<IActionResult> InactiveRestaurant(Guid id)
    {
        try
        {
            var response = await _mediator.Send(new InactiveRestaurantCommand(id));
            return Ok(new OK_Result<Guid>("Thay đổi trạng thái nhà hàng thành không hoạt động thành công", response));
        }
        catch (Exception ex)
        {
            return BadRequest(new Error<string>("Không hoạt động thất bại", ErrorStatusCodeConfig.BAD_REQUEST, new List<string> { ex.Message }));
        }
    }

    [Authorize(Roles = Role.Administrator)]
    [HttpPatch("{id:guid}/update")]
    public async Task<IActionResult> UpdateRestaurant(Guid id, UpdateRestaurantCommand command)
    {
        try
        {
            command.Id = id;
            var response = await _mediator.Send(command);
            return Ok(new OK_Result<Guid>("Cập nhật nhà hàng thành công", response));
        }
        catch (AppException ex)
        {
            return BadRequest(new Error<FieldError>("Cập nhật nhà hàng thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
        }
    }

    [Authorize(Roles = Role.Administrator)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRestaurant(Guid id)
    {
        try
        {
            var response = await _mediator.Send(new GetRestaurantDetailCommand(id));
            return Ok(response);
        }
        catch (AppException ex)
        {
            return BadRequest(new Error<string>("Lấy thông tin nhà hàng thất bại", ErrorStatusCodeConfig.BAD_REQUEST, new List<string> { ex.Message }));
        }
    }

    /* XXX  Demo 1
    1. Add New Account Manager (Admin )
    2. Using account Manager to add menu ( register  a restaurant)
    => auto implement ingredient to this (Manager)
    3. Admin add ingredient quantity follow IngredientId 
    => if 
    */

    // [ ] Update Restaurant Information
    // [ ] Add Quantity follow IngredientId 


}
