using FluentValidation;
using FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;

namespace FOV.Application.Features.DishGenerals.Commands.Inactive;
public class InactiveDishGeneralValidator : AbstractValidator<InactiveProductGeneralCommand>
{
    public InactiveDishGeneralValidator(CheckDishGeneralIdValidator checkDishGeneralId)
    {
        RuleFor(x => x.Id).SetValidator(checkDishGeneralId);
    }
}
