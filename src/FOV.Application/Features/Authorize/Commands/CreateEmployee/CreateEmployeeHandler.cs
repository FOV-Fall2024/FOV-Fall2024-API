using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using FluentResults;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Authorize.Commands.CreateEmployee;

//
public sealed record CreateEmployeeCommand(string LastName, string FirstName, string Address, string Email, int RoleId, Guid RestaurantId) : IRequest<Result>;
public sealed record GenerateRole(string RoleName, string Code);

public class CreateEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<CreateEmployeeCommand, Result>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // Generate the role-specific code
        var generate = await GenerateCode(request.RoleId);

        // Create a new user with the provided details
        User user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Email // Ensure UserName is set, as it's required for UserManager
        };

        // Attempt to create the user
        var result = await _userManager.CreateAsync(user, "12345678!Fpt");
        if (!result.Succeeded)
        {
            return Result.Fail(result.Errors.First().Description);
        }

        // Ensure the role exists
        if (!await _roleManager.RoleExistsAsync(generate.RoleName))
        {
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(generate.RoleName));
            if (!roleResult.Succeeded)
            {
                return Result.Fail(roleResult.Errors.First().Description);
            }
        }

        // Assign the role to the user
        var roleAssignResult = await _userManager.AddToRoleAsync(user, generate.RoleName);
        if (!roleAssignResult.Succeeded)
        {
            return Result.Fail(roleAssignResult.Errors.First().Description);
        }

        // Create an Employee entity associated with the user
        Employee employee = new(generate.Code, user.Id, request.RestaurantId);

        // Add the Employee entity to the repository and save changes
        await _unitOfWorks.EmployeeRepository.AddAsync(employee);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }

    // 1. Manager 2.Waiter 3.Cook

    public static string UserRole(int role) => role switch
    {
        1 => Role.Manager,
        2 => Role.Waiter,
        3 => Role.Cook,
        _ => throw new NotImplementedException(),
    };

    public static string DefaultRoleValue(int role) => role switch
    {
        1 => "MNG_001",
        2 => "WTR_001",
        3 => "CKR_001",
        _ => throw new NotImplementedException(),
    };

    public async Task<GenerateRole> GenerateCode(int roleId)
    {
        if (!await _roleManager.RoleExistsAsync(UserRole(roleId)))
        {
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(UserRole(roleId)));
            if (!roleResult.Succeeded)
            {
                throw new Exception();
            }

        }
        await _unitOfWorks.SaveChangeAsync();

        var users = await _userManager.GetUsersInRoleAsync(UserRole(roleId));
        return users.Count == 0
            ? new GenerateRole(UserRole(roleId), DefaultRoleValue(roleId))
            : new GenerateRole(UserRole(roleId), IncrementRoleCode(users.FirstOrDefault().Employee.EmployeeCode));

    }


    public static string IncrementRoleCode(string roleCode)
    {
        // Match the prefix and the numeric part separately
        var match = Regex.Match(roleCode, @"^(.*?)(\d+)$");
        if (match.Success)
        {
            var prefix = match.Groups[1].Value;
            var numberPart = match.Groups[2].Value;

            // Convert the numeric part to an integer, increment it, and format it back to the original length
            var incrementedNumber = (int.Parse(numberPart) + 1).ToString().PadLeft(numberPart.Length, '0');

            // Concatenate the prefix and the incremented number
            return prefix + incrementedNumber;
        }

        // If the role code doesn't match the expected pattern, return it as is
        return roleCode;
    }
}
