using System;
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
public record CreateSalaryResponse(Guid Id, string EmployeeCode, string EmployeeName, CreateSalaryDto Salary, DateTime CreatedDate);
public record CreateSalaryDto(decimal TotalShifts, decimal TotalHoursWorked, double ActualHoursWorked, decimal RegularSalary, decimal OvertimeSalary, decimal Penalty, decimal TotalSalaries, double OvertimeHours, decimal PenaltyHours, List<AttendanceDetailsDto> AttendanceDetailsDtos);
public record AttendanceDetailsDto(DateOnly Date, string ShiftName, string CheckInTime, string CheckOutTime);
public class GetSalaryOfAllEmployeeQuery(IUnitOfWorks unitOfWorks, IClaimService claimService, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager) : IRequestHandler<GetSalaryOfAllEmployeeCommand, PagedResult<CreateSalaryResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    private readonly UserManager<User> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

    public async Task<PagedResult<CreateSalaryResponse>> Handle(GetSalaryOfAllEmployeeCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        var userId = request.UserId ?? _claimService.UserId;
        Guid? restaurantId = null;

        if (userRole == Role.Waiter || userRole == Role.Chef)
        {
            var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
            if (currentUser == null)
                throw new AppException("Không tìm thấy thông tin nhân viên.");

            var roles = await _userManager.GetRolesAsync(currentUser);
            if (!roles.Contains(userRole.ToString()))
                throw new AppException($"Người dùng không có vai trò {userRole}.");

            request = request with { UserId = userId };
        }
        else if (userRole == Role.Manager)
        {
            restaurantId = _claimService.RestaurantId;
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == userId && u.RestaurantId == restaurantId);

            if (user == null)
                throw new AppException("Không tìm thấy nhân viên trong nhà hàng của bạn.");
        }

        var chosenDate = request.ChosenDate?.ToUniversalTime() ?? DateTime.UtcNow;
        var startDate = new DateTime(chosenDate.Year, chosenDate.Month, 1, 0, 0, 0, DateTimeKind.Utc);
        var endDate = startDate.AddMonths(1).AddDays(-1);

        var usersQuery = _userManager.Users.AsQueryable();

        if (restaurantId.HasValue)
            usersQuery = usersQuery.Where(u => u.RestaurantId == restaurantId);

        if (request.UserId.HasValue)
            usersQuery = usersQuery.Where(u => u.Id == request.UserId);

        usersQuery = usersQuery.Where(u => !u.EmployeeCode.StartsWith("MNG_") && !u.EmployeeCode.StartsWith("HCF_"));

        var users = await usersQuery.ToListAsync();

        if (!users.Any())
            throw new AppException("Không tìm thấy nhân viên phù hợp.");

        var mappedResult = new List<CreateSalaryResponse>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Any())
                throw new AppException($"Người dùng {user.FullName} chưa được gán vai trò nào.");

            var roleName = roles.First();
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                throw new AppException($"Không tìm thấy thông tin vai trò cho {user.FullName}.");

            // **Lấy hourlyRate từ Role của nhân viên**
            var hourlyRate = role.RoleSalary;

            var schedules = await _unitOfWorks.WaiterScheduleRepository
                .WhereAsync(ws => ws.DateTime >= DateOnly.FromDateTime(startDate)
                                  && ws.DateTime <= DateOnly.FromDateTime(endDate)
                                  && ws.UserId == user.Id, x => x.Shift);

            var attendances = await _unitOfWorks.AttendanceRepository
                .WhereAsync(a => a.CheckInTime >= startDate && a.CheckInTime <= endDate
                                && a.WaiterSchedule.UserId == user.Id, x => x.WaiterSchedule.Shift);

            const int shiftHours = 5;
            var penalty = 0m;

            var validAttendances = attendances.Where(a => a.CheckOutTime != null).ToList();
            var onlyCheckInAttendances = attendances.Where(a => a.CheckInTime != null && a.CheckOutTime == null).ToList();
            var missingSchedules = schedules
                .Where(s => !attendances.Any(a => a.WaiterScheduleId == s.Id))
                .Select(ms =>
                {
                    var isFutureSchedule = ms.DateTime.ToDateTime(new TimeOnly()) > DateTime.UtcNow;
                    if (!isFutureSchedule)
                    {
                        penalty += shiftHours * hourlyRate; // Áp dụng phạt cho các ca thuộc quá khứ
                    }

                    return new AttendanceDetailsDto(
                        Date: ms.DateTime,
                        ShiftName: ms.Shift.ShiftName,
                        CheckInTime: "Không có CheckIn",
                        CheckOutTime: isFutureSchedule ? "Lịch sắp tới" : "Không có CheckOut"
                    );
                }).ToList();

            var totalEmployeeHoursWorked = validAttendances
                .Sum(a => (a.CheckOutTime - a.CheckInTime)?.TotalHours ?? 0);

            var totalBaseHours = validAttendances.Count * shiftHours;
            var overtimeHours = Math.Max(0, totalEmployeeHoursWorked - totalBaseHours);
            var baseSalary = (decimal)totalEmployeeHoursWorked * hourlyRate;
            var overtimeSalary = (decimal)overtimeHours * hourlyRate * 1.5m;
            var totalSalary = baseSalary + overtimeSalary - penalty;

            var attendanceDetailsDtos = validAttendances.Select(a => new AttendanceDetailsDto(
                    Date: a.WaiterSchedule.DateTime,
                    ShiftName: a.WaiterSchedule.Shift.ShiftName,
                    CheckInTime: a.CheckInTime?.ToString() ?? "Chưa thực hiện CheckIn",
                    CheckOutTime: a.CheckOutTime?.ToString() ?? "Chưa thực hiện CheckOut"
                )).ToList();

            attendanceDetailsDtos.AddRange(onlyCheckInAttendances.Select(a => new AttendanceDetailsDto(
                Date: a.WaiterSchedule.DateTime,
                ShiftName: a.WaiterSchedule.Shift.ShiftName,
                CheckInTime: a.CheckInTime?.ToString() ?? "Chưa thực hiện CheckIn",
                CheckOutTime: "Chưa thực hiện CheckOut"
            )));

            attendanceDetailsDtos.AddRange(missingSchedules);

            mappedResult.Add(new CreateSalaryResponse(
                user.Id,
                user.EmployeeCode,
                user.FullName,
                new CreateSalaryDto(
                    TotalShifts: validAttendances.Count,
                    TotalHoursWorked: totalBaseHours,
                    ActualHoursWorked: totalEmployeeHoursWorked,
                    RegularSalary: baseSalary,
                    OvertimeSalary: overtimeSalary,
                    Penalty: penalty,
                    TotalSalaries: totalSalary,
                    OvertimeHours: overtimeHours,
                    PenaltyHours: penalty / hourlyRate,
                    AttendanceDetailsDtos: attendanceDetailsDtos
                ),
                DateTime.UtcNow
            ));
        }
        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<CreateSalaryResponse>.Sorting(sortType, mappedResult, sortField);
        var result = PaginationHelper<CreateSalaryResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
