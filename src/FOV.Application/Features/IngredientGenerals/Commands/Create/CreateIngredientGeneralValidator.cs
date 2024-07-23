using FluentValidation;

namespace FOV.Application.Features.IngredientGenerals.Commands.Create;

public class CreateIngredientGeneralValidator : AbstractValidator<CreateIngredientGeneralCommand>
{
    public CreateIngredientGeneralValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Description).NotEmpty().NotNull();
        RuleFor(x => x.IngredientType).NotEmpty().NotNull();
    }
}
