using FluentValidation;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.RefundDishInventories.Commands.AddSingle;
public class AddSingleRefundDishInventoryValidator : AbstractValidator<AddSingleRefundDishInventoryCommand>
{
    public AddSingleRefundDishInventoryValidator(RefundDishInventoryId checkId)
    {
        RuleFor(x => x).SetValidator(checkId);
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Phải lớn hơn không");
    }
}


public sealed class RefundDishInventoryId : AbstractValidator<AddSingleRefundDishInventoryCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public RefundDishInventoryId(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(command => command)
  .MustAsync(CheckInformation)
  .WithMessage("Tên này đã tồn tại trong hệ thống");
    }

    public async Task<bool> CheckInformation(AddSingleRefundDishInventoryCommand command, CancellationToken token)
    {
        Dish? dish = await _unitOfWorks.DishRepository.GetByIdAsync(command.DishId, x => x.RefundDishInventory, x => x.RefundDishInventory.DishUnits);
        if (dish is null) return false;
        if (!dish.RefundDishInventory.DishUnits.Where(x => x.Id == command.DishId).Any())
        {
            return false;
        }
        return true;
    }
}
