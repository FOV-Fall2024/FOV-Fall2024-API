using FluentValidation;
using FOV.Application.Features.Categories.Commands.Add;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Categories.Commands.Update;
public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryValidator(CheckCategoryIdValidator idValidator, CheckDuplicateName nameValidator)
    {
        RuleFor(x => x.CategoryName).NotEmpty().SetValidator(nameValidator);
        RuleFor(x => x.Id).NotEmpty().SetValidator(idValidator);
    }
}

public sealed class CheckCategoryIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public CheckCategoryIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(categoryId => categoryId).MustAsync(CheckExistId).WithMessage("Không tìm thấy loại");
    }

    private async Task<bool> CheckExistId(Guid categoryId, CancellationToken token)
    {
        Category? category = await _unitOfWorks.CategoryRepository.GetByIdAsync(categoryId);
        return category != null;
    }
}
