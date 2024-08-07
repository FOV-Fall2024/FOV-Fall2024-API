﻿using FOV.Application.Features.Restaurants.Commons.Create;
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
        var response = await _mediator.Send(command);
        return Ok(response);
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
