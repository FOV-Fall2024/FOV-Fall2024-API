using FluentValidation;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.RefundDishInventories.Commands.AddSingle;
public class AddSingleRefundDishInventoryValidator : AbstractValidator<AddSingleRefundDishInventoryCommand>
{
    public AddSingleRefundDishInventoryValidator()
    {
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Phải lớn hơn không");
    }
}


