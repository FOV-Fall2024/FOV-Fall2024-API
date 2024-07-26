using FluentValidation;

namespace FOV.Application.Features.IngredientTypes.Commands.Create;

public class CreateIngredientTypeValidator : AbstractValidator<CreateIngredientTypeCommand>
{
    public CreateIngredientTypeValidator()
    {
        RuleFor(x => x.Name).NotNull();
        RuleFor(x => x.Description).NotNull();
    }
}
