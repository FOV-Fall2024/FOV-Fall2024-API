using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.WaiterScheduleAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Schedules.Commands.Create;
public record RegisterScheduleCommand(DateOnly Date, Guid ShiftId, List<Guid> EmployeeIds) : IRequest<List<Guid>>;
public class RegisterScheduleHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RegisterScheduleCommand, List<Guid>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<Guid>> Handle(RegisterScheduleCommand request, CancellationToken cancellationToken)
    {
        List<Guid> scheduleIds = new();
        foreach (var employeeId in request.EmployeeIds)
        {
            var existingSchedule = await _unitOfWorks.WaiterScheduleRepository.FirstOrDefaultAsync(
                ws => ws.DateTime == request.Date && ws.ShiftId == request.ShiftId && ws.UserId == employeeId);

            if (existingSchedule != null) throw new AppException("Nhân viên này đã có lịch làm");

            if (existingSchedule == null)
            {
                var newSchedule = new WaiterSchedule(request.Date, request.ShiftId, employeeId);
                await _unitOfWorks.WaiterScheduleRepository.AddAsync(newSchedule);
                scheduleIds.Add(newSchedule.Id);
            }
        }
        await _unitOfWorks.SaveChangeAsync();
        return scheduleIds;
    }
}
