using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Domain.Entities.ShiftAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Shift.Commands.Update;
public sealed record UpdateShiftCommand(Guid Id, string? ShiftName, DateTime? StartTime, DateTime? EndTime) : IRequest<Result>;
public class UpdateShiftHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateShiftCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
    {
        Domain.Entities.ShiftAggregator.Shift shift = await _unitOfWorks.ShiftRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        Domain.Entities.ShiftAggregator.Shift updatedShift = new(request.ShiftName ?? shift.ShiftName, request.StartTime ?? shift.StartTime, request.EndTime ?? shift.EndTime);
        _unitOfWorks.ShiftRepository.Update(updatedShift);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
