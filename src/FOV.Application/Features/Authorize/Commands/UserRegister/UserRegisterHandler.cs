using FluentResults;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Authorize.Commands.UserRegister;

public sealed record UserRegisterCommand(string Email, string LastName, string FirstName, string Password, string Address) : IRequest<Result>;

public class UserRegisterHandler(UserManager<User> userManager, IUnitOfWorks unitOfWorks, RoleManager<IdentityRole> roleManager) : IRequestHandler<UserRegisterCommand, Result>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    public async Task<Result> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
    {
        User user = new()
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return Result.Fail(result.Errors.First().Description);
        }

        // Ensure the role exists
        if (!await _roleManager.RoleExistsAsync(Role.User))
        {
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(Role.User));
            if (!roleResult.Succeeded)
            {
                return Result.Fail(roleResult.Errors.First().Description);
            }
        }

        // Assign the role to the user
        var roleAssignResult = await _userManager.AddToRoleAsync(user, Role.User);
        if (!roleAssignResult.Succeeded)
        {
            return Result.Fail(roleAssignResult.Errors.First().Description);
        }

        // Save changes to ensure the user and role assignment are committed
        await _unitOfWorks.SaveChangeAsync();

        // Create a customer associated with the user
        Customer customer = new()
        {
            Address = request.Address,
            UserId = user.Id
        };

        await _unitOfWorks.CustomerRepository.AddAsync(customer);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();

    }
}
