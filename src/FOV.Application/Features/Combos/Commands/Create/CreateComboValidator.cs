using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Combos.Commands.Create;

class CreateComboValidator : AbstractValidator<CreateComboCommand>
{
    public CreateComboValidator(PriceValidator priceValidator,ComboNameValidator nameValidator)
    {
        RuleFor(x => x.Price)
            .MustAsync(async (command, price, cancellation) =>
                await priceValidator.CheckPrice(price, command.ProductInCombos, cancellation))
            .WithMessage("Price must be less than the total price of the selected dishes.");
        RuleFor(x => x.ComboName).SetValidator(nameValidator);
              
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

public sealed class ComboNameValidator : AbstractValidator<string>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;

    public ComboNameValidator(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;

        // Validation rule to check combo name uniqueness
        RuleFor(name => name)
            .MustAsync(CheckNameCombo)
            .WithMessage("Tên đã được sử dụng trong hệ thống");
    }

    public async Task<bool> CheckNameCombo(string comboName, CancellationToken token)
    {
        // Ensure RestaurantId is available
        var restaurantId = _claimService.RestaurantId;
        if (restaurantId == null)
        {
            throw new InvalidOperationException("Restaurant ID is not available.");
        }

        // Query to check if the combo name already exists for this restaurant
        Combo? combo = await _unitOfWorks.ComboRepository
            .FirstOrDefaultAsync(x => x.ComboName == comboName && x.RestaurantId == restaurantId, token);

        // Return true if combo name is unique (i.e., combo is null)
        return combo == null;
    }
}


