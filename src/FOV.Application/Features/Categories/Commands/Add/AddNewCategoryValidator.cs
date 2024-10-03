using FluentValidation;
using FOV.Application.Features.Categories.Commands.AddNewChildCategory;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Categories.Commands.Add;
public class AddNewCategoryValidator : AbstractValidator<AddNewCategoryCommand>
{
    public AddNewCategoryValidator(CheckDuplicateName name)
    {
        RuleFor(x => x.CategoryName).NotEmpty();
        RuleFor(x => x.CategoryName).SetValidator(name);
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
            .WithMessage("Tên này đã tồn tại trong hệ thống");
    }

    private async Task<bool> CheckDuplicateCategoryName(string name, CancellationToken token)
    {
        Category? ingredientType = await _unitOfWorks.CategoryRepository.FirstOrDefaultAsync(x => x.CategoryName == name);
        return ingredientType == null;
    }
}
