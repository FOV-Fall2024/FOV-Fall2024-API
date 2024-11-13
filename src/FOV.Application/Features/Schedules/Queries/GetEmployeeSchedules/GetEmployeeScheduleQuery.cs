using FOV.Application.Features.Schedules.Responses;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;
public record GetEmployeeScheduleRequest(PagingRequest? PagingRequest, Guid EmployeeId) : IRequest<PagedResult<GetEmployeeScheduleResponse>>;
public class GetEmployeeScheduleQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetEmployeeScheduleRequest, PagedResult<GetEmployeeScheduleResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetEmployeeScheduleResponse>> Handle(GetEmployeeScheduleRequest request, CancellationToken cancellationToken)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        int daysToSunday = (int)DayOfWeek.Sunday - (int)today.DayOfWeek;
        DateOnly startOfWeek = today.AddDays(daysToSunday);
        DateOnly endOfWeek = startOfWeek.AddDays(6);

        var schedules = await _unitOfWorks.WaiterScheduleRepository
            .WhereAsync(ws => ws.UserId == request.EmployeeId
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
