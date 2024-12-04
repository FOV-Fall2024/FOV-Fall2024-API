using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Salaries.Commands.Create;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Salaries.Queries.GetSalaryOfEmployee;
public record GetSalaryOfEmployeeCommand(DateTime? ChosenDate = null) : IRequest<CreateSalaryResponse>;
public class GetSalaryOfEmployeeQuery(IUnitOfWorks unitOfWorks, IClaimService claimService, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager) : IRequestHandler<GetSalaryOfEmployeeCommand, CreateSalaryResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    private readonly UserManager<User> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

    public async Task<CreateSalaryResponse> Handle(GetSalaryOfEmployeeCommand request, CancellationToken cancellationToken)
    {
        var userId = _claimService.UserId;
        var employee = await _userManager.FindByIdAsync(userId.ToString())
            ?? throw new AppException("Employee not found");

        var roles = await _userManager.GetRolesAsync(employee);
        if (!roles.Any())
            throw new AppException("Employee has no assigned roles.");

        var roleName = roles.First();
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
            throw new AppException("Không tìm thấy thông tin vai trò.");

        var hourlyRate = role.RoleSalary;

        var currentDate = request.ChosenDate?.ToUniversalTime() ?? DateTime.UtcNow;
        var startDate = new DateTime(currentDate.Year, currentDate.Month, 1).ToUniversalTime();
        var endDate = startDate.AddMonths(1).AddDays(-1).ToUniversalTime();

        var existingSalary = await _unitOfWorks.WaiterSalaryRepository
            .WhereAsync(ws => ws.PayDate >= startDate && ws.PayDate <= endDate && ws.UserId == userId);

        if (existingSalary.Any())
        {
            var salary = existingSalary.First();
            var attendances = await _unitOfWorks.AttendanceRepository.WhereAsync(a => a.CheckInTime >= startDate && a.CheckInTime <= endDate && a.WaiterSchedule.UserId == userId);

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

            salary.TotalShifts = totalShifts;
            salary.TotalHoursWorked = (decimal)totalHoursWorked;
            salary.ActualHoursWorked = (decimal)(totalHoursWorked + overtimeHours - penaltyHours);
            salary.RegularSalary = regularSalary;
            salary.OvertimeSalary = overtimeSalary;
            salary.Penalty = penalty;
            salary.TotalSalaries = totalSalary;

            await _unitOfWorks.SaveChangeAsync();

            return new CreateSalaryResponse(
                employee.Id,
                employee.EmployeeCode,
                employee.FullName,
                new CreateSalaryDto(
                    totalShifts,
                    (decimal)totalHoursWorked,
                    (decimal)(totalHoursWorked + overtimeHours - penaltyHours),
                    regularSalary,
                    overtimeSalary,
                    penalty,
                    totalSalary
                ),
                salary.Created
            );
        }

        var attendancesNew = await _unitOfWorks.AttendanceRepository.WhereAsync(a => a.CheckInTime >= startDate && a.CheckInTime <= endDate && a.WaiterSchedule.UserId == userId);

        if (!attendancesNew.Any())
            throw new AppException("No attendance data found for this employee this month.");

        const int shiftHoursNew = 5;
        var totalShiftsNew = attendancesNew.Count();
        var totalHoursWorkedNew = attendancesNew
            .Sum(a => (a.CheckOutTime - a.CheckInTime)?.TotalHours ?? 0);
        var totalStandardHoursNew = totalShiftsNew * shiftHoursNew;
        var overtimeHoursNew = Math.Max(0, totalHoursWorkedNew - totalStandardHoursNew);
        var penaltyHoursNew = Math.Max(0, totalStandardHoursNew - totalHoursWorkedNew);

        var regularSalaryNew = (decimal)totalHoursWorkedNew * hourlyRate;
        var overtimeSalaryNew = (decimal)overtimeHoursNew * hourlyRate * 1.5m;
        var penaltyNew = (decimal)penaltyHoursNew * hourlyRate;
        var totalSalaryNew = regularSalaryNew + overtimeSalaryNew - penaltyNew;

        var salaryResponse = new CreateSalaryResponse(
            employee.Id,
            employee.EmployeeCode,
            employee.FullName,
            new CreateSalaryDto(
                totalShiftsNew,
                (decimal)totalHoursWorkedNew,
                (decimal)(totalHoursWorkedNew + overtimeHoursNew - penaltyHoursNew),
                regularSalaryNew,
                overtimeSalaryNew,
                penaltyNew,
                totalSalaryNew
            ),
            DateTime.UtcNow.ToUniversalTime()
        );

        var waiterSalary = new WaiterSalary
        {
            UserId = employee.Id,
            TotalShifts = totalShiftsNew,
            TotalHoursWorked = (decimal)totalHoursWorkedNew,
            ActualHoursWorked = (decimal)(totalHoursWorkedNew + overtimeHoursNew - penaltyHoursNew),
            RegularSalary = regularSalaryNew,
            OvertimeSalary = overtimeSalaryNew,
            Penalty = penaltyNew,
            TotalSalaries = totalSalaryNew,
            PayDate = endDate,
            Status = "Pending"
        };

        await _unitOfWorks.WaiterSalaryRepository.AddAsync(waiterSalary);
        await _unitOfWorks.SaveChangeAsync();

        return salaryResponse;
    }
}
