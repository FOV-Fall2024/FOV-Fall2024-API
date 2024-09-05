using FluentResults;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Ingredients.Commands.AddSingleQuantity;

public sealed record AddSingleQuantityCommand(Guid IngredientId, decimal Quantity) : IRequest<Result>;
public class AddSingleQuantityHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddSingleQuantityCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(AddSingleQuantityCommand request, CancellationToken cancellationToken)
    {
        Ingredient ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(request.IngredientId) ?? throw new Exception();
        ingredient.AddQuantity(request.Quantity);
        IngredientTransaction ingredientTransaction = new(request.Quantity, Domain.Entities.IngredientAggregator.Enums.IngredientTransactionType.Add, ingredient.Id);
        ingredient.AddQuantity(request.Quantity);
        await _unitOfWorks.IngredientTransactionRepository.AddAsync(ingredientTransaction);
        _unitOfWorks.IngredientRepository.Update(ingredient);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
