using FluentValidation;
using FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.DishGenerals.Commands.RemoveIngredient;
public class RemoveIngredientValidator : AbstractValidator<RemoveIngredientCommand>
{
    public RemoveIngredientValidator(CheckIdInGeneralRemoveValidator checkValidator)
    {
        RuleFor(x => x).SetValidator(checkValidator);
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
        DishIngredientGeneral? dishIngredientGeneral = await _unitOfWorks.DishIngredientGeneralRepository
            .FirstOrDefaultAsync(x => x.DishGeneralId == tuple.productId && x.IngredientGeneralId == tuple.IngredientId);
        return dishIngredientGeneral != null;
    }
}
