using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Attendances.Commands.CheckOut;
public record CheckOutCommand(DateOnly Date, Guid ShiftId, DateTime CheckOutTime, double Latitude, double Longitude) : IRequest<Guid>;
public class CheckOutHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, IClaimService claimService) : IRequestHandler<CheckOutCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IClaimService _claimService = claimService;
    private const double MaxDistance = 200;
    public async Task<Guid> Handle(CheckOutCommand request, CancellationToken cancellationToken)
    {
        //Cuối ngày hết đơn mới được check out
        //Những ca còn lại thì thằng cuối cùng của ca đó không được checkout nếu ca sau chưa có người
        var user = _userManager.FindByIdAsync(_claimService.UserId.ToString()) 
            ?? throw new AppException("Không tìm thấy nhân viên");
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(_claimService.RestaurantId) 
            ?? throw new AppException("Không tìm thấy nhà hàng nào");

        var shifts = await _unitOfWorks.ShiftRepository.GetAllAsync();
        var lastShift = shifts.OrderByDescending(s => s.EndTime).FirstOrDefault();
        if (lastShift == null) 
            throw new AppException("Không tìm thấy ca làm việc.");

        var checkOutTime = request.CheckOutTime.AddHours(7);
        var shift = shifts.FirstOrDefault(s => s.Id == request.ShiftId) 
            ?? throw new AppException("Không tìm thấy ca làm việc.");

        //var shiftStartTime = new DateTime(request.CheckOutTime.Year, request.CheckOutTime.Month, request.CheckOutTime.Day,
        //                             shift.StartTime?.Hours ?? 0, shift.StartTime?.Minutes ?? 0, shift.StartTime?.Seconds ?? 0);
        //var shiftEndTime = new DateTime(request.CheckOutTime.Year, request.CheckOutTime.Month, request.CheckOutTime.Day,
        //                                shift.EndTime?.Hours ?? 0, shift.EndTime?.Minutes ?? 0, shift.EndTime?.Seconds ?? 0);
        //var earliestCheckOutTime = shiftEndTime.AddMinutes(-15);
        //if (checkOutTime < shiftEndTime)
        //    throw new AppException("Bạn chỉ được phép check-out sau khi ca làm việc kết thúc.");

        var distance = CalculateDistanceInMeter(restaurant.Latitude, restaurant.Longitude, request.Latitude, request.Longitude);
        if (distance > MaxDistance)
            throw new AppException($"Khoảng cách check-out vượt quá {MaxDistance}m cho phép.");

        var waiterSchedule = await _unitOfWorks.WaiterScheduleRepository.FirstOrDefaultAsync(
            ws => ws.DateTime == request.Date && ws.ShiftId == request.ShiftId && ws.UserId == _claimService.UserId,
            ws => ws.Attendances);

        if (waiterSchedule == null) 
            throw new AppException("Nhân viên không có lịch làm việc trong ca này.");

        var attendance = waiterSchedule.Attendances?.FirstOrDefault();
        if (attendance == null || attendance.CheckInTime == null) 
            throw new AppException("Nhân viên chưa check-in trong ca này.");

        if (shift.Id == lastShift.Id)
        {
            var activeOrders = await _unitOfWorks.OrderRepository.GetAllAsync(
                o => o.Created.Date == request.Date.ToDateTime(TimeOnly.MinValue).Date &&
                     o.OrderStatus != OrderStatus.Finish && o.OrderStatus != OrderStatus.Canceled);
            if (activeOrders.Any())
                throw new AppException("Không thể check-out vì vẫn còn đơn hàng hoạt động.");
        }
        else
        {
            var nextShift = shifts.OrderBy(s => s.StartTime).FirstOrDefault(s => s.StartTime > shift.EndTime);
            if (nextShift != null)
            {
                var nextShiftWaiterSchedules = await _unitOfWorks.WaiterScheduleRepository.GetAllAsync(
                    ws => ws.DateTime == request.Date && ws.ShiftId == nextShift.Id,
                    ws => ws.Attendances);
                if (!nextShiftWaiterSchedules.Any(ws => ws.Attendances?.Any(a => a.CheckInTime != null) == true))
                    throw new AppException("Không thể check-out vì ca tiếp theo chưa có người check-in.");
            }
        }

        attendance.CheckOutTime = request.CheckOutTime.ToUniversalTime();
        _unitOfWorks.AttendanceRepository.Update(attendance);
        await _unitOfWorks.SaveChangeAsync();

        return attendance.Id;
    }
    private static double CalculateDistanceInMeter(double lat1, double lon1, double lat2, double lon2)
    {
        const double EarthRadius = 6371;
        var deltaLat = (lat2 - lat1) * (Math.PI / 180);
        var deltaLon = (lon2 - lon1) * (Math.PI / 180);

        var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos(lat1 * (Math.PI / 180)) * Math.Cos(lat2 * (Math.PI / 180)) *
                Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return EarthRadius * c * 1000;
    }
}
