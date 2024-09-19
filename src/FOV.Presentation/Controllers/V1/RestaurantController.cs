using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Restaurants.Commons.Active;
using FOV.Application.Features.Restaurants.Commons.Create;
using FOV.Application.Features.Restaurants.Commons.Inactive;
using FOV.Application.Features.Restaurants.Queries.Get;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class RestaurantController(IMediator mediator) : DefaultController
{

    private readonly IMediator _mediator = mediator;

    // [ ] Add New Restaurant
    [HttpPost]
    public async Task<IActionResult> AddRestaurant(CreateRestaurantCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return Ok(new OK_Result<Guid>("Thêm nhà hàng mới thành công", response));
        }
        catch (AppException ex)
        {
            return BadRequest(new Error<string>("Thêm nhà hàng thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.Errors));
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetMenu([FromQuery] GetRestaurantCommand query)
    {
        var response = await _mediator.Send(query);
        return Ok(response);
    }

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

    [HttpPost("{id:guid}/inactive")]
    public async Task<IActionResult> InactiveRestaurant(Guid id)
    {
        try
        {
            var response = await _mediator.Send(new InactiveRestaurantCommand(id));
            return Ok(new OK_Result<Guid>("Thay đổi trạng thái nhà hàng thành không hoạt động thành công", response));
        } catch (Exception ex)
        {
            return BadRequest(new Error<string>("Không hoạt động thất bại", ErrorStatusCodeConfig.BAD_REQUEST, new List<string> { ex.Message }));
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
