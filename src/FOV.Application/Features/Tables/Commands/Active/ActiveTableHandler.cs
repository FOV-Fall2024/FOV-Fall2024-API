using FluentResults;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.Features.Tables.Commands.Active;
public sealed record ActiveTableCommand(Guid id) : IRequest<Result>;
public class ActiveTableHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveTableCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.id) ?? throw new Exception();
        table.UpdateState(false); //IsDeleted = false means Active
        _unitOfWorks.TableRepository.Update(table);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
