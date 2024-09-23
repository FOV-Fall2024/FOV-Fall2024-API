using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Shift.Commands.Active;
public sealed record ActiveShiftCommand(Guid id) : IRequest<Result>;
public class ActiveShiftHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveShiftCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveShiftCommand request, CancellationToken cancellationToken)
    {
        var shift = await _unitOfWorks.ShiftRepository.GetByIdAsync(request.id);
        if (shift == null)
        {
            return Result.Fail("Không tìm thấy ca làm nào");
        }
        shift.UpdateState(false);
        _unitOfWorks.ShiftRepository.Update(shift);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}

