using FluentValidation;
using FOV.Application.Features.Dishes.Commons.Inactive;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Dishes.Commons.Update;
public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductValidator(CheckProductIdValidator idChecking, CheckPriceValidator priceChecking)
    {
        RuleFor(x => x.ProductId).SetValidator(idChecking);
        RuleFor(x => x).SetValidator(priceChecking);
    }
}

public sealed class CheckPriceValidator : AbstractValidator<UpdateProductCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public CheckPriceValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(ingredientType => ingredientType)
           .MustAsync(CheckIsExist)
           .WithMessage("Giá không phù hợp");
    }

    private async Task<bool> CheckIsExist(UpdateProductCommand updateDish, CancellationToken token)
    {
        // Retrieve the existing Dish entity
        Dish? dish = await _unitOfWorks.DishRepository.GetByIdAsync(updateDish.ProductId);
        if (dish == null)
        {
            throw new Exception("Dish not found");
        }

        // Retrieve the associated DishGeneral entity
        DishGeneral dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync((Guid)dish.DishGeneralId)
            ?? throw new Exception("DishGeneral not found");

        // Calculate the maximum allowable price
        decimal maxAllowedPrice = dishGeneral.Price * dishGeneral.PercentagePriceDifference;

        // Check if the updated price exceeds the allowable price
        if (updateDish.Price > maxAllowedPrice)
        {
            return false; // Price exceeds the allowable range
        }

        return true; // Price is within the allowable range
    }

}

