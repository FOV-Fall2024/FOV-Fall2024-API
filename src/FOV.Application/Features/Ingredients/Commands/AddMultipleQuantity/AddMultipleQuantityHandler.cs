using FluentResults;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Ingredients.Commands.AddMultipleQuantity;
public sealed record AddMultipleQuantityCommand(List<ObjectAdding> Adding) : IRequest<Result>;
public sealed record ObjectAdding(decimal Quantity, Guid IngreidentId);
public class AddMultipleQuantityHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddMultipleQuantityCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(AddMultipleQuantityCommand request, CancellationToken cancellationToken)
    {
        foreach (var item in request.Adding)
        {
            Ingredient ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(item.IngreidentId) ?? throw new Exception();
            IngredientTransaction ingredientTransaction = new(item.Quantity, Domain.Entities.IngredientAggregator.Enums.IngredientTransactionType.Add, ingredient.Id);
            ingredient.AddQuantity(item.Quantity);
            await _unitOfWorks.IngredientTransactionRepository.AddAsync(ingredientTransaction);
            _unitOfWorks.IngredientRepository.Update(ingredient);
        }
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
