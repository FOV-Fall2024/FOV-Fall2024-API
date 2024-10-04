using FluentValidation;
using FOV.Application.Features.IngredientGenerals.Commands.Active;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientGenerals.Commands.Update;

public class UpdateIngredientGeneralValidator : AbstractValidator<UpdateIngredientGeneralCommand>
{
    public UpdateIngredientGeneralValidator(IngredientGeneralIdValidator validator, IngredientNameValidator name)
    {
        RuleFor(x => x.Id).NotEmpty().SetValidator(validator);
        RuleFor(x => x.IngredientGeneralName).NotEmpty().SetValidator(name);
    }
}

public sealed class IngredientNameValidator : AbstractValidator<string>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public IngredientNameValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(name => name).MustAsync(CheckDuplicateName).WithMessage("Tên này đã có trong hệ thống");

    }

    private async Task<bool> CheckDuplicateName(string name, CancellationToken token)
    {
        IngredientGeneral? ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientName == name);
        return ingredientGeneral == null;
    }
}
