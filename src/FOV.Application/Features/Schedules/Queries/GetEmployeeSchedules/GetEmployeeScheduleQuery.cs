using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Queries.GetEmployeeSchedules;
public record GetEmployeeScheduleRequest(PagingRequest? PagingRequest, Guid? Id, Guid? EmployeeId, Guid? ShiftId) : IRequest<PagedResult<GetEmployeeScheduleResponse>>;
public record GetEmployeeScheduleResponse(Guid Id, EmployeeDto Employee, ShiftDto Shift, DateOnly Date);
public record ShiftDto(Guid ShiftId, string ShiftName);
public record EmployeeDto(Guid EmployeeId, string EmployeeCode);
public class GetEmployeeScheduleQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetEmployeeScheduleRequest, PagedResult<GetEmployeeScheduleResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<PagedResult<GetEmployeeScheduleResponse>> Handle(GetEmployeeScheduleRequest request, CancellationToken cancellationToken)
    {
        var schedule = await _unitOfWorks.WaiterScheduleRepository.GetAllAsync(s => s.Shift, s => s.Employee);
        var filterEntities = new WaiterSchedule
        {
            Id = request.Id.HasValue ? request.Id.Value : Guid.Empty,
            EmployeeId = request.EmployeeId.HasValue ? request.EmployeeId.Value : Guid.Empty,
            ShiftId = request.ShiftId.HasValue ? request.ShiftId.Value : Guid.Empty,
        };
        var filterTable = schedule.AsQueryable().CustomFilterV1(filterEntities);

        var mappedSchedule = filterTable.Select(s => new GetEmployeeScheduleResponse(s.Id, new EmployeeDto(s.EmployeeId, s.Employee.EmployeeCode), new ShiftDto(s.ShiftId, s.Shift.ShiftName), s.DateTime)).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

        var sortedResults = PaginationHelper<GetEmployeeScheduleResponse>.Sorting(sortType, mappedSchedule, sortField);
        var result = PaginationHelper<GetEmployeeScheduleResponse>.Paging(sortedResults, page, pageSize);
        return result;
    }
}
