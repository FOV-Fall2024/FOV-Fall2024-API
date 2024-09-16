using FluentValidation;
using FOV.Application.Features.IngredientTypes.Commands.Active;

namespace FOV.Application.Features.IngredientTypes.Commands.Inactive;
internal class InactiveIngredientTypeValidator : AbstractValidator<InactiveIngredientTypeCommand>
{
    public InactiveIngredientTypeValidator(IngredientIdValidator validator)
    {
        RuleFor(x => x.Id).NotEmpty().SetValidator(validator);
    }
}
