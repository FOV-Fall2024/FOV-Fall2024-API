using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FOV.Domain.Entities.UserAggregator;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FOV.Application.Features.Authorize.Commands.UserLogin;

public sealed record UserLoginCommand(string Email, string Password) : IRequest<UserToken>;
public sealed record UserToken(string AccessToken, string RefreshToken);
public class UserLoginHandler(UserManager<User> userManager, IConfiguration configuration) : IRequestHandler<UserLoginCommand, UserToken>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<UserToken> Handle(UserLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        var roles = await _userManager.GetRolesAsync(user);


        string token = GenerateJWT(user, roles, _configuration["JWT:SecretKey"] ?? throw new Exception(), _configuration["JWT:ValidIssuer"] ?? throw new Exception(), _configuration["JWT:ValidAudience"] ?? throw new Exception());
        return new UserToken(token, "not");
    }


    private static string GenerateJWT(User user, IList<string> userRoles, string secretKey, string issuer, string audience)
    {

        DateTime secretKeyDatetime = DateTime.UtcNow;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
            {
                new("UserId", user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName ?? throw new Exception() ),
                new (ClaimTypes.Role,userRoles.First()),
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
