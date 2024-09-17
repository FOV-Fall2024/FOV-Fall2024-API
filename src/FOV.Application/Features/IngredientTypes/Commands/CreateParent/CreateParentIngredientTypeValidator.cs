using FluentValidation;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientTypes.Commands.Create;

public sealed class CreateParentIngredientTypeValidator : AbstractValidator<CreateIngredientTypeCommand>
{
    public CreateParentIngredientTypeValidator(IngredientTypeValidator validator)
    {
        RuleFor(x => x.Name).NotEmpty().SetValidator(validator);
        RuleFor(x => x.Description).NotNull();

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
            .WithMessage("Asset must not be in assigned state");

    }

    private async Task<bool> CheckDuplicateName(string name, CancellationToken token)
    {
        IngredientType? ingredientType = await _unitOfWorks.IngredientTypeRepository.FirstOrDefaultAsync(x => x.IngredientName == name);
        return ingredientType != null;
    }

}
