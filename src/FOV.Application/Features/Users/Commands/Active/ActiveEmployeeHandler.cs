using FluentResults;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Users.Commands.Active;
public sealed record ActiveEmployeeCommand(string Id) : IRequest<Result>;


public class ActiveEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<ActiveEmployeeCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Result> Handle(ActiveEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
           .Include(u => u.Employee)
           .FirstOrDefaultAsync(u => u.Id == request.Id);

        if (user == null)
        {
            return Result.Fail("User not found.");
        }

        if (user.Employee == null)
        {
            return Result.Fail("User does not have an associated Employee.");
        }

        user.Employee.UpdateState(false);

        _unitOfWorks.EmployeeRepository.Update(user.Employee);

        // Save changes to the database
        await _unitOfWorks.SaveChangeAsync();

        // Disable lockout and set the lockout end date to a past date
        await _userManager.SetLockoutEnabledAsync(user, false);
        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MinValue);

        return Result.Ok();
    }

}
