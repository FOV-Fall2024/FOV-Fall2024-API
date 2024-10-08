using FluentValidation;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.DishGenerals.Commands.AddIngredient;

public class AddIngredientValidator : AbstractValidator<AddIngredientInProductCommand>
{
    public AddIngredientValidator(CheckIdInGeneralValidator idChecking)
    {
        RuleFor(x => x).SetValidator(idChecking);
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Số lượng phải lớn hơn 0.");
    }
}

public class CheckIdInGeneralValidator : AbstractValidator<AddIngredientInProductCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CheckIdInGeneralValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(command => command)
            .MustAsync(CheckId)
            .WithMessage("ID không hợp lệ hoặc nguyên liệu đã tồn tại.");
    }

    private async Task<bool> CheckId(AddIngredientInProductCommand command, CancellationToken token)
    {
        DishIngredientGeneral? dishIngredientGeneral = await _unitOfWorks.DishIngredientGeneralRepository
            .FirstOrDefaultAsync(x => x.DishGeneralId == command.Id && x.IngredientGeneralId == command.IngredientId);
        return dishIngredientGeneral == null;
    }
}
