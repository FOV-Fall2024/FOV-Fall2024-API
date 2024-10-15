using FluentValidation;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.RefundDishInventories.Commands.AddMultiple;


public class AddMultipleRefundDishInventoryValidator : AbstractValidator<AddMultipleRefundDishInventoryCommand>
{
    public AddMultipleRefundDishInventoryValidator()
    {
    }
}

