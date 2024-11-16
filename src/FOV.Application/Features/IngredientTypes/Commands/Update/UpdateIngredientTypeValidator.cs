using FluentValidation;
using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientTypes.Commands.Update;
public class UpdateIngredientTypeValidator : AbstractValidator<UpdateIngredientTypeCommand>
{
    public UpdateIngredientTypeValidator(IngredientTypeValidator validator, CheckIngredientParentIdValidator validations)
    {
        RuleFor(x => x).SetValidator(validator);
        RuleFor(x => x.Id).NotEmpty().SetValidator(validations);
    }
}


public sealed class IngredientTypeValidator : AbstractValidator<UpdateIngredientTypeCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public IngredientTypeValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;

        RuleFor(name => name)
            .MustAsync(CheckDuplicateName)
            .WithMessage("Tên đã tồn tại trong hệ thống");

    }

    private async Task<bool> CheckDuplicateName(UpdateIngredientTypeCommand name, CancellationToken token)
    {
        var existingIngredient = await _unitOfWorks.IngredientTypeRepository
           .FirstOrDefaultAsync(x => x.IngredientName == name.IngredientTypeName && x.Id != name.Id);
        return existingIngredient == null;
    }
}
