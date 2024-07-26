using FluentResults;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Commands.Active;

public sealed record ActiveIngredientGeneralCommand(Guid Id) : IRequest<Result>;


public class ActiveIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveIngredientGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveIngredientGeneralCommand request, CancellationToken cancellationToken)
    {
        IngredientGeneral ingredientGenerals = await _unitOfWorks.IngredientGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        ingredientGenerals.UpdateState(true);
        _unitOfWorks.IngredientGeneralRepository.Update(ingredientGenerals);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
