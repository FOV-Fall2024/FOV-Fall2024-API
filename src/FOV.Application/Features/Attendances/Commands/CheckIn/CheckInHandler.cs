using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Attendances.Commands.CheckIn;
public record CheckInCommand(Guid RestaurantId, Guid ShiftId, Guid UserId, DateOnly Date, DateTime CheckInTime, double Latitude, double Longitude) : IRequest<Guid>;
public class CheckInHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<CheckInCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    private const double MaxDistance = 200;
    public async Task<Guid> Handle(CheckInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString()) ?? throw new AppException("Không tìm thấy thông tin nhân viên.");
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.RestaurantId) ?? throw new AppException("Không tìm thấy thông tin nhà hàng."); ;
        var shift = await _unitOfWorks.ShiftRepository.GetByIdAsync(request.ShiftId) ?? throw new AppException("Không tìm thấy thông tin ca làm việc.");

        var checkInDate = request.CheckInTime.AddHours(7);
        var shiftStartTime = new DateTime(request.CheckInTime.Year, request.CheckInTime.Month, request.CheckInTime.Day,
                                             shift.StartTime?.Hours ?? 0, shift.StartTime?.Minutes ?? 0, shift.StartTime?.Seconds ?? 0);
        var shiftEndTime = new DateTime(request.CheckInTime.Year, request.CheckInTime.Month, request.CheckInTime.Day,
                                        shift.EndTime?.Hours ?? 0, shift.EndTime?.Minutes ?? 0, shift.EndTime?.Seconds ?? 0);

        if (request.CheckInTime < shiftStartTime || request.CheckInTime > shiftEndTime)
            throw new AppException("Thời gian check-in không nằm trong thời gian ca làm.");

        var waiterSchedule = await _unitOfWorks.WaiterScheduleRepository.FirstOrDefaultAsync(
                       ws => ws.DateTime == request.Date && ws.ShiftId == request.ShiftId && ws.UserId == request.UserId,
                                  ws => ws.Attendances, ws => ws.User);

        if (waiterSchedule == null) throw new AppException("Nhân viên không có lịch làm việc trong ca này.");

        var existingAttendance = waiterSchedule.Attendances?.FirstOrDefault(a => a.CheckInTime != null);
        if (existingAttendance != null) throw new AppException("Nhân viên đã check-in trước đó.");

        var distance = CalculateDistanceInMeter(restaurant.Latitude, restaurant.Longitude, request.Latitude, request.Longitude);
        if (distance > MaxDistance) throw new AppException("Vị trí check-in không nằm trong phạm vi cho phép.");

        var attendance = waiterSchedule.Attendances?.FirstOrDefault() ?? new Attendance
        {
            WaiterScheduleId = waiterSchedule.Id,
            CheckInTime = request.CheckInTime.ToUniversalTime()
        };

        if (attendance.Id != Guid.Empty && attendance.CheckInTime == null)
        {
            attendance.CheckInTime = request.CheckInTime.ToUniversalTime();
            _unitOfWorks.AttendanceRepository.Update(attendance);
        }
        else
        {
            await _unitOfWorks.AttendanceRepository.AddAsync(attendance);
        }

        await _unitOfWorks.SaveChangeAsync();

        return attendance.Id;
    }
    private static double CalculateDistanceInMeter(double lat1, double lon1, double lat2, double lon2)
    {
        const double EarthRadius = 6371; //Km
        // Note lại sau này xài lại
        // Haversine formula để tính khoảng cách giữa 2 điểm trên trái đất
        // a = sin²(Δφ/2) + cos φ1 ⋅ cos φ2 ⋅ sin²(Δλ/2) (a là diện tích giữa 2 điểm)
        // c = 2 ⋅ atan2( √a, √(1−a) ) (c là góc giữa 2 điểm)
        // d = R ⋅ c (distance)
        // Δφ là lat2 - lat1 (sự khác biệt giữa vĩ độ 2 điểm)
        // Δλ là lon2 - lon1 (sự khác biệt giữa kinh độ 2 điểm)
        var deltaLat = (lat2 - lat1) * (Math.PI / 180);
        var deltaLon = (lon2 - lon1) * (Math.PI / 180);

        var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) + //sin²(Δφ/2)
                Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) *//cos φ1 ⋅ cos φ2
                Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2); //sin²(Δλ/2)

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a)); //2 ⋅ atan2( √a, √(1−a) )
        return EarthRadius * c * 1000; // m
    }
}
