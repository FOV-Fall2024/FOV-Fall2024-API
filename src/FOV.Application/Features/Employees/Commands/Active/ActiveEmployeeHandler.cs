using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Employees.Commands.Active;

public sealed record ActiveEmployeeCommand(Guid Id) : IRequest<Result<Guid>>;

public class ActiveEmployeeHandler(UserManager<User> userManager) : IRequestHandler<ActiveEmployeeCommand, Result<Guid>>
{
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Result<Guid>> Handle(ActiveEmployeeCommand request, CancellationToken cancellationToken)
    {
        var fieldErrors = new List<FieldError>();

        var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.Id == request.Id);

        if (user == null)
        {
            fieldErrors.Add(new FieldError
            {
                Field = "userId",
                Message = "Không tìm thấy người dùng."
            });
        }

        if (fieldErrors.Any())
        {
            throw new AppException("Không thể kích hoạt nhân viên", fieldErrors);
        }

        user.UpdateState(true);

        var updateResult = await _userManager.UpdateAsync(user);
        if (!updateResult.Succeeded)
        {
            fieldErrors.AddRange(updateResult.Errors.Select(e => new FieldError
            {
                Field = "Update",
                Message = e.Description
            }));
            throw new AppException("Cập nhật trạng thái người dùng thất bại", fieldErrors);
        }

        await _userManager.SetLockoutEnabledAsync(user, false);
        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MinValue);

        return Result.Ok(user.Id);
    }
}
