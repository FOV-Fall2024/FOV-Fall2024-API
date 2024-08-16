using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FOV.Application.Features.Authorize.Commands.UserLogin;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FOV.Application.Features.Authorize.Commands.EmployeeLogin;

public sealed record EmployeeLoginCommand(string Code, string Password) : IRequest<EmployeeLoginResponse>;
public record EmployeeLoginResponse(string AccessToken, string RefreshToken);
public class EmployeeLoginHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration) : IRequestHandler<EmployeeLoginCommand, EmployeeLoginResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;
    private readonly SignInManager<User> _signInManager = signInManager;
    public async Task<EmployeeLoginResponse> Handle(EmployeeLoginCommand request, CancellationToken cancellationToken)
    {
        // Fetch employee and related user in a single query
        var employee = await _unitOfWorks.EmployeeRepository
            .FirstOrDefaultAsync(x => x.EmployeeCode == request.Code, x => x.User);

        if (employee == null || employee.User == null)
        {
            return null;
        }

        var user = employee.User;
        var roles = await _userManager.GetRolesAsync(user);
        var signIn = await _userManager.CheckPasswordAsync(user, request.Password);

        if (signIn)
        {
            // Using ?? operator for safe access to configuration values
            string secretKey = _configuration["JWT:SecretKey"] ?? throw new Exception("SecretKey not configured");
            string validIssuer = _configuration["JWT:ValidIssuer"] ?? throw new Exception("ValidIssuer not configured");
            string validAudience = _configuration["JWT:ValidAudience"] ?? throw new Exception("ValidAudience not configured");

            string token = GenerateJWT(user, roles, secretKey, validIssuer, validAudience, Guid.NewGuid());
            return new EmployeeLoginResponse(token, "not");
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
