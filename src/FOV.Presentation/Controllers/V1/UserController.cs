using Azure;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Authorize.Commands.CreateEmployee;
using FOV.Application.Features.Users.Commands.Active;
using FOV.Application.Features.Users.Commands.Inactive;
using FOV.Application.Features.Users.Queries.GetAllEmployee;
using FOV.Application.Features.Users.Queries.GetAllUser;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
        try
        {
            var response = await _mediator.Send(request);
            return Ok(new OK_Result<string>(response.Value, null));
        } catch (AppException ex)
        {
            return BadRequest(new Error<FieldError>("Tạo tài khoản thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
        }
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

    [HttpPost("activate/{id}")]
    public async Task<IActionResult> ActivateEmployee(string id)
    {
        try
        {
            var result = await _mediator.Send(new ActiveEmployeeCommand(id));

            if (result.IsFailed)
            {
                return BadRequest(new { Errors = result.Errors.Select(e => e.Message).ToList() });
            }

            return Ok(new OK_Result<Guid>("Nhân viên đã được kích hoạt", result.Value));
        }
        catch (AppException ex)
        {
            return BadRequest(new { Errors = ex.FieldErrors });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Có lỗi xảy ra", Details = ex.Message });
        }
    }

    [HttpPost("inactivate/{id}")]
    public async Task<IActionResult> InactivateEmployee(string id)
    {
        try
        {
            var result = await _mediator.Send(new InactvieEmployeeCommand(id));

            if (result.IsFailed)
            {
                return BadRequest(new { Errors = result.Errors.Select(e => e.Message).ToList() });
            }
            return Ok(new OK_Result<Guid>("Nhân viên đã được vô hiệu hóa", result.Value));
        }
        catch (AppException ex)
        {
            return BadRequest(new { Errors = ex.FieldErrors });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Có lỗi xảy ra", Details = ex.Message });
        }
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
