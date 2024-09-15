using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Shift.Commands.Create;
public record CreateShiftCommand(string ShiftName, TimeSpan StartTime, TimeSpan EndTime) : IRequest<Guid>;
public class CreateShiftHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateShiftCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.ShiftAggregator.Shift shift = new(request.ShiftName, request.StartTime, request.EndTime);
        await _unitOfWorks.ShiftRepository.AddAsync(shift);
        await _unitOfWorks.SaveChangeAsync();
        return shift.Id;
    }
}
