using System.Security.Claims;
using FOV.Application.Features.Authorize.Commands.EmployeeLogin;
using FOV.Application.Features.Authorize.Commands.UserLogin;
using FOV.Application.Features.Authorize.Commands.UserRegister;
using FOV.Domain.Entities.UserAggregator;
using FOV.Presentation.Infrastructure;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class AuthController(ISender sender, UserManager<User> userManager, SignInManager<User> signInManager) : DefaultController
{
    private readonly ISender _sender = sender;

    // [ ] Register 
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterCommand command)
    {
        var response = await _sender.Send(command);
        return response.IsSuccess ? Ok(response) : BadRequest(response.Reasons);
    }

    // [ ] Login
    [HttpPost("login/employee")]
    public async Task<IActionResult> Login(EmployeeLoginCommand request)
    {
        var response = await _sender.Send(request);
        return Ok(response);
    }
    [HttpPost("login/customer")]
    public async Task<IActionResult> CustomerLogin(UserLoginCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }

    // [ ] Login Google 
}
