using FluentResults;
using FOV.Domain.Entities.DishAggregator.Enums;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using System.Text.Json.Serialization;

namespace FOV.Application.Features.RefundDishInventories.Commands.AddSingle;
public sealed record AddSingleRefundDishInventoryCommand(int Quantity) : IRequest<Result>
{
    [JsonIgnore]
    public Guid DishId { get; set; }
}
public class AddSingleRefundDishInventoryHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddSingleRefundDishInventoryCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(AddSingleRefundDishInventoryCommand request, CancellationToken cancellationToken)
    {
        Dish dishSystem = await _unitOfWorks.DishRepository.GetByIdAsync(request.DishId, x => x.RefundDishInventory) ?? throw new Exception();
        int quantityAdding = request.Quantity;
        RefundDishInventory inventory = await _unitOfWorks.RefundDishInventoryRepository.GetByIdAsync(dishSystem.RefundDishInventory.Id) ?? throw new Exception();
        inventory.AddQuantity(quantityAdding);
        _unitOfWorks.RefundDishInventoryRepository.Update(inventory);
        RefundDishInventoryTransaction transaction = new(quantityAdding, dishSystem.RefundDishInventory.Id, RefundDishInventoryTransactionType.Add);
        await _unitOfWorks.RefundDishInventoryTransactionRepository.AddAsync(transaction);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
