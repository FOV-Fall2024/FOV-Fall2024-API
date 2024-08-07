﻿using FOV.Application.Features.Authorize.Commands.CreateEmployee;
using FOV.Application.Features.Users.Commands.Active;
using FOV.Application.Features.Users.Commands.Inactive;
using FOV.Application.Features.Users.Queries.GetAllEmployee;
using FOV.Application.Features.Users.Queries.GetAllUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class UserController(IMediator mediator) : DefaultController
{

    //[ ] Active User  
    //[ ] Inactive User  
    //[ ] View Users 
    //[ ] View User Detail 
    private readonly IMediator _mediator = mediator;



    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand request)
    {
        return Ok(await _mediator.Send(request));
    }

    [HttpGet("users")]
    public async Task<IActionResult> Get([FromQuery] GetUsersCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("employee")]
    public async Task<IActionResult> GetEmployee([FromQuery] GetAllEmployeeCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpPost("{id}/active")]
    public async Task<IActionResult> Active(string id)
    {
        return Ok(await _mediator.Send(new ActiveEmployeeCommand(id)));
    }

    [HttpPost("{id}/inactive")]
    public async Task<IActionResult> InActive(string id)
    {
        return Ok(await _mediator.Send(new InactvieEmployeeCommand(id)));
    }
}
