using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Authorize.Commands.UserLogin;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FOV.Application.Features.Authorize.Commands.UserGoogleLogin;

public sealed record UserGoogleLoginCommand(string UserName, string Email, string GoogleId, string PictureUrl) : IRequest<Result<UserToken>>;
public class UserGoogleLoginHandler(UserManager<User> userManager, IUnitOfWorks unitOfWorks, IConfiguration configuration) : IRequestHandler<UserGoogleLoginCommand, Result<UserToken>>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IConfiguration _configuration = configuration;

    public async Task<Result<UserToken>> Handle(UserGoogleLoginCommand request, CancellationToken cancellationToken)
    {
        //var user = await _userManager.FindByEmailAsync(request.UserName);
        //if (user == null)
        //{

        //    // If user doesn't exist, create a new one
        //    user = new User
        //    {
        //        UserName = request.UserName,
        //        Email = request.Email,
        //    };

        //    var createResult = await _userManager.CreateAsync(user);
        //    var roleAssignResult = await _userManager.AddToRoleAsync(user, Role.User);
        //    var loginInfo = new UserLoginInfo(
        //        GoogleDefaults.AuthenticationScheme,
        //        request.GoogleId,
        //        GoogleDefaults.DisplayName);

        //    var loginResult = await _userManager.AddLoginAsync(user, loginInfo);


        //}


        //string token = GenerateJWT(user, Role.User, _configuration["JWT:SecretKey"] ?? throw new AppException(), _configuration["JWT:ValidIssuer"] ?? throw new AppException(), _configuration["JWT:ValidAudience"] ?? throw new AppException());
        //await _unitOfWorks.SaveChangeAsync();
        //return Result.Ok(new UserToken(token, ""))
        //   .WithSuccess(new Success("Google login successful"));
        throw new NotImplementedException();
    }

    public static string GenerateJWT(User user, string userRoles, string secretKey, string issuer, string audience)
    {

        DateTime secretKeyDatetime = DateTime.UtcNow;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
            {
                new("UserId", user.Id.ToString()),
                new(ClaimTypes.Name, user.UserName ?? throw new AppException("Name not found") ),
                new (ClaimTypes.Role,userRoles),
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
