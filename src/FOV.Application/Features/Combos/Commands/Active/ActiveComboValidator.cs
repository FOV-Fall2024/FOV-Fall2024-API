using FluentValidation;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Combos.Commands.Active;
public class ActiveComboValidator : AbstractValidator<ActiveComboCommand>
{
    public ActiveComboValidator(CheckComboIdValidator IdValidator)
    {
        RuleFor(x => x.ComboId).SetValidator(IdValidator);
    }
}

public sealed class CheckComboIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CheckComboIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(id => id)
           .MustAsync(IdChecking)
           .WithMessage("Id Không có trong hệ thống");
    }

    public async Task<bool> IdChecking(Guid id, CancellationToken token)
    {
        Combo? combo = await _unitOfWorks.ComboRepository.GetByIdAsync(id);
        return combo != null;

    }

}

