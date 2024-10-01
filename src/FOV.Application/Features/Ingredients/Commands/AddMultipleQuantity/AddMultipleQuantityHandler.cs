using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Ingredients.Commands.AddMultipleQuantity;
public sealed record AddMultipleQuantityCommand(List<ObjectAdding> Adding) : IRequest<List<Guid>>;
public sealed record ObjectAdding(decimal Quantity, Guid IngreidentId);
public class AddMultipleQuantityHandler : IRequestHandler<AddMultipleQuantityCommand, List<Guid>>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public AddMultipleQuantityHandler(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<List<Guid>> Handle(AddMultipleQuantityCommand request, CancellationToken cancellationToken)
    {
        var fieldErrors = new List<FieldError>();
        var transactionIds = new List<Guid>();

        foreach (var item in request.Adding)
        {
            var ingredient = await _unitOfWorks.IngredientRepository.GetByIdAsync(item.IngreidentId);
            if (ingredient == null)
            {
                fieldErrors.Add(new FieldError { Field = "ingredientId", Message = $"Nguyên liệu với ID {item.IngreidentId} không tồn tại." });
                continue;
            }

            var ingredientTransaction = new IngredientTransaction(item.Quantity, Domain.Entities.IngredientAggregator.Enums.IngredientTransactionType.Add, ingredient.Id);
            ingredient.AddQuantity(item.Quantity);

            await _unitOfWorks.IngredientTransactionRepository.AddAsync(ingredientTransaction);
            _unitOfWorks.IngredientRepository.Update(ingredient);

            transactionIds.Add(ingredientTransaction.Id);
        }

        await _unitOfWorks.SaveChangeAsync();

        if (fieldErrors.Any())
        {
            throw new AppException("Lỗi khi thêm nguyên liệu", fieldErrors);
        }

        return transactionIds;
    }
}
