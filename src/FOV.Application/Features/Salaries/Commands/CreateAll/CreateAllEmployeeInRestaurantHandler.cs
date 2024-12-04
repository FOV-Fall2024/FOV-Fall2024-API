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
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Salaries.Commands.CreateAll;
public record CreateAllSalariesCommand(Guid RestaurantId) : IRequest<string>;
public class CreateAllEmployeeInRestaurantHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, RoleManager<ApplicationRole> roleManager) : IRequestHandler<CreateAllSalariesCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
    public async Task<string> Handle(CreateAllSalariesCommand request, CancellationToken cancellationToken)
    {
        var users = await _userManager.Users.Where(u => u.RestaurantId == request.RestaurantId).ToListAsync();

        if (!users.Any())
            return "Không có nhân viên trong nhà hàng này.";

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

            var currentDate = DateTime.UtcNow;
            var startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var attendances = await _unitOfWorks.AttendanceRepository
                .WhereAsync(a => a.CheckInTime >= startDate && a.CheckInTime <= endDate && a.WaiterSchedule.UserId == user.Id);

            if (!attendances.Any())
                throw new AppException($"Không tìm thấy dữ liệu điểm danh cho nhân viên {user.FullName} trong tháng này.");

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
        }

        return "Đã tạo lương cho tất cả nhân viên trong nhà hàng.";
    }
}
