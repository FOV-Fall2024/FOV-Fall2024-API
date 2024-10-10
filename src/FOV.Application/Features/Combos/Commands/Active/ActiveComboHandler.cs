using FluentResults;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.Active;

public sealed record ActiveComboCommand(Guid ComboId) : IRequest<Result>;
public class ActiveComboHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveComboCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveComboCommand request, CancellationToken cancellationToken)
    {
        Combo combo = await _unitOfWorks.ComboRepository.GetByIdAsync(request.ComboId) ?? throw new Exception();
        combo.UpdateState(true);
        _unitOfWorks.ComboRepository.Update(combo);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
