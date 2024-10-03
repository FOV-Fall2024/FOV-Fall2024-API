using FluentValidation;
using FOV.Application.Features.IngredientGenerals.Commands.Active;

namespace FOV.Application.Features.IngredientGenerals.Commands.Inactive;
public class InactiveIngredientGeneralValidator : AbstractValidator<InactiveIngredientGeneralCommand>
{
    public InactiveIngredientGeneralValidator(IngredientGeneralIdValidator checkId)
    {
        RuleFor(x => x.Id).NotEmpty().SetValidator(checkId);
    }
}
