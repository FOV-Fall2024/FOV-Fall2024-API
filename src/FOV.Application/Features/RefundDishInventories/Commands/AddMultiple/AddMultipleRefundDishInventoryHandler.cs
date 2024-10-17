using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.RefundDishInventories.Commands.AddMultiple;

public sealed record AddMultipleRefundDishInventoryCommand(List<DishAddingCommand> Dishes) : IRequest<Result>;

public sealed record DishAddingCommand(Guid DishId, int Quantity);
public class AddMultipleRefundDishInventoryHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<AddMultipleRefundDishInventoryCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(AddMultipleRefundDishInventoryCommand request, CancellationToken cancellationToken)
    {
        foreach (var dish in request.Dishes)
        {
            Dish dishSystem = await _unitOfWorks.DishRepository.GetByIdAsync(dish.DishId, x => x.RefundDishInventory) ?? throw new Exception();
            int quantityAdding = dish.Quantity;
            RefundDishInventory inventory = await _unitOfWorks.RefundDishInventoryRepository.GetByIdAsync(dishSystem.RefundDishInventory.Id) ?? throw new Exception();
            inventory.AddQuantity(quantityAdding);
            _unitOfWorks.RefundDishInventoryRepository.Update(inventory);
            RefundDishInventoryTransaction transaction = new(quantityAdding, dishSystem.RefundDishInventory.Id, RefundDishInventoryTransactionType.Add);
            await _unitOfWorks.RefundDishInventoryTransactionRepository.AddAsync(transaction);
            await _unitOfWorks.SaveChangeAsync();

        }

        return Result.Ok();
    }
}
