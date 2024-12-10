using FluentValidation;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientMeasures.Commands.Create;
public class CreateIngredientMeasureValidator : AbstractValidator<CreateIngredientMeasureCommand>
{
    public CreateIngredientMeasureValidator(IngredientMeasureNameValidator nameValidator)
    {
        RuleFor(x => x.IngredientMeasureName).SetValidator(nameValidator);
    }
}

public sealed class IngredientMeasureNameValidator : AbstractValidator<string>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public IngredientMeasureNameValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(IngredientType => IngredientType)
           .MustAsync(CheckIsExist)
           .WithMessage("Tên đơn vị đã được dùng trong hệ thống");
    }

    private async Task<bool> CheckIsExist(string name, CancellationToken token)
    {
        IngredientMeasure? ingredientType = await _unitOfWorks.IngredientMeasureRepository.FirstOrDefaultAsync(x => x.IngredientMeasureName == name);
        return ingredientType == null;
    }

}
