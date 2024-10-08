using FluentValidation;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;

public class UpdateIngredientQuantityValidator : AbstractValidator<UpdateIngredientQuantityCommand>
{
    public UpdateIngredientQuantityValidator(CheckIdInGeneralValidator checkIdPairValidator)
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0)
            .WithMessage("Số lượng phải lớn hơn 0.");

        RuleFor(x => x).SetValidator(checkIdPairValidator);
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
    }

    private async Task<bool> CheckId(UpdateIngredientQuantityCommand tuple, CancellationToken token)
    {
        DishIngredientGeneral? dishIngredientGeneral = await _unitOfWorks.DishIngredientGeneralRepository
            .FirstOrDefaultAsync(x => x.DishGeneralId == tuple.DishGeneralId && x.IngredientGeneralId == tuple.IngredientGeneralId);
        return dishIngredientGeneral != null;
    }
}
