using Azure;
using FluentResults;
using FOV.Application.Features.Authorize.Commands.EmployeeLogin;
using FOV.Application.Features.Authorize.Commands.UserLogin;
using FOV.Application.Features.Authorize.Commands.UserRegister;
using FOV.Application.Features.Authorize.Queries.Profile;
using FOV.Domain.Entities.UserAggregator;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
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
        return response.IsSuccess ? Ok(new OK_Result<string>("Register Successfully", response.Successes.ToList().First().Message)) : BadRequest(new Error<IReason>("", ErrorStatusCodeConfig.BAD_REQUEST, response.Reasons));
    }

    // [ ] Login (Employee)
    [HttpPost("login/employee")]
    public async Task<IActionResult> Login(EmployeeLoginCommand request)
    {
        var response = await _sender.Send(request);
        return Ok(new OK_Result<EmployeeLoginResponse>("Login Successfully",response));
    }

    // [x] Login (Customer)
    [HttpPost("login/customer")]
    public async Task<IActionResult> CustomerLogin(UserLoginCommand command)
    {
        var response = await _sender.Send(command);

        return Ok(new OK_Result<UserToken>("Login Successfully", response));
    }

    // [x] View Profile
    [HttpGet("me")]
    public async Task<IActionResult> Profile()
    {
        var response = await _sender.Send(new ViewProfileCommand());
        return Ok(new OK_Result<ViewProfileResponse>("View Profile Successfully", response));
    }

    [HttpGet("login-google")]
    public IActionResult LoginWithGoogle()
    {
        var redirectUrl = Url.Action("GoogleResponse", "Auth");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("signin-google")]
    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        if (!result.Succeeded)
        {
            return BadRequest("Error authenticating with Google");
        }

        var claims = result.Principal.Identities
            .FirstOrDefault()?.Claims.Select(claim => new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });

        // Here, you would typically generate a JWT token or handle the claims as needed

        return Ok(claims);
    }
    // [ ]  Update Profile 

    // [ ] Login Google 
}
