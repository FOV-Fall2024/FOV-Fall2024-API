using FOV.Application.Features.Authorize.Commands.EmployeeLogin;
using FOV.Application.Features.Authorize.Commands.UserLogin;
using FOV.Application.Features.Authorize.Commands.UserRegister;
using FOV.Application.Features.Authorize.Queries.Profile;
using FOV.Domain.Entities.UserAggregator;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class AuthController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    // [x] Register 
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterCommand command)
    {
        var response = await _sender.Send(command);
        return response.IsSuccess ? Created() : BadRequest(response.Reasons);
    }

    // [ ] Login (Employee)
    [HttpPost("login/employee")]
    public async Task<IActionResult> Login(EmployeeLoginCommand request)
    {
        var response = await _sender.Send(request);
        return Ok(response);
    }

    // [x] Login (Customer)
    [HttpPost("login/customer")]
    public async Task<IActionResult> CustomerLogin(UserLoginCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }

    // [x] View Profile
    [HttpGet("me")]
    public async Task<IActionResult> Profile()
    {
        var response = await _sender.Send(new ViewProfileCommand());
        return Ok(response);
    }

    // [ ]  Update Profile 

    // [ ] Login Google 
}
