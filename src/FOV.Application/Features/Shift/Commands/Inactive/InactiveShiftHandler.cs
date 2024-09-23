using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Shift.Commands.Inactive;
public record InactiveShiftCommand(Guid ShiftId) : IRequest<Result>;
public class InactiveShiftHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveShiftCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveShiftCommand request, CancellationToken cancellationToken)
    {
        var shift = await _unitOfWorks.ShiftRepository.GetByIdAsync(request.ShiftId);
        if (shift == null)
        {
            return Result.Fail("Không tìm thấy ca làm nào");
        }
        shift.UpdateState(true);
        _unitOfWorks.ShiftRepository.Update(shift);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
