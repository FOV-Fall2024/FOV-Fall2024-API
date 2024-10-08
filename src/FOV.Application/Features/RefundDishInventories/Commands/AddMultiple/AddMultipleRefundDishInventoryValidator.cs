using FluentValidation;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.RefundDishInventories.Commands.AddMultiple;


public class AddMultipleRefundDishInventoryValidator : AbstractValidator<AddMultipleRefundDishInventoryCommand>
{
    public AddMultipleRefundDishInventoryValidator(CheckRefundDishListValidator checkListValidator)
    {
        RuleFor(x => x.Dishes).SetValidator(checkListValidator);
    }
}

public sealed class CheckRefundDishListValidator : AbstractValidator<List<DishAddingCommand>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public CheckRefundDishListValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(list => list)
    .MustAsync(CheckListValidator)
    .WithMessage("Tên này đã tồn tại trong hệ thống");
    }

    public async Task<bool> CheckListValidator(List<DishAddingCommand> list, CancellationToken token)
    {
        foreach (DishAddingCommand command in list)
        {
            Dish? dish = await _unitOfWorks.DishRepository.GetByIdAsync(command.DishId, x => x.RefundDishInventory, x => x.RefundDishInventory.DishUnits);
            if (dish is null) return false;
            if (!dish.RefundDishInventory.DishUnits.Where(x => x.Id == command.DishId).Any())
            {
                return false;
            }
        }
        return true;
    }
}
