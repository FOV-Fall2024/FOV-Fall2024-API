using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Authorize.Commands.UserLogin;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FOV.Application.Features.Authorize.Commands.EmployeeLogin;

public sealed record EmployeeLoginCommand(string Code, string Password) : IRequest<EmployeeLoginResponse>;
public sealed record EmployeeLoginResponse(Guid Id, Guid RestaurantId, string FullName, string PhoneNumber, string Role, string AccessToken, string RefreshToken);
public class EmployeeLoginHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, NotificationHub notificationHub) : IRequestHandler<EmployeeLoginCommand, EmployeeLoginResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;
    private readonly SignInManager<User> _signInManager = signInManager;
    private readonly NotificationHub _notificationHub = notificationHub;
    public async Task<EmployeeLoginResponse> Handle(EmployeeLoginCommand request, CancellationToken cancellationToken)
    {
        var fieldErrors = new List<FieldError>();

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.EmployeeCode == request.Code);

        if (user == null)
        {
            fieldErrors.Add(new FieldError { Field = "code", Message = "Mã nhân viên không đúng" });
            throw new AppException("Đăng nhập thất bại", fieldErrors);
        }
        var roles = await _userManager.GetRolesAsync(user);

        var signIn = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!signIn)
        {
            fieldErrors.Add(new FieldError { Field = "password", Message = "Mật khẩu không chính xác" });
            throw new AppException("Đăng nhập thất bại", fieldErrors);
        }

        if (signIn)
        {
            // Using ?? operator for safe access to configuration values
            string secretKey = _configuration["JWTSecretKey:SecretKey"] ?? throw new Exception("SecretKey not configured");
            string validIssuer = _configuration["JWTSecretKey:ValidIssuer"] ?? throw new Exception("ValidIssuer not configured");
            string validAudience = _configuration["JWTSecretKey:ValidAudience"] ?? throw new Exception("ValidAudience not configured");

            string token = GenerateJWT(user, roles, secretKey, validIssuer, validAudience, user.RestaurantId ?? Guid.Empty);

            //Remember to remove this line when deploy
            await _notificationHub.SendEmployeeId(user.Id, roles.FirstOrDefault());

            return new EmployeeLoginResponse(user.Id, user.RestaurantId ?? Guid.Empty, user.FullName, user.PhoneNumber, roles.FirstOrDefault(), token, "not");
        }

        return null;
    }
    private static string GenerateJWT(User user, IList<string> userRoles, string secretKey, string issuer, string audience, Guid restaurantId)
    {

        DateTime secretKeyDatetime = DateTime.UtcNow;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
    {
        new("UserId", user.Id.ToString()),
        new("RestaurantId", restaurantId.ToString()),
        new(ClaimTypes.Role, userRoles.First()), // Assumes userRoles is not empty
    };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: secretKeyDatetime.AddMinutes(86400),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
