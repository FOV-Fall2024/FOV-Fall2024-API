using FluentValidation;
using FOV.Application.Features.Dishes.Commons.Inactive;

namespace FOV.Application.Features.Dishes.Commons.Active;
public class ActiveProductValidator : AbstractValidator<ActiveProductCommand>
{
    public ActiveProductValidator(CheckProductIdValidator IdChecking)
    {
        RuleFor(x => x.Id).SetValidator(IdChecking);
    }
}
