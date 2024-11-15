using FluentValidation;
using FOV.Application.Features.DishGenerals.Commands.Update;
using FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.DishGenerals.Commands.RemoveIngredient;
public class RemoveIngredientValidator : AbstractValidator<RemoveIngredientCommand>
{
    public RemoveIngredientValidator(CheckIdInGeneralRemoveValidator checkValidator, CheckDishGeneralIdValidator dishId, CheckDishGeneralStateValidator stateValidator)
    {
        RuleFor(x => x).SetValidator(checkValidator);
        RuleFor(x => x.ProductId).SetValidator(dishId).SetValidator(stateValidator);
    }
}


public class CheckIdInGeneralRemoveValidator : AbstractValidator<RemoveIngredientCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CheckIdInGeneralRemoveValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(command => command)
            .MustAsync(CheckId)
            .WithMessage("ID không hợp lệ hoặc nguyên liệu đã tồn tại.");
    }

    private async Task<bool> CheckId(RemoveIngredientCommand tuple, CancellationToken token)
    {
        foreach (var ingredient in tuple.IngredientId)
        {
            DishIngredientGeneral? dishIngredientGeneral = await _unitOfWorks.DishIngredientGeneralRepository
           .FirstOrDefaultAsync(x => x.DishGeneralId == tuple.ProductId && x.IngredientGeneralId == ingredient);

            if (dishIngredientGeneral == null) return false;
        }
        return true;
    }
}
