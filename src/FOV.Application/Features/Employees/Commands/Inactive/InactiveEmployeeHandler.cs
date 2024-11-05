using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Employees.Commands.Inactive;

public sealed record InactvieEmployeeCommand(Guid Id) : IRequest<Result<Guid>>;

public class InactiveEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<InactvieEmployeeCommand, Result<Guid>>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result<Guid>> Handle(InactvieEmployeeCommand request, CancellationToken cancellationToken)
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
            throw new AppException("Không thể vô hiệu hóa nhân viên", fieldErrors);
        }

        user.UpdateState(false);

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

        await _userManager.SetLockoutEnabledAsync(user, true);
        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(10));

        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok(user.Id);
    }
}
