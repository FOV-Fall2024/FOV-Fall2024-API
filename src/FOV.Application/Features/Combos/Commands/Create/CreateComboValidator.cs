using FluentValidation;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Combos.Commands.Create;

class CreateComboValidator : AbstractValidator<CreateComboCommand>
{
    public CreateComboValidator(PriceValidator priceValidator)
    {
        RuleFor(x => x.Price)
            .MustAsync(async (command, price, cancellation) =>
                await priceValidator.CheckPrice(price, command.ProductInCombos, cancellation))
            .WithMessage("Price must be less than the total price of the selected dishes.");
    }
}

public sealed class PriceValidator : AbstractValidator<decimal>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public PriceValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<bool> CheckPrice(decimal price, List<ProductInCombo> productIds, CancellationToken token)
    {
        decimal totalPrice = 0;
        foreach (var dishCheck in productIds)
        {
            Dish? dish = await _unitOfWorks.DishRepository.GetByIdAsync(dishCheck.ProductId);
            totalPrice += dish?.Price ?? 0; // Use null-coalescing to avoid null references
        }
        return price < totalPrice; // Ensure the provided price is less than the total price of dishes
    }
}
