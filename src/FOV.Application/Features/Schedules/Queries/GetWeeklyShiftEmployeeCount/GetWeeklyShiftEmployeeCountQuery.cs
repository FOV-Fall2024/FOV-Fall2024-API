using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Queries.GetWeeklyShiftEmployeeCount;
public record GetWeeklyShiftEmployeeCountCommand(DateOnly SpecificDate) : IRequest<List<ShiftEmployeeCountDto>>;
public record ShiftEmployeeCountDto(DateOnly? Date, Guid ShiftId, string ShiftName, int EmployeeCount);
public class GetWeeklyShiftEmployeeCountQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetWeeklyShiftEmployeeCountCommand, List<ShiftEmployeeCountDto>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<List<ShiftEmployeeCountDto>> Handle(GetWeeklyShiftEmployeeCountCommand request, CancellationToken cancellationToken)
    {
        var restaurantId = _claimService.RestaurantId;
        if (restaurantId == null)
        {
            throw new AppException("Restaurant ID is not specified for the current user.");
        }

        var dayOfWeek = (int)request.SpecificDate.DayOfWeek;
        var startDate = request.SpecificDate.AddDays(-(dayOfWeek == 0 ? 6 : dayOfWeek - 1));
        var endDate = startDate.AddDays(6);

        var schedules = await _unitOfWorks.WaiterScheduleRepository.GetAllAsync(
            s => s.User,
            s => s.Shift
        );

        var filterSchedules = schedules.Where(s => s.DateTime >= startDate && s.DateTime <= endDate && s.User.RestaurantId == restaurantId);

        var shiftEmployeeCounts = schedules
            .GroupBy(s => new { s.DateTime, s.ShiftId })
            .Select(g => new ShiftEmployeeCountDto(
                g.Key.DateTime,
                g.Key.ShiftId,
                g.First().Shift.ShiftName,
                g.Count()
            ))
            .ToList();

        return shiftEmployeeCounts;
    }
}
