using System.Text.RegularExpressions;
using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Authorize.Commands.CreateEmployee;

public sealed record CreateEmployeeCommand(string FullName, string PhoneNumber, int RoleId, Guid RestaurantId) : IRequest<Result<string>>;
public sealed record GenerateRole(string RoleName, string Code);

public partial class CreateEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager) : IRequestHandler<CreateEmployeeCommand, Result<string>>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager = roleManager;

    public async Task<Result<string>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var fieldErrors = new List<FieldError>();
        if (request.RoleId == 1)
        {
            var existingManager = await _userManager.Users
                .FirstOrDefaultAsync(u => u.RestaurantId == request.RestaurantId);

            if (existingManager != null && await _userManager.IsInRoleAsync(existingManager, Role.Manager))
            {
                fieldErrors.Add(new FieldError
                {
                    Field = "restaurantId",
                    Message = "Nhà hàng này đã tồn tại manager rồi"
                });
            }
        }

        var existingUser = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
        if (existingUser != null)
        {
            fieldErrors.Add(new FieldError
            {
                Field = "phoneNumber",
                Message = "Số điện thoại này đã được đăng kí"
            });
        }

        var roleName = UserRole(request.RoleId);
        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            fieldErrors.Add(new FieldError
            {
                Field = "roleId",
                Message = "Vai trò không tồn tại trong hệ thống"
            });
        }

        if (fieldErrors.Any())
        {
            throw new AppException("Lỗi khi tạo tài khoản nhân viên", fieldErrors);
        }

        var generate = await GenerateCode(request.RoleId);

        User user = new()
        {
            FullName = request.FullName,
            PhoneNumber = request.PhoneNumber,
            UserName = request.PhoneNumber,
        };

        var result = await _userManager.CreateAsync(user, "12345678!Fpt");
        if (!result.Succeeded)
        {
            var userErrors = result.Errors.Select(e => new FieldError
            {
                Field = "userCreation",
                Message = e.Description
            }).ToList();

            throw new AppException("Lỗi khi tạo tài khoản nhân viên", userErrors);
        }

        var roleAssignResult = await _userManager.AddToRoleAsync(user, roleName);
        if (!roleAssignResult.Succeeded)
        {
            var roleAssignErrors = roleAssignResult.Errors.Select(e => new FieldError
            {
                Field = "RoleAssignment",
                Message = e.Description
            }).ToList();

            throw new AppException("Lỗi khi gán vai trò", roleAssignErrors);
        }

        await _unitOfWorks.SaveChangeAsync();

        string message = request.RoleId switch
        {
            1 => "Tạo tài khoản quản lý thành công",
            2 => "Tạo tài khoản nhân viên thành công",
            3 => "Tạo tài khoản phụ bếp thành công",
            4 => "Tạo tài khoản bếp trưởng thành công",
            _ => "Tạo tài khoản thành công"
        };

        return Result.Ok(message);
        throw new NotImplementedException();
    }


    // 1. Manager 2.Waiter 3.Cook 4.Headchef

    public static string UserRole(int role) => role switch
    {
        1 => Role.Manager,
        2 => Role.Waiter,
        3 => Role.Chef,
        4 => Role.HeadChef,
        _ => throw new NotImplementedException(),
    };

    public static string DefaultRoleValue(int role) => role switch
    {
        1 => "MNG_001",
        2 => "WTR_001",
        3 => "CKR_001",
        4 => "HCF_001",
        _ => throw new NotImplementedException(),
    };

    public async Task<GenerateRole> GenerateCode(int roleId)
    {
        // Ensure the role exists
        if (!await _roleManager.RoleExistsAsync(UserRole(roleId)))
        {
            var roleResult = await _roleManager.CreateAsync(new IdentityRole<Guid>(roleId.ToString()));
            if (!roleResult.Succeeded)
            {
                throw new Exception("Error creating role.");
            }
        }

        await _unitOfWorks.SaveChangeAsync();

        var usersInRole = await _userManager.GetUsersInRoleAsync(UserRole(roleId));

        int count = usersInRole.Count();

        string nextEmployeeCode = DefaultRoleValue(roleId);
        if (count > 0)
        {
            nextEmployeeCode = IncrementRoleCode(DefaultRoleValue(roleId), count + 1);
        }

        return new GenerateRole(UserRole(roleId), nextEmployeeCode);
    }

    public static string IncrementRoleCode(string roleCode, int newCount)
    {
        var match = MyRegex().Match(roleCode);
        if (match.Success)
        {
            var prefix = match.Groups[1].Value;
            var incrementedNumber = newCount.ToString().PadLeft(match.Groups[2].Value.Length, '0');
            return prefix + incrementedNumber;
        }
        return roleCode;
    }


    [GeneratedRegex(@"^(.*?)(\d+)$")]
    private static partial Regex MyRegex();
}
