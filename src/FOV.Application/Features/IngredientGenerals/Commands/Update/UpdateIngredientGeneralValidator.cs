using FluentValidation;
using FOV.Application.Features.IngredientGenerals.Commands.Active;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientGenerals.Commands.Update;

public sealed class IngredientNameValidator : AbstractValidator<UpdateIngredientGeneralCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public IngredientNameValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(x => x).MustAsync(CheckDuplicateName).WithMessage("Tên này đã có trong hệ thống");
    }
    private async Task<bool> CheckDuplicateName(UpdateIngredientGeneralCommand command, CancellationToken token)
    {
        IngredientGeneral? ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientName == command.IngredientGeneralName && x.Id != command.Id);
        return ingredientGeneral == null;
    }
}

public class UpdateIngredientGeneralValidator : AbstractValidator<UpdateIngredientGeneralCommand>
{
    public UpdateIngredientGeneralValidator(IngredientGeneralIdValidator validator, IngredientNameValidator nameValidator)
    {
        RuleFor(x => x.Id).NotEmpty().SetValidator(validator);
        RuleFor(x => x).SetValidator(nameValidator);
    }
}
