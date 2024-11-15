using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Schedules.Responses;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Queries.GetEmployeeOfShiftOnSpecificDate;
public record GetEmployeeOfShiftOnSpecificDateCommand(Guid ShiftId, DateOnly Date) : IRequest<List<EmployeeDto>>;
internal class GetEmployeeOfShiftOnSpecificDateQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetEmployeeOfShiftOnSpecificDateCommand, List<EmployeeDto>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<List<EmployeeDto>> Handle(GetEmployeeOfShiftOnSpecificDateCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        if (userRole == null)
        {
            throw new AppException("User role is not found");
        }
        var schedules = await _unitOfWorks.WaiterScheduleRepository.GetAllAsync(x => x.User, x => x.Shift);
        var filteredSchedules = schedules.Where(s => s.DateTime == request.Date && s.ShiftId == request.ShiftId && s.User.RestaurantId == _claimService.RestaurantId);

        var mappedSchedules = filteredSchedules.Select(schedule => new EmployeeDto(schedule.User.Id, schedule.User.EmployeeCode)).ToList();

        return mappedSchedules;
    }
}
