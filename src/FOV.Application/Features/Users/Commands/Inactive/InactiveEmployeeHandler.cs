using FluentResults;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Users.Commands.Inactive;
public sealed record InactvieEmployeeCommand(string Id) : IRequest<Result>;
public class InactiveEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<InactvieEmployeeCommand, Result>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(InactvieEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.Id);
        Employee employee = await _unitOfWorks.EmployeeRepository.GetByIdAsync(user.Customer.Id) ?? throw new Exception();
        employee.UpdateState(true);

        _unitOfWorks.EmployeeRepository.Update(employee);
        await _unitOfWorks.SaveChangeAsync();
        await _userManager.SetLockoutEnabledAsync(user, true);
        await _userManager.SetLockoutEndDateAsync(user, DateTime.Today.AddYears(10));
        return Result.Ok();
    }
}
