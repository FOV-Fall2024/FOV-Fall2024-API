using FluentValidation;
using FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.DishGenerals.Commands.AddIngredient;

public class AddIngredientValidator : AbstractValidator<AddIngredientInProductCommand>
{
    public AddIngredientValidator(CheckIdInGeneralValidator idChecking, CheckDishGeneralIdValidator dishId)
    {
        RuleFor(x => x).SetValidator(idChecking);
        RuleFor(x => x.Id).SetValidator(dishId);
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

        RuleFor(command => command).MustAsync(CheckQuantity).WithMessage("Không được nhập số âm");
    }

    private async Task<bool> CheckId(AddIngredientInProductCommand command, CancellationToken token)
    {
        foreach (var ingredient in command.IngredientAdds)
        {
            DishIngredientGeneral? dishIngredientGeneral = await _unitOfWorks.DishIngredientGeneralRepository
            .FirstOrDefaultAsync(x => x.DishGeneralId == command.Id && x.IngredientGeneralId == ingredient.IngredientId);
            if (dishIngredientGeneral != null) return false;
        }
        return true;

    }


    private async Task<bool> CheckQuantity(AddIngredientInProductCommand command, CancellationToken token)
    {
        foreach (var ingredient in command.IngredientAdds)
        {
            if (ingredient.Quantity <= 0) return false;
        }
        return true;
    }
}
