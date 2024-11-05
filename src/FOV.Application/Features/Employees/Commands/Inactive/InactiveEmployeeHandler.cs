using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Employees.Commands.Inactive;

public sealed record InactvieEmployeeCommand(string Id) : IRequest<Result<Guid>>;

public class InactiveEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<InactvieEmployeeCommand, Result<Guid>>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result<Guid>> Handle(InactvieEmployeeCommand request, CancellationToken cancellationToken)
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
        //    throw new AppException("Không thể vô hiệu hóa nhân viên", fieldErrors);
        //}

        //user.Employee.UpdateState(false);

        //_unitOfWorks.EmployeeRepository.Update(user.Employee);

        //await _userManager.SetLockoutEnabledAsync(user, true);
        //await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(10));

        //await _unitOfWorks.SaveChangeAsync();

        //return Result.Ok(user.Employee.Id);
        throw new NotImplementedException();
    }
}
