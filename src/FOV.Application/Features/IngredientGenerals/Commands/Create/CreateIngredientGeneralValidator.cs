using FluentValidation;
using FOV.Application.Features.IngredientGenerals.Commands.Update;

namespace FOV.Application.Features.IngredientGenerals.Commands.Create;

public class CreateIngredientGeneralValidator : AbstractValidator<CreateIngredientGeneralCommand>
{
    public CreateIngredientGeneralValidator(IngredientNameValidator name)
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().SetValidator(name);
        RuleFor(x => x.Description).NotEmpty().NotNull();
        RuleFor(x => x.IngredientType).NotEmpty().NotNull();
    }
}
