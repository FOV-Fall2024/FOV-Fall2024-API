using FOV.Application.Features.Users.Commands.CreateUser;
using FOV.Application.Features.Users.Queries.GetAllUser;
using FOV.Application.Features.Users.Responses;
using FOV.Presentation.Infrastructure.Core;
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

    [HttpPost("register")]
    public async Task<IActionResult> Post(CreateUserCommand command)
    {
        var response = await _mediator.Send(command);
        return Ok(new OK_Result<RegisterUserResponse>(response.Message, response));
    }

    [HttpGet("users")]
    public async Task<IActionResult> Get([FromQuery] GetUsersCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
  
}
