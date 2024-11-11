using FluentValidation;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientGenerals.Commands.Create;

public class CreateIngredientGeneralValidator : AbstractValidator<CreateIngredientGeneralCommand>
{
    public CreateIngredientGeneralValidator(IngredientGeneralNameValidator name,IngredientValidator ingredientTypeId)
    {
        RuleFor(x => x.IngredientGeneralName).NotEmpty().NotNull().SetValidator(name);
        RuleFor(x => x.IngredientGeneralDescription).NotNull();
        RuleFor(x => x.IngredientType).NotNull().SetValidator(ingredientTypeId);
    }
}


public sealed class IngredientValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public IngredientValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(IngredientType => IngredientType)
           .MustAsync(CheckIsExist)
           .WithMessage("Không tìm thấy loại nguyên liệu");
    }

    private async Task<bool> CheckIsExist(Guid Id, CancellationToken token)
    {
        IngredientType? ingredientType = await _unitOfWorks.IngredientTypeRepository.FirstOrDefaultAsync(x => x.Id == Id );
        return ingredientType != null;
    }

}

public sealed class IngredientGeneralNameValidator : AbstractValidator<string>
{

    private readonly IUnitOfWorks _unitOfWorks;


    public IngredientGeneralNameValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;

        RuleFor(Name => Name)
            .MustAsync(CheckDuplicateName)
            .WithMessage("Tên không được trùng lập");

    }

    private async Task<bool> CheckDuplicateName(string name, CancellationToken token)
    {
        IngredientGeneral? ingredientType = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientName == name);
        return ingredientType == null;
    }
}
