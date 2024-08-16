using System.Text.RegularExpressions;
using FluentResults;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Authorize.Commands.CreateEmployee;

public sealed record CreateEmployeeCommand(string LastName, string FirstName, string Address, string Email, int RoleId, Guid RestaurantId) : IRequest<Result>;
public sealed record GenerateRole(string RoleName, string Code);

public partial class CreateEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, RoleManager<IdentityRole> roleManager) : IRequestHandler<CreateEmployeeCommand, Result>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;

    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var generate = await GenerateCode(request.RoleId);

        User user = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Email
        };

        var result = await _userManager.CreateAsync(user, "12345678!Fpt");
        if (!result.Succeeded) throw new KeyNotFoundException(result.Errors.First().Description);

        if (!await _roleManager.RoleExistsAsync(generate.RoleName))
        {
            var roleResult = await _roleManager.CreateAsync(new IdentityRole(generate.RoleName));
            if (!roleResult.Succeeded) throw new KeyNotFoundException(roleResult.Errors.First().Description);
        }

        var roleAssignResult = await _userManager.AddToRoleAsync(user, generate.RoleName);
        if (!roleAssignResult.Succeeded)
        {
            return Result.Fail(roleAssignResult.Errors.First().Description);
        }

        Employee employee = new(generate.Code, user.Id, request.RestaurantId);

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
        var match = MyRegex().Match(roleCode);
        if (match.Success)
        {
            var prefix = match.Groups[1].Value;
            var numberPart = match.Groups[2].Value;
            var incrementedNumber = (int.Parse(numberPart) + 1).ToString().PadLeft(numberPart.Length, '0');
            return prefix + incrementedNumber;
        }
        return roleCode;
    }

    [GeneratedRegex(@"^(.*?)(\d+)$")]
    private static partial Regex MyRegex();
}
