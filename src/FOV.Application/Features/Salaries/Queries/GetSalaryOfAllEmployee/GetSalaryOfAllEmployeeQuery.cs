﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Salaries.Commands.Create;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Salaries.Queries.GetSalaryOfAllEmployee;

public record GetSalaryOfAllEmployeeCommand(
    PagingRequest? PagingRequest,
    DateTime? ChosenDate = null,
    Guid? UserId = null
) : IRequest<PagedResult<CreateSalaryResponse>>;

public class GetSalaryOfAllEmployeeQuery(IUnitOfWorks unitOfWorks, IClaimService claimService, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager) : IRequestHandler<GetSalaryOfAllEmployeeCommand, PagedResult<CreateSalaryResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    private readonly UserManager<User> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

    public async Task<PagedResult<CreateSalaryResponse>> Handle(GetSalaryOfAllEmployeeCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        var userId = request.UserId;
        Guid? restaurantId = null;

        if (userRole == Role.Manager)
        {
            restaurantId = _claimService.RestaurantId;

            if (userId.HasValue)
            {
                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.Id == userId.Value && u.RestaurantId == restaurantId);

                if (user == null)
                    throw new AppException("Không tìm thấy nhân viên trong nhà hàng của bạn.");
            }
        }

        var chosenDate = request.ChosenDate?.ToUniversalTime() ?? DateTime.UtcNow;

        var startDate = new DateTime(chosenDate.Year, chosenDate.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = startDate.AddMonths(1).AddDays(-1);

        var existingSalaries = await _unitOfWorks.WaiterSalaryRepository
            .WhereAsync(ws => ws.PayDate >= startDate && ws.PayDate <= endDate
                            && (!userId.HasValue || ws.UserId == userId)
                            && (!restaurantId.HasValue || ws.User.RestaurantId == restaurantId), x => x.User);

        var usersQuery = _userManager.Users.AsQueryable();

        if (restaurantId.HasValue)
            usersQuery = usersQuery.Where(u => u.RestaurantId == restaurantId);

        if (userId.HasValue)
            usersQuery = usersQuery.Where(u => u.Id == userId);

        var users = await usersQuery.ToListAsync(cancellationToken);

        if (!users.Any())
            throw new AppException("Không tìm thấy nhân viên phù hợp.");

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Any())
                throw new AppException($"Người dùng {user.FullName} chưa được gán vai trò nào.");

            var roleName = roles.First();
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                throw new AppException($"Không tìm thấy thông tin vai trò cho {user.FullName}.");

            var hourlyRate = role.RoleSalary;

            var attendances = await _unitOfWorks.AttendanceRepository
                .WhereAsync(a => a.CheckInTime >= startDate && a.CheckInTime <= endDate
                                && a.WaiterSchedule.UserId == user.Id);

            if (!attendances.Any())
                continue;

            const int shiftHours = 5;
            var totalShifts = attendances.Count();
            var totalHoursWorked = attendances
                .Sum(a => (a.CheckOutTime - a.CheckInTime)?.TotalHours ?? 0);
            var totalStandardHours = totalShifts * shiftHours;
            var overtimeHours = Math.Max(0, totalHoursWorked - totalStandardHours);
            var penaltyHours = Math.Max(0, totalStandardHours - totalHoursWorked);

            var regularSalary = (decimal)totalHoursWorked * hourlyRate;
            var overtimeSalary = (decimal)overtimeHours * hourlyRate * 1.5m;
            var penalty = (decimal)penaltyHours * hourlyRate;
            var totalSalary = regularSalary + overtimeSalary - penalty;

            var waiterSalary = existingSalaries.FirstOrDefault(ws => ws.UserId == user.Id);

            if (waiterSalary != null)
            {
                waiterSalary.TotalShifts = totalShifts;
                waiterSalary.TotalHoursWorked = (decimal)totalHoursWorked;
                waiterSalary.ActualHoursWorked = (decimal)(totalHoursWorked + overtimeHours - penaltyHours);
                waiterSalary.RegularSalary = regularSalary;
                waiterSalary.OvertimeSalary = overtimeSalary;
                waiterSalary.Penalty = penalty;
                waiterSalary.TotalSalaries = totalSalary;
                waiterSalary.Status = "Pending";
            }
            else
            {
                waiterSalary = new WaiterSalary
                {
                    UserId = user.Id,
                    TotalShifts = totalShifts,
                    TotalHoursWorked = (decimal)totalHoursWorked,
                    ActualHoursWorked = (decimal)(totalHoursWorked + overtimeHours - penaltyHours),
                    RegularSalary = regularSalary,
                    OvertimeSalary = overtimeSalary,
                    Penalty = penalty,
                    TotalSalaries = totalSalary,
                    PayDate = endDate,
                    Status = "Pending"
                };
                await _unitOfWorks.WaiterSalaryRepository.AddAsync(waiterSalary);
            }
        }

        await _unitOfWorks.SaveChangeAsync();

        var query = await _unitOfWorks.WaiterSalaryRepository
            .WhereAsync(ws => ws.PayDate >= startDate && ws.PayDate <= endDate
                            && (!userId.HasValue || ws.UserId == userId)
                            && (!restaurantId.HasValue || ws.User.RestaurantId == restaurantId), x => x.User);

        var mappedResult = query.Select(ws => new CreateSalaryResponse(
                ws.Id,
                ws.User.EmployeeCode,
                ws.User.FullName,
                new CreateSalaryDto(
                    ws.TotalShifts,
                    ws.TotalHoursWorked,
                    ws.ActualHoursWorked,
                    ws.RegularSalary,
                    ws.OvertimeSalary,
                    ws.Penalty,
                    ws.TotalSalaries
                ),
                ws.Created
            ))
            .ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<CreateSalaryResponse>.Sorting(sortType, mappedResult, sortField);
        var result = PaginationHelper<CreateSalaryResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}