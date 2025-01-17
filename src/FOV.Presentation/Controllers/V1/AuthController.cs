﻿using System.Security.Claims;
using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Authorize.Commands.ChangePassword;
using FOV.Application.Features.Authorize.Commands.EditProfile;
using FOV.Application.Features.Authorize.Commands.EmployeeLogin;
using FOV.Application.Features.Authorize.Commands.UserGoogleLogin;
using FOV.Application.Features.Authorize.Commands.UserLogin;
using FOV.Application.Features.Authorize.Commands.UserRegister;
using FOV.Application.Features.Authorize.Queries.Profile;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : DefaultController
{
    private readonly ISender _sender;

    public AuthController(ISender sender)
    {
        _sender = sender;
    }

    /// <summary>
    /// Edits the user's profile.
    /// </summary>
    /// <param name="command">The command containing profile edit details.</param>
    /// <returns>A success message.</returns>
    [Authorize]
    [HttpPost("edit-profile")]
    [SwaggerOperation(Summary = "Edit user profile.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(EditProfileCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(new OK_Result<Guid>("Thay đổi hồ sơ cá nhân thành công", response));
    }


    /// <summary>
    /// Changes the user's password.
    /// </summary>
    /// <param name="command">The command containing password change details.</param>
    /// <returns>A success message or error details.</returns>
    [HttpPost("change-password")]
    [SwaggerOperation(Summary = "Change user password.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
    {
        var result = await _sender.Send(command);
        if (result.IsSuccess)
        {
            return Ok(new OK_Result<string>("Thay đổi mật khẩu thành công", result.Successes.First().Message));
        }

        return BadRequest(result.Errors.Select(e => e.Message));
    }

    /// <summary>
    /// Logs in an employee.
    /// </summary>
    /// <param name="request">The command containing employee login details.</param>
    /// <returns>A success message with login response.</returns>
    [HttpPost("login")]
    [SwaggerOperation(Summary = "Employee login.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(EmployeeLoginCommand request)
    {
        try
        {
            var response = await _sender.Send(request);
            return response is null
                ? BadRequest(new Error<string>("Kiểm tra thông tin đăng nhập", ErrorStatusCodeConfig.BAD_REQUEST))
                : Ok(new OK_Result<EmployeeLoginResponse>("Đăng nhập thành công", response));
            }
        catch (AppException ex)
        {
            return BadRequest(new Error<FieldError>("Đăng nhập thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
        }
    }

    /// <summary>
    /// Retrieves the user's profile.
    /// </summary>
    /// <returns>The user's profile information.</returns>
    [Authorize]
    [HttpGet("me")]
    [SwaggerOperation(Summary = "View user profile.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Profile()
    {
        var response = await _sender.Send(new ViewProfileCommand());
        return Ok(new OK_Result<ViewProfileResponse>("Xem thông tin cá nhân thành công", response));
    }

    /// <summary>
    /// Initiates the Google login process.
    /// </summary>
    /// <returns>A challenge to authenticate with Google.</returns>
    [HttpGet("login-google")]
    [SwaggerOperation(Summary = "Login with Google.")]
    public IActionResult LoginWithGoogle()
    {
        var redirectUrl = Url.Action("GoogleResponse", "Auth");
        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    /// <summary>
    /// Handles the Google OAuth response.
    /// </summary>
    /// <returns>A success message with user claims.</returns>
    [HttpGet("signin-google")]
    [SwaggerOperation(Summary = "Google OAuth response handler.")]
    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        if (!result.Succeeded)
        {
            return BadRequest("Error authenticating with Google");
        }

        var response = await _sender.Send(new UserGoogleLoginCommand(
            result.Principal.FindFirstValue(ClaimTypes.NameIdentifier),
            result.Principal.FindFirstValue(ClaimTypes.Email),
            result.Principal.FindFirstValue(ClaimTypes.Name),
            result.Principal.FindFirstValue("picture")
        ));

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

    // [ ] Update Profile
}
