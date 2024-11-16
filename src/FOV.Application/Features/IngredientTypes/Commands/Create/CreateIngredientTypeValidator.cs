using FluentValidation;
using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Application.Features.IngredientTypes.Commands.Update;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientTypes.Commands.Create;
public class CreateIngredientTypeValidator : AbstractValidator<CreateChildIngredientTypeCommand>
{
    public CreateIngredientTypeValidator(IngredientTypeCheckNameValidator validator, CheckIngredientParentIdValidator validationRules)
    {
        RuleFor(x => x.IngredientTypeName).NotEmpty().SetValidator(validator);

    }
}

public sealed class IngredientTypeCheckNameValidator : AbstractValidator<string>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public IngredientTypeCheckNameValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;

        RuleFor(name => name)
            .MustAsync(CheckDuplicateName)
            .WithMessage("Tên đã tồn tại trong hệ thống");

    }

    private async Task<bool> CheckDuplicateName(string name, CancellationToken token)
    {
        var existingIngredient = await _unitOfWorks.IngredientTypeRepository
           .FirstOrDefaultAsync(x => x.IngredientName == name);
        return existingIngredient == null;
    }
}
public sealed class CheckIngredientParentIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CheckIngredientParentIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(parentId => parentId)
            .MustAsync(CheckParentId)
            .WithMessage("Không tìm thấy Id");
    }

    private async Task<bool> CheckParentId(Guid parentId, CancellationToken token)
    {
        IngredientType? ingredientType = await _unitOfWorks.IngredientTypeRepository.GetByIdAsync(parentId);
        return ingredientType != null;
    }


}
