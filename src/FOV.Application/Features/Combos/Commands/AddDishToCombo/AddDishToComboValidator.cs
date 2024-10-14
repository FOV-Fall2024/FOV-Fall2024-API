using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.Combos.Commands.Active;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Combos.Commands.AddDishToCombo;
public class AddDishToComboValidator : AbstractValidator<AddDishToComboCommand>
{
    public AddDishToComboValidator(CheckComboIdValidator idChecking, CheckDishValidator dishChecking)
    {
        RuleFor(x => x.Id).SetValidator(idChecking);
        RuleFor(x => x.ProductAdding).SetValidator(dishChecking);

    }
}

public class CheckDishValidator : AbstractValidator<List<DishAddingCommand>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;
    public CheckDishValidator(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;

        RuleFor(id => id)
          .MustAsync(DishIdChecking)
          .WithMessage("Id món không trong hệ thống ");

        RuleFor(quantity => quantity)
        .MustAsync(DishQuantityChecking)
        .WithMessage("Số lượng không phù hợp ");

    }


    private async Task<bool> DishIdChecking(List<DishAddingCommand> dishes, CancellationToken token)
    {
        foreach (var dishCheck in dishes)
        {
            Dish? dish = await _unitOfWorks.DishRepository.FirstOrDefaultAsync(x => x.Id == dishCheck.DishId && x.RestaurantId == _claimService.RestaurantId);
            if (dish is null) return false;
        }
        return true;
    }

    private async Task<bool> DishQuantityChecking(List<DishAddingCommand> dishes, CancellationToken token)
    {
        foreach (var dishCheck in dishes)
        {
            if (dishCheck.Quantity <= 0) return false;
        }
        return true;
    }


}
