using FluentResults;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Users.Commands.Active;
public sealed record ActiveEmployeeCommand(string Id) : IRequest<Result>;


public class ActiveEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<ActiveEmployeeCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Result> Handle(ActiveEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);
        Employee employee = await _unitOfWorks.EmployeeRepository.GetByIdAsync(user.Customer.Id) ?? throw new Exception("Không tìm thấy nhân viên");

        employee.UpdateState(false);
        _unitOfWorks.EmployeeRepository.Update(employee);

        // Save changes to the database
        await _unitOfWorks.SaveChangeAsync();

        // Disable lockout and set the lockout end date to a past date
        await _userManager.SetLockoutEnabledAsync(user, false);
        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MinValue);

        return Result.Ok();
    }

}
