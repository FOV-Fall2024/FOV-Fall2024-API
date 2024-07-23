

using FluentResults;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Commands.Inactive;

public sealed record InactiveIngredientTypeCommand(Guid Id) : IRequest<Result>;
public class InactiveIngredientTypeHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveIngredientTypeCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        IngredientGeneral ingredientGenerals = await _unitOfWorks.IngredientGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        ingredientGenerals.UpdateState(false);
        _unitOfWorks.IngredientGeneralRepository.Update(ingredientGenerals);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}