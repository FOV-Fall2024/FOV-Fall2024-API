using FluentResults;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Users.Queries.GetAllEmployee;

public sealed record GetAllEmployeeCommand(PagingRequest? PagingRequest, string? Role, Guid? RestaurantId, string? FirstName, string? Email, string? EmployeeCode, bool? IsDelete) : IRequest<PagedResult<GetAllEmployeeResponse>>;

public sealed record GetAllEmployeeResponse(string Id, string UserName, string FirstName, string LastName, string Email, string EmployeeCode, DateTime HireDate, string RoleName, Guid RestaurantId, bool IsDelete);

public class GetAllEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<GetAllEmployeeCommand, PagedResult<GetAllEmployeeResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<PagedResult<GetAllEmployeeResponse>> Handle(GetAllEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWorks.EmployeeRepository.GetAllAsync(x => x.User);
        if (request.RestaurantId.HasValue)
        {
            employees = employees.Where(x => x.RestaurantId == request.RestaurantId).ToList();
        }
        if (!string.IsNullOrEmpty(request.FirstName))
        {
            employees = employees.Where(x => x.User.FirstName.Contains(request.FirstName)).ToList();
        }
        // xin loi thang Filter loi nen fix chua chay phat
        var filterEntity = employees.AsQueryable().CustomFilterV1(new Employee
        {
            User = new User
            {
                FirstName = request.FirstName,
                Email = request.Email,
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
                    employee.RestaurantId,
                    employee.IsDeleted
                ));
            }
        }

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResults = PaginationHelper<GetAllEmployeeResponse>.Sorting(sortType, result, sortField);
        var pagedResult = PaginationHelper<GetAllEmployeeResponse>.Paging(sortedResults, page, pageSize);

        return pagedResult;
    }
}

