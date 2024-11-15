using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;
using FOV.Application.Features.Schedules.Responses;
using FOV.Domain.Entities.AttendanceAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Attendances.Queries.GetDailyAttendances;
public sealed record GetDailyAttendanceCommand(PagingRequest? PagingRequest, bool? IsCheckIn) : IRequest<PagedResult<GetDailyAttendanceResponse>>;
public sealed record GetDailyAttendanceResponse(Guid Id, DateTimeOffset? CheckInTime, WaiterScheduleDto WaiterSchedule, DateTime CreatedDate);
public record WaiterScheduleDto(Guid Id, EmployeeDto Employee, ShiftDto Shift);
public class GetDailyAttendancesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetDailyAttendanceCommand, PagedResult<GetDailyAttendanceResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetDailyAttendanceResponse>> Handle(GetDailyAttendanceCommand request, CancellationToken cancellationToken)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        var schedules = (await _unitOfWorks.WaiterScheduleRepository
            .GetAllAsync(s => s.Attendances, s => s.User, s => s.Shift))
            .Where(s => s.DateTime == today);

        if (request.IsCheckIn.HasValue)
        {
            if (request.IsCheckIn.Value)
            {
                schedules = schedules.Where(s => s.Attendances.Any(a => a.CheckInTime != null));
            }
            else
            {
                schedules = schedules.Where(s => s.Attendances.All(a => a.CheckInTime == null));
            }
        }
        var attendanceList = schedules.Select(s => new GetDailyAttendanceResponse(
            s.Id,
            s.Attendances.FirstOrDefault()?.CheckInTime,
            new WaiterScheduleDto(
                s.Id,
                new EmployeeDto(s.User.Id, s.User.EmployeeCode, s.User.FullName, s.Id),
                new ShiftDto(s.ShiftId, s.Shift.ShiftName)
            ),
            s.Created
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<GetDailyAttendanceResponse>.Sorting(sortType, attendanceList, sortField);
        var result = PaginationHelper<GetDailyAttendanceResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}

