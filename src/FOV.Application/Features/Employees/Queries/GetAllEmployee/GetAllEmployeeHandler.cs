﻿using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.Users.Responses;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Employees.Queries.GetAllEmployee;

public sealed record GetAllEmployeeCommand(PagingRequest? PagingRequest, string? Role, Guid? RestaurantId, string? FullName, string? PhoneNumber, string? EmployeeCode, Status? Status = Status.Unknown) : IRequest<PagedResult<GetAllEmployeeResponse>>;

public class GetAllEmployeeHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, IClaimService claimService) : IRequestHandler<GetAllEmployeeCommand, PagedResult<GetAllEmployeeResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IClaimService _claimService = claimService;

    public async Task<PagedResult<GetAllEmployeeResponse>> Handle(GetAllEmployeeCommand request, CancellationToken cancellationToken)
    {
        var userRoles = _claimService.UserRole;
        var restaurantId = _claimService.RestaurantId;

        var users = _userManager.Users;
        var usersQuery = users.AsQueryable();

        if (userRoles.Contains(Role.Manager))
        {
            usersQuery = usersQuery.Where(x => x.RestaurantId == restaurantId);
        }

        if (request.RestaurantId.HasValue)
        {
            usersQuery = usersQuery.Where(x => x.RestaurantId == request.RestaurantId);
        }

        if (!string.IsNullOrEmpty(request.FullName))
        {
            // Concatenate FirstName and LastName to form FullName and make it case-insensitive
            var fullName = request.FullName.ToLower();
            usersQuery = usersQuery.Where(x =>
                (x.FullName).ToLower().Contains(fullName));
        }

        var filterEntity = usersQuery.CustomFilterV1(new User
        {
            PhoneNumber = request.PhoneNumber,
            EmployeeCode = request.EmployeeCode ?? string.Empty,
            Status = request.Status ?? Status.Unknown
        });

        var result = new List<GetAllEmployeeResponse>();

        foreach (var user in filterEntity)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleName = roles.FirstOrDefault() ?? string.Empty;

            if (roleName == Role.Administrator)
            {
                continue;
            }

            // Only include if the role matches or no specific role is requested
            if (string.IsNullOrEmpty(request.Role) || roles.Contains(request.Role))
            {
                result.Add(new GetAllEmployeeResponse(
                    user.Id,
                    user.FullName,
                    user.PhoneNumber,
                    user.EmployeeCode,
                    user.HireDate ?? DateTime.Now,
                    roleName,
                    user.Restaurant?.RestaurantName ?? string.Empty,
                    user.Status
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

