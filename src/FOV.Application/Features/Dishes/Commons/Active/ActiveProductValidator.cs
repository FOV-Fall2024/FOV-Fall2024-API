using FluentValidation;
using FOV.Application.Features.Dishes.Commons.Inactive;

namespace FOV.Application.Features.Dishes.Commons.Active;
public class ActiveProductValidator : AbstractValidator<ActiveProductCommand>
{
    public ActiveProductValidator(CheckProductIdValidator idChecking)
    {
        RuleFor(x => x.Id).SetValidator(idChecking);
    }
}
