using FluentValidation;
using FOV.Application.Features.Categories.Commands.AddNewChildCategory;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Categories.Commands.Add;
public class AddNewCategoryValidator : AbstractValidator<AddNewCategoryCommand>
{
    public AddNewCategoryValidator(CheckDuplicateName name)
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).SetValidator(name);
    }
}


public sealed class CheckDuplicateName : AbstractValidator<string>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public CheckDuplicateName(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(name => name)
            .MustAsync(CheckDuplicateCategoryName)
            .WithMessage("Name already exits in system");
    }

    private async Task<bool> CheckDuplicateCategoryName(string name, CancellationToken token)
    {
        Category? ingredientType = await _unitOfWorks.CategoryRepository.FirstOrDefaultAsync(x => x.CategoryName == name);
        return ingredientType == null;
    }
}
