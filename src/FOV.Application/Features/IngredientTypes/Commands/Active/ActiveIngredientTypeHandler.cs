using FluentResults;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Commands.Active;

public sealed record ActiveIngredientTypeCommand(Guid Id) : IRequest<Result>;
public class ActiveIngredientTypeHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveIngredientTypeCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWork = unitOfWorks;
    public async Task<Result> Handle(ActiveIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        IngredientType ingredientType = await _unitOfWork.IngredientTypeRepository.GetByIdAsync(request.Id) ??
        throw new Exception();
        ingredientType.UpdateState(true);
        _unitOfWork.IngredientTypeRepository.Update(ingredientType);
        await _unitOfWork.SaveChangeAsync();
        return Result.Ok();
    }
}
