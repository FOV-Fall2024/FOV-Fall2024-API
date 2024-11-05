using FluentResults;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Ingredients.Commands.AddSingleQuantity;
public sealed record AddSingleQuantityCommand(Guid IngredientId, decimal Quantity) : IRequest<Guid>;
public class AddSingleQuantityHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddSingleQuantityCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(AddSingleQuantityCommand request, CancellationToken cancellationToken)
    {
        if (request.Quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }

        var ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(request.IngredientId);
        if (ingredient == null)
        {
            throw new KeyNotFoundException($"Ingredient with ID {request.IngredientId} not found.");
        }


        //var existingTransaction = await _unitOfWorks.IngredientTransactionRepository
        //    .FirstOrDefaultAsync(t => t.IngredientId == ingredient.Id &&
        //                               t.TransactionDate.Date == DateTime.UtcNow.Date);

        //if (existingTransaction != null)
        //{
        //    _logger.LogWarning("A transaction for this ingredient has already been recorded today.");
        //    throw new InvalidOperationException("A transaction for this ingredient has already been recorded today.");
        //}

        ingredient.AddQuantity(request.Quantity);

        IngredientUsage ingredientTransaction = new(request.Quantity,
                                                           Domain.Entities.IngredientAggregator.Enums.IngredientTransactionType.Add,
                                                           ingredient.Id);

        await _unitOfWorks.IngredientTransactionRepository.AddAsync(ingredientTransaction);

        _unitOfWorks.IngredientRepository.Update(ingredient);

        await _unitOfWorks.SaveChangeAsync();

        return ingredient.Id;
    }


}
