using System.ComponentModel.DataAnnotations;
using FOV.Domain.Entities.UserAggregator;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace FOV.Presentation.Infrastructure;

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class CustomRegisterRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
}

public static class EndPoint
{
    public static void AuthenticationEndPoint(this WebApplication app)
    {
        app.MapIdentityApi<User>();

    }

    public static void AddCustomEndpoints(this WebApplication app)
    {
        // Define a custom register endpoint
        app.MapPost("/register", async (HttpContext context, UserManager<User> userManager, IEmailSender emailSender) =>
        {
            var registerRequest = await context.Request.ReadFromJsonAsync<CustomRegisterRequest>();
            if (registerRequest == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                return;
            }

            var user = new User
            {
                UserName = registerRequest.Username,
                Email = registerRequest.Email,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName
            };
            var result = await userManager.CreateAsync(user, registerRequest.Password);
            if (result.Succeeded)
            {
                // Optionally send a confirmation email
                var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = $"Please confirm your account by clicking <a href='your-callback-url?code={code}'>here</a>.";
                await emailSender.SendEmailAsync(registerRequest.Email, "Confirm your email", callbackUrl);

                context.Response.StatusCode = StatusCodes.Status201Created;
                await context.Response.WriteAsJsonAsync(new { Success = true });
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(result.Errors);
            }
        });
    }

}

