using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Users.Queries.GetAllEmployee;
public sealed record GetAllEmployeeCommand(string? Role, string? UserName, string? FirstName, string? LastName, string? Email, string? EmployeeCode) : IRequest<List<GetAllEmployeeResponse>>;

public sealed record GetAllEmployeeResponse(string Id, string UserName, string FirstName, string LastName, string Email, string EmployeeCode, DateTime HireDate, string roleName);
public class GetAllEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<GetAllEmployeeCommand, List<GetAllEmployeeResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    private readonly UserManager<User> _userManager = userManager;
    public async Task<List<GetAllEmployeeResponse>> Handle(GetAllEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWorks.EmployeeRepository.GetAllAsync(x => x.User);

        // Filter the employees based on the request parameters
        var filteredEmployees = employees
            .Where(x =>
                (string.IsNullOrEmpty(request.UserName) || x.User.UserName.Contains(request.UserName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(request.FirstName) || x.User.FirstName.Contains(request.FirstName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(request.LastName) || x.User.LastName.Contains(request.LastName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(request.Email) || x.User.Email.Contains(request.Email, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(request.EmployeeCode) || x.EmployeeCode.Contains(request.EmployeeCode, StringComparison.OrdinalIgnoreCase))
            )
            .Select(x => new GetAllEmployeeResponse(
                x.User.Id,
                x.User.UserName,
                x.User.FirstName,
                x.User.LastName,
                x.User.Email,
                x.EmployeeCode,
                x.HireDate,
               _userManager.GetRolesAsync(x.User).Result.First()
            ))
            .ToList();

        return filteredEmployees;
    }
}
