using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Application.Features.Tables.Commands.Active;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Commands.Inactive;
public sealed record InactiveTableCommand(Guid id) : IRequest<Result>;
public class InactiveTableHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveTableCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.id) ?? throw new Exception();
        table.UpdateState(true);
        _unitOfWorks.TableRepository.Update(table);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}

