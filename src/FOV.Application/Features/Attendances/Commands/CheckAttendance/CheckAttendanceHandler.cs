using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Attendances.Commands.CheckAttendance;
public record CheckAttendanceCommand(Guid EmployeeId, Guid RestaurantId, Guid WaiterScheduleId, DateOnly Date) : IRequest<string>;
public class CheckAttendanceHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CheckAttendanceCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<string> Handle(CheckAttendanceCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.RestaurantId) ?? throw new Exception("Restaurant not found");
        var employee = await _unitOfWorks.EmployeeRepository.GetByIdAsync(request.EmployeeId) ?? throw new Exception("Employee not found");
        var waiterSchedule = await _unitOfWorks.WaiterScheduleRepository.GetByIdAsync(request.WaiterScheduleId) ?? throw new Exception("Schedule not found");

        if (waiterSchedule.DateTime != request.Date)
        {
            throw new Exception("Invalid date");
        }
        
        if (waiterSchedule.EmployeeId != request.EmployeeId)
        {
            throw new Exception("Invalid employee");
        }

        var attendance = await _unitOfWorks.AttendanceRepository.GetByEmployeeScheduleAndDateAsync(request.EmployeeId, request.WaiterScheduleId, request.Date);
        if (attendance != null)
        {
            throw new Exception("Attendance already checked for this employee on the selected date.");
        }

        var newAttendance = new Domain.Entities.AttendanceAggregator.Attendance
        {
            EmployeeId = request.EmployeeId,
            WaiterScheduleId = request.WaiterScheduleId,
            CheckInTime = DateTimeOffset.UtcNow.AddHours(7)
        };

        await _unitOfWorks.AttendanceRepository.AddAsync(newAttendance);
        await _unitOfWorks.SaveChangeAsync();
        return "Attendance checked successfully";
    }
}
