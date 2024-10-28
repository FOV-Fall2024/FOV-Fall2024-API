using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Employees.Commands.Active;

public sealed record ActiveEmployeeCommand(string Id) : IRequest<Result<Guid>>;

public class ActiveEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<ActiveEmployeeCommand, Result<Guid>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Result<Guid>> Handle(ActiveEmployeeCommand request, CancellationToken cancellationToken)
    {
        //var fieldErrors = new List<FieldError>();

        //var user = await _userManager.Users
        //    .Include(u => u.Employee)
        //    .FirstOrDefaultAsync(u => u.Id == request.Id);

        //if (user == null)
        //{
        //    fieldErrors.Add(new FieldError
        //    {
        //        Field = "userId",
        //        Message = "Không tìm thấy người dùng."
        //    });
        //}

        //if (user?.Employee == null)
        //{
        //    fieldErrors.Add(new FieldError
        //    {
        //        Field = "employee",
        //        Message = "Người dùng không có nhân viên liên quan."
        //    });
        //}

        //if (fieldErrors.Any())
        //{
        //    throw new AppException("Không thể kích hoạt nhân viên", fieldErrors);
        //}

        //user.Employee.UpdateState(true); // Activate the employee

        //_unitOfWorks.EmployeeRepository.Update(user.Employee);

        //await _userManager.SetLockoutEnabledAsync(user, false);
        //await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MinValue); // Remove lockout

        //await _unitOfWorks.SaveChangeAsync();

        //return Result.Ok(user.Employee.Id);
        throw new NotImplementedException();
    }
}
