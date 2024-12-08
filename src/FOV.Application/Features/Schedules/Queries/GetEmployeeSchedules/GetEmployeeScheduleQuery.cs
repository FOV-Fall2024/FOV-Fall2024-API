using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Schedules.Responses;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;
public record GetEmployeeScheduleRequest(PagingRequest? PagingRequest, DateTime? SelectedDate = null) : IRequest<PagedResult<GetEmployeeScheduleResponse>>;
public class GetEmployeeScheduleQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetEmployeeScheduleRequest, PagedResult<GetEmployeeScheduleResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<PagedResult<GetEmployeeScheduleResponse>> Handle(GetEmployeeScheduleRequest request, CancellationToken cancellationToken)
    {
        var employeeId = _claimService.UserId;
        var referenceDate = request.SelectedDate?.Date ?? DateTime.Today;
        var selectedDay = DateOnly.FromDateTime(referenceDate);

        int daysToMonday = (int)DayOfWeek.Monday - (int)selectedDay.DayOfWeek;
        if (daysToMonday > 0) daysToMonday -= 7;
        DateOnly startOfWeek = selectedDay.AddDays(daysToMonday);
        DateOnly endOfWeek = startOfWeek.AddDays(6);

        var schedules = await _unitOfWorks.WaiterScheduleRepository
            .WhereAsync(ws => ws.UserId == employeeId
                              && ws.DateTime >= startOfWeek
                              && ws.DateTime <= endOfWeek,
                        ws => ws.Shift, ws => ws.User);

        var mappedSchedules = schedules.Select(s => new GetEmployeeScheduleResponse(
            s.Id,
            //new EmployeeDto(s.UserId, s.User.EmployeeCode),
            new ShiftDto(s.ShiftId, s.Shift.ShiftName),
            s.DateTime,
            s.Created
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<GetEmployeeScheduleResponse>.Sorting(sortType, mappedSchedules, sortField);
        var result = PaginationHelper<GetEmployeeScheduleResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}
