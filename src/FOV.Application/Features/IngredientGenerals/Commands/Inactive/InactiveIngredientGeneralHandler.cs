using FluentResults;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Commands.Inactive;
public sealed record InactiveIngredientGeneralCommand(Guid Id) : IRequest<Result>;
public class InactiveIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveIngredientGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveIngredientGeneralCommand request, CancellationToken cancellationToken)
    {
        IngredientGeneral ingredientGenerals = await _unitOfWorks.IngredientGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        ingredientGenerals.UpdateState(true);
        _unitOfWorks.IngredientGeneralRepository.Update(ingredientGenerals);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
