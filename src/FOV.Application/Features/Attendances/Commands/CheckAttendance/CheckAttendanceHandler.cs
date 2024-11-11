using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Attendances.Commands.CheckAttendance;
public record CheckAttendanceCommand(Guid EmployeeId, Guid RestaurantId, Guid WaiterScheduleId, DateOnly Date) : IRequest<string>;
public class CheckAttendanceHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<CheckAttendanceCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    public async Task<string> Handle(CheckAttendanceCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.RestaurantId) ?? throw new Exception("Không tìm thấy nhà hàng");
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.RestaurantId == restaurant.Id) ?? throw new Exception("Không tìm thấy nhân viên");
        var waiterSchedule = await _unitOfWorks.WaiterScheduleRepository.GetByIdAsync(request.WaiterScheduleId) ?? throw new Exception("Không tìm thấy lịch làm");

        if (waiterSchedule.DateTime != request.Date)
        {
            throw new Exception("Ngày không hợp lệ");
        }

        if (waiterSchedule.UserId != request.EmployeeId)
        {
            throw new Exception("Nhân viên không hợp lệ");
        }

        var attendance = await _unitOfWorks.AttendanceRepository.GetByEmployeeScheduleAndDateAsync(request.EmployeeId, request.WaiterScheduleId, request.Date);
        if (attendance != null)
        {
            throw new Exception("Nhân viên này đã điểm danh");
        }

        var newAttendance = new Domain.Entities.AttendanceAggregator.Attendance
        {
            Id = request.EmployeeId,
            WaiterScheduleId = request.WaiterScheduleId,
            CheckInTime = DateTime.UtcNow.AddHours(7)
        };

        await _unitOfWorks.AttendanceRepository.AddAsync(newAttendance);
        await _unitOfWorks.SaveChangeAsync();
        return "Điểm danh thành công";
    }
}
