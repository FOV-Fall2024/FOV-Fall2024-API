using FluentValidation;
using FOV.Application.Features.Combos.Commands.Active;

namespace FOV.Application.Features.Combos.Commands.RemoveDishInCombo;
public class RemoveDishInComboValidator : AbstractValidator<RemoveDishInComboCommand>
{
    public RemoveDishInComboValidator(CheckComboIdValidator idValidator)
    {
        RuleFor(x => x.Id).SetValidator(idValidator);
    }
}


