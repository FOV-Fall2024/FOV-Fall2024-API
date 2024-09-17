using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Commands.Create;
public record RegisterScheduleCommand(
    Dictionary<DateOnly, List<Guid>> DateShift,
    Guid EmployeeId
    ) : IRequest<List<Guid>>;
public class RegisterScheduleHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RegisterScheduleCommand, List<Guid>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<Guid>> Handle(RegisterScheduleCommand request, CancellationToken cancellationToken)
    {
        List<Guid> scheduleIds = new();
        foreach (var entry in request.DateShift)
        {
            var date = entry.Key;
            var shiftIds = entry.Value;

            foreach (var shiftId in shiftIds)
            {
                var schedule = new WaiterSchedule(date, shiftId, request.EmployeeId);
                await _unitOfWorks.WaiterScheduleRepository.AddAsync(schedule);
                scheduleIds.Add(schedule.Id);
            }
        }

        await _unitOfWorks.SaveChangeAsync();
        return scheduleIds;
    }
}
