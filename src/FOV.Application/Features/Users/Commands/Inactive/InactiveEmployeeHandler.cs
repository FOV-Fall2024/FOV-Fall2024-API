using FluentResults;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Users.Commands.Inactive;
public sealed record InactvieEmployeeCommand(string Id) : IRequest<Result>;
public class InactiveEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<InactvieEmployeeCommand, Result>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(InactvieEmployeeCommand request, CancellationToken cancellationToken)
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

        await _unitOfWorks.SaveChangeAsync();
        await _userManager.SetLockoutEnabledAsync(user, true);
        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddYears(10));

        return Result.Ok();
    }

}
