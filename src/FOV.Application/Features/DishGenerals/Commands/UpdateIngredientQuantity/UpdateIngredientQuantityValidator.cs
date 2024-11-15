using FluentValidation;
using FOV.Application.Features.DishGenerals.Commands.Update;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;

public class UpdateIngredientQuantityValidator : AbstractValidator<UpdateIngredientQuantityCommand>
{
    public UpdateIngredientQuantityValidator(CheckIdInGeneralValidator checkIdPairValidator, CheckDishGeneralIdValidator dishId, CheckDishGeneralStateValidator stateCheck)
    {
        RuleFor(x => x).SetValidator(checkIdPairValidator);
        RuleFor(x => x.DishGeneralId).SetValidator(dishId).SetValidator(stateCheck);
    }
}

public class CheckIdInGeneralValidator : AbstractValidator<UpdateIngredientQuantityCommand>
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

    private async Task<bool> CheckId(UpdateIngredientQuantityCommand command, CancellationToken token)
    {
        foreach (var ingredient in command.UpdateIngredient)
        {
            DishIngredientGeneral? dishIngredientGeneral = await _unitOfWorks.DishIngredientGeneralRepository
            .FirstOrDefaultAsync(x => x.DishGeneralId == command.DishGeneralId && x.IngredientGeneralId == ingredient.IngredientGeneralId);
            if (dishIngredientGeneral == null) return false;
        }
        return true;
    }

    private async Task<bool> CheckQuantity(UpdateIngredientQuantityCommand command, CancellationToken token)
    {
        foreach (var ingredient in command.UpdateIngredient)
        {
            if (ingredient.Quantity <= 0) return false;
        }
        return true;
    }
}


public class CheckDishGeneralIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CheckDishGeneralIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(command => command)
            .MustAsync(CheckId)
            .WithMessage("ID món ăn  không hợp lệ");

    }

    private async Task<bool> CheckId(Guid command, CancellationToken token)
    {
        DishGeneral? dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(command);
        return dishGeneral != null;

    }

}
