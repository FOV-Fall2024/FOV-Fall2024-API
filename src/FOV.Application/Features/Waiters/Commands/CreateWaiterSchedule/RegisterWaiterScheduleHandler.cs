using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Waiters.Commands.CreateWaiterSchedule;
public record RegisterWaiterScheduleCommand(Guid ShiftId, string UserId, DateTime DateTime) : IRequest<Guid>;
public class RegisterWaiterScheduleHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RegisterWaiterScheduleCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(RegisterWaiterScheduleCommand request, CancellationToken cancellationToken)
    {
        WaiterSchedule waiterSchedule = new(request.DateTime, request.ShiftId, request.UserId);
        await _unitOfWorks.WaiterScheduleRepository.AddAsync(waiterSchedule);
        await _unitOfWorks.SaveChangeAsync();
        return waiterSchedule.Id;
    }
}
