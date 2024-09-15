using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Commands.Delete;
public record UnregisterScheduleCommand(string EmployeeId, Guid ScheduleId) : IRequest<bool>;
public class UnregisterScheduleHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UnregisterScheduleCommand, bool>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<bool> Handle(UnregisterScheduleCommand request, CancellationToken cancellationToken)
    {
        var schedule = await _unitOfWorks.WaiterScheduleRepository.GetByIdAsync(request.ScheduleId);
        if (schedule.EmployeeId != request.EmployeeId)
        {
            throw new Exception("You are not authorized to delete this schedule");
        }
        _unitOfWorks.WaiterScheduleRepository.Remove(schedule);
        await _unitOfWorks.SaveChangeAsync();
        return true;
    }
}
