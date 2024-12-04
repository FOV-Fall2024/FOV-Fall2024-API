using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.WaiterSalaryAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Salaries.Commands.Create;
public record CreateSalaryCommand(Guid UserId) : IRequest<CreateSalaryResponse>;
public record CreateSalaryResponse(Guid Id, string EmployeeCode, string EmployeeName, CreateSalaryDto Salary, DateTime CreatedDate);
public record CreateSalaryDto(decimal TotalShifts, decimal TotalHoursWorked, decimal ActualHoursWorked, decimal RegularSalary, decimal OvertimeSalary, decimal Penalty, decimal TotalSalaries);
public class CreateSalaryHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager) : IRequestHandler<CreateSalaryCommand, CreateSalaryResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    public async Task<CreateSalaryResponse> Handle(CreateSalaryCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString())
            ?? throw new AppException("Không tìm thấy nhân viên này");

        var roles = await _userManager.GetRolesAsync(user);
        if (!roles.Any())
            throw new AppException("Người dùng chưa được gán vai trò nào.");

        var roleName = roles.First();
        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
            throw new AppException("Không tìm thấy thông tin vai trò.");

        var hourlyRate = role.RoleSalary;

        var currentDate = DateTime.UtcNow;
        var startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
        var endDate = startDate.AddMonths(1).AddDays(-1);

        var attendances = await _unitOfWorks.AttendanceRepository
            .WhereAsync(a => a.CheckInTime >= startDate && a.CheckInTime <= endDate && a.WaiterSchedule.UserId == request.UserId);

        if (!attendances.Any())
            throw new AppException("Không tìm thấy dữ liệu điểm danh trong tháng này.");

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

        var waiterSalary = new WaiterSalary
        {
            UserId = user.Id,
            TotalShifts = totalShifts,
            TotalHoursWorked = (decimal)totalHoursWorked,
            ActualHoursWorked = (decimal)(totalHoursWorked + overtimeHours - penaltyHours),
            RegularSalary = regularSalary,
            OvertimeSalary = overtimeSalary,
            Penalty = penalty,
            TotalSalaries = totalSalary,
            PayDate = DateTime.UtcNow,
            Status = "Pending"
        };

        await _unitOfWorks.WaiterSalaryRepository.AddAsync(waiterSalary);
        await _unitOfWorks.SaveChangeAsync();

        var response = new CreateSalaryResponse(
            waiterSalary.Id,
            user.EmployeeCode,
            user.FullName,
            new CreateSalaryDto(
                waiterSalary.TotalShifts,
                waiterSalary.TotalHoursWorked,
                waiterSalary.ActualHoursWorked,
                waiterSalary.RegularSalary,
                waiterSalary.OvertimeSalary,
                waiterSalary.Penalty,
                waiterSalary.TotalSalaries
            ),
            waiterSalary.Created
        );

        return response;
    }
}
