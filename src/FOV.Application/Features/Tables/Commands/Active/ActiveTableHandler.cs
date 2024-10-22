using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Commands.Active;
public sealed record ActiveTableCommand(Guid id) : IRequest<Guid>;
public class ActiveTableHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveTableCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(ActiveTableCommand request, CancellationToken cancellationToken)
    {
        var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.id) ?? throw new Exception();
        table.UpdateState(true);
        _unitOfWorks.TableRepository.Update(table);
        await _unitOfWorks.SaveChangeAsync();
        return table.Id;
    }
}
