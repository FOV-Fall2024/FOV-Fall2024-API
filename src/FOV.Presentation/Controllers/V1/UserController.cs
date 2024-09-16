﻿using FOV.Application.Features.Authorize.Commands.CreateEmployee;
using FOV.Application.Features.Users.Commands.Active;
using FOV.Application.Features.Users.Commands.Inactive;
using FOV.Application.Features.Users.Queries.GetAllEmployee;
using FOV.Application.Features.Users.Queries.GetAllUser;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace FOV.Presentation.Controllers.V1;

public class UserController(IMediator mediator, IDatabase database) : DefaultController
{

    //[ ] Active User  
    //[ ] Inactive User  
    //[ ] View Users 
    //[ ] View User Detail 
    private readonly IMediator _mediator = mediator;
    private readonly IDatabase _database = database;



    [HttpPost]
    public async Task<IActionResult> Create(CreateEmployeeCommand request)
    {
        var response = await _mediator.Send(request);

        if (response.IsSuccess)
        {
            return Ok(new OK_Result<string>(response.Value, null));
        }
        return BadRequest(new OK_Result<List<string>>("Tạo tài khoản thất bại", response.Errors.Select(e => e.Message).ToList()));
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

    [HttpPost("testRedis")]
    public async Task<IActionResult> Test()
    {
        string testKey = "test_key";
        string testValue = "Hello, Redis!";
        await _database.StringSetAsync(testKey, testValue);
        return Ok();
    }
}
