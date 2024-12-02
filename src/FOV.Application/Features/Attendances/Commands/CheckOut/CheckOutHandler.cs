using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
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
    public async Task<Guid> Handle(CheckOutCommand request, CancellationToken cancellationToken)
    {
        //Cuối ngày hết đơn mới được check out
        //Những ca còn lại thì thằng cuối cùng của ca đó không được checkout nếu ca sau chưa có người
        var user = _userManager.FindByIdAsync(_claimService.UserId.ToString()) ?? throw new AppException("Không tìm thấy nhân viên");
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(_claimService.RestaurantId) ?? throw new AppException("Không tìm thấy nhà hàng nào");
        var shift = await _unitOfWorks.ShiftRepository.GetByIdAsync(request.ShiftId) ?? throw new AppException("Không tìm thấy ca làm việc");

        var checkOutTime = request.CheckOutTime.AddHours(7);
        var shiftStartTime = new DateTime(request.CheckOutTime.Year, request.CheckOutTime.Month, request.CheckOutTime.Day,
                                     shift.StartTime?.Hours ?? 0, shift.StartTime?.Minutes ?? 0, shift.StartTime?.Seconds ?? 0);
        var shiftEndTime = new DateTime(request.CheckOutTime.Year, request.CheckOutTime.Month, request.CheckOutTime.Day,
                                        shift.EndTime?.Hours ?? 0, shift.EndTime?.Minutes ?? 0, shift.EndTime?.Seconds ?? 0);
        return Guid.Empty;
    }
}
