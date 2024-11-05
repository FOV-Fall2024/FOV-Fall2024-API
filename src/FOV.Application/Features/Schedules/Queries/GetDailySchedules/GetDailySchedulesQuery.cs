using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;
using FOV.Application.Features.Schedules.Responses;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Queries.GetDailySchedules;
public sealed record GetDailyScheduleCommand(PagingRequest? PagingRequest, Guid? ShiftId, Guid? RestaurantId) : IRequest<PagedResult<GetDailyScheduleResponse>>;

public class GetDailySchedulesQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetDailyScheduleCommand, PagedResult<GetDailyScheduleResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetDailyScheduleResponse>> Handle(GetDailyScheduleCommand request, CancellationToken cancellationToken)
    {
        //DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        //var schedules = await _unitOfWorks.WaiterScheduleRepository.GetAllAsync(x => x.Employee, x => x.Shift);

        //var filterEntity = new WaiterSchedule
        //{
        //    Id = request.ShiftId.HasValue ? request.ShiftId.Value : Guid.Empty,
        //};

        //var filteredSchedules = schedules.AsQueryable().CustomFilterV1(filterEntity).Where(schedules => schedules.DateTime == today);

        //if (request.RestaurantId.HasValue)
        //{
        //    filteredSchedules = filteredSchedules.Where(schedule => schedule.Employee.RestaurantId == request.RestaurantId.Value);
        //}

        //var mappedSchedules = filteredSchedules.Select(schedule => new GetDailyScheduleResponse(
        //               schedule.Id,
        //                          new EmployeeDto(schedule.EmployeeId, schedule.Employee.EmployeeCode),
        //                                     new ShiftDto(schedule.ShiftId, schedule.Shift.ShiftName)
        //                                            )).ToList();

        //var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        //var sortedResults = PaginationHelper<GetDailyScheduleResponse>.Sorting(sortType, mappedSchedules, sortField);
        //var result = PaginationHelper<GetDailyScheduleResponse>.Paging(sortedResults, page, pageSize);

        //return result;
        throw new NotImplementedException();
    }
}
