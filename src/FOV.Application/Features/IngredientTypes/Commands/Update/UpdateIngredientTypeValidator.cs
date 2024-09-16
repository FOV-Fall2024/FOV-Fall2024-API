using FluentValidation;
using FOV.Application.Features.IngredientTypes.Commands.CreateChild;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientTypes.Commands.Update;
public class UpdateIngredientTypeValidator : AbstractValidator<UpdateIngredientTypeCommand>
{
    public UpdateIngredientTypeValidator(IngredientTypeValidator validator, CheckIngredientParentIdValidator validations)
    {
        RuleFor(x => x.Name).NotEmpty().SetValidator(validator);
        RuleFor(x => x.Id).NotEmpty().SetValidator(validations);
    }
}


public sealed class IngredientTypeValidator : AbstractValidator<string>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public IngredientTypeValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;

        RuleFor(name => name)
            .MustAsync(CheckDuplicateName)
            .WithMessage("Name is unique :>");

    }

    private async Task<bool> CheckDuplicateName(string name, CancellationToken token)
    {
        IngredientType? ingredientType = await _unitOfWorks.IngredientTypeRepository.FirstOrDefaultAsync(x => x.IngredientName == name);
        return ingredientType != null;
    }
}
