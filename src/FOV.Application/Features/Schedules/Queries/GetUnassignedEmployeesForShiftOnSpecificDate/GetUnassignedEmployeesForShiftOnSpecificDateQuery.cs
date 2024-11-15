using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Schedules.Responses;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Schedules.Queries.GetUnassignedEmployeesForShiftOnSpecificDate;
public record GetUnassignedEmployeesForShiftOnSpecificDateCommand(Guid ShiftId, DateOnly Date) : IRequest<List<EmployeeDto>>;
public class GetUnassignedEmployeesForShiftOnSpecificDateQuery : IRequestHandler<GetUnassignedEmployeesForShiftOnSpecificDateCommand, List<EmployeeDto>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;
    private readonly UserManager<User> _userManager;

    public GetUnassignedEmployeesForShiftOnSpecificDateQuery(IUnitOfWorks unitOfWorks, IClaimService claimService, UserManager<User> userManager)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;
        _userManager = userManager;
    }

    public async Task<List<EmployeeDto>> Handle(GetUnassignedEmployeesForShiftOnSpecificDateCommand request, CancellationToken cancellationToken)
    {
        var restaurantId = _claimService.RestaurantId;
        if (restaurantId == null)
        {
            throw new AppException("Restaurant ID is not specified for the current user.");
        }

        var allEmployees = await _userManager.Users
            .Where(u => u.RestaurantId == restaurantId &&
                        (u.EmployeeCode.StartsWith("WTR_") || u.EmployeeCode.StartsWith("CKR_")))
            .ToListAsync(cancellationToken);

        var assignedSchedules = await _unitOfWorks.WaiterScheduleRepository.GetAllAsync(s => s.User, s => s.Shift);

        var filteredAssignedSchedules = assignedSchedules
            .Where(s => s.DateTime == request.Date && s.ShiftId == request.ShiftId && s.User.RestaurantId == restaurantId)
            .ToList();

        var assignedEmployeeIds = filteredAssignedSchedules
            .Select(s => s.User.Id)
            .ToHashSet();

        var unassignedEmployees = allEmployees
            .Where(e => !assignedEmployeeIds.Contains(e.Id) &&
                        (e.EmployeeCode.StartsWith("WTR_") || e.EmployeeCode.StartsWith("CKR_")))
            .Select(e => new EmployeeDto(e.Id, e.EmployeeCode))
            .ToList();

        return unassignedEmployees;
    }
}
