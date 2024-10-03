using FluentValidation;
using FOV.Application.Features.IngredientGenerals.Commands.Update;

namespace FOV.Application.Features.IngredientGenerals.Commands.Create;

public class CreateIngredientGeneralValidator : AbstractValidator<CreateIngredientGeneralCommand>
{
    public CreateIngredientGeneralValidator(IngredientNameValidator name)
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().SetValidator(name);
        RuleFor(x => x.Description).NotEmpty().NotNull();
        RuleFor(x => x.IngredientType).NotEmpty().NotNull();
        RuleFor(x => x.IngredientMeasureType).NotEmpty().NotNull().InclusiveBetween(1, 4);
    }
}

//public sealed class IngredientGeneralNameValidator : AbstractValidator<string>
//{

//    private readonly IUnitOfWorks _unitOfWorks;


//    public IngredientGeneralNameValidator(IUnitOfWorks unitOfWorks)
//    {
//        _unitOfWorks = unitOfWorks;

//        RuleFor(name => name)
//            .MustAsync(CheckDuplicateName)
//            .WithMessage("Name is unique :>");

//    }

//    private async Task<bool> CheckDuplicateName(string name, CancellationToken token)
//    {
//        IngredientGeneral? ingredientType = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientName == name);
//        return ingredientType == null;
//    }
//}
