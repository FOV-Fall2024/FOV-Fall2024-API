using FluentValidation;
using FOV.Application.Features.IngredientGenerals.Commands.Active;
using FOV.Application.Features.IngredientTypes.Commands.Inactive;

namespace FOV.Application.Features.IngredientGenerals.Commands.Inactive;
internal class InactiveIngredientGeneralValidator : AbstractValidator<InactiveIngredientTypeCommand>
{
    public InactiveIngredientGeneralValidator(IngredientGeneralIdValidator checkId)
    {
        RuleFor(x => x.Id).NotEmpty().SetValidator(checkId);
    }
}
