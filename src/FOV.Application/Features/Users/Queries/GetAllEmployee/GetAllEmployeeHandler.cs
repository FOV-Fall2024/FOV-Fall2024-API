using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Users.Queries.GetAllEmployee;

public sealed record GetAllEmployeeCommand(string? Role, Guid? RestaurantId, string? UserName, string? FirstName, string? LastName, string? Email, string? EmployeeCode) : IRequest<List<GetAllEmployeeResponse>>;

public sealed record GetAllEmployeeResponse(string Id, string UserName, string FirstName, string LastName, string Email, string EmployeeCode, DateTime HireDate, string RoleName, Guid RestaurantId);

public class GetAllEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<GetAllEmployeeCommand, List<GetAllEmployeeResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<List<GetAllEmployeeResponse>> Handle(GetAllEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWorks.EmployeeRepository.GetAllAsync(x => x.User);
        if (request.RestaurantId.HasValue)
        {
            employees = employees.Where(x => x.RestaurantId == request.RestaurantId).ToList();
        }

        var filterEntity = employees.AsQueryable().CustomFilterV1(new Employee
        {
            User = new User
            {
                UserName = request.UserName ?? string.Empty,
                FirstName = request.FirstName ?? string.Empty,
                LastName = request.LastName ?? string.Empty,
                Email = request.Email ?? string.Empty,
            },
            EmployeeCode = request.EmployeeCode ?? string.Empty,
        });

        var result = new List<GetAllEmployeeResponse>();

        foreach (var employee in filterEntity)
        {
            var roles = await _userManager.GetRolesAsync(employee.User);
            var roleName = roles.FirstOrDefault() ?? string.Empty;

            if (string.IsNullOrEmpty(request.Role) || roles.Contains(request.Role))
            {
                result.Add(new GetAllEmployeeResponse(
                    employee.User.Id,
                    employee.User.UserName,
                    employee.User.FirstName,
                    employee.User.LastName,
                    employee.User.Email,
                    employee.EmployeeCode,
                    employee.HireDate,
                    roleName,
                    employee.RestaurantId
                ));
            }
        }

        return result;
    }
}
