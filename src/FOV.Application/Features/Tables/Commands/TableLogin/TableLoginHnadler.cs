using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Commands.TableLogin;
public record TableLoginCommand(Guid TableId) : IRequest<Result>;
public class TableLoginHnadler(IUnitOfWorks unitOfWorks) : IRequestHandler<TableLoginCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(TableLoginCommand request, CancellationToken cancellationToken)
    {
        var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.TableId) ?? throw new Exception();
        table.UpdateIsLogin(true);
        _unitOfWorks.TableRepository.Update(table);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
