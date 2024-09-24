using FluentResults;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Users.Queries.GetAllEmployee;

public sealed record GetAllEmployeeCommand(PagingRequest? PagingRequest, string? Role, Guid? RestaurantId, string? FirstName, string? Email, string? EmployeeCode, Status? Status = Status.Unknown) : IRequest<PagedResult<GetAllEmployeeResponse>>;

public sealed record GetAllEmployeeResponse(string Id, string UserName, string FirstName, string LastName, string Email, string EmployeeCode, DateTime HireDate, string RoleName, Guid RestaurantId, Status Status, DateTimeOffset Created);

public class GetAllEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<GetAllEmployeeCommand, PagedResult<GetAllEmployeeResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<PagedResult<GetAllEmployeeResponse>> Handle(GetAllEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employees = await _unitOfWorks.EmployeeRepository.GetAllAsync(x => x.User);
        var employeesQuery = employees.AsQueryable();

        if (request.RestaurantId.HasValue)
        {
            employeesQuery = employeesQuery.Where(x => x.RestaurantId == request.RestaurantId);
        }

        if (!string.IsNullOrEmpty(request.FirstName))
        {
            employeesQuery = employeesQuery.Where(x => x.User.FirstName.ToLower().Contains(request.FirstName.ToLower()));
        }

        var filterEntity = employeesQuery.CustomFilterV1(new Employee
        {
            User = new User
            {
                FirstName = request.FirstName,
                Email = request.Email,
            },
            EmployeeCode = request.EmployeeCode ?? string.Empty,
            Status = request.Status ?? Status.Unknown 
        });

        var result = new List<GetAllEmployeeResponse>();

        foreach (var employee in filterEntity)
        {
            var roles = await _userManager.GetRolesAsync(employee.User);
            var roleName = roles.FirstOrDefault() ?? string.Empty;

            // Only include if the role matches or no specific role is requested
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
                    employee.Status,
                    employee.Created
                ));
            }
        }

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        sortType = Domain.Common.SortOrder.Descending;

        var sortedResults = PaginationHelper<GetAllEmployeeResponse>.Sorting(sortType, result, sortField = "HireDate");
        var pagedResult = PaginationHelper<GetAllEmployeeResponse>.Paging(sortedResults, page, pageSize);

        return pagedResult;
    }

}

