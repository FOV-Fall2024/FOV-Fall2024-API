using FluentValidation;

namespace FOV.Application.Features.IngredientGenerals.Commands.Update;

public class UpdateIngredientGeneralValidator : AbstractValidator<UpdateIngredientGeneralCommand>
{
    public UpdateIngredientGeneralValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
