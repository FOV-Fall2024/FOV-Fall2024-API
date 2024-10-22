using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.IngredientUnits.Commands.CreateNewIngredientUnit;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientUnits.Commands.Update;
public class UpdateIngredientUnitValidator : AbstractValidator<UpdateIngredientUnitCommand>
{
    public UpdateIngredientUnitValidator(CheckUpdateUnitValidator rule)
    {
        RuleFor(x => x.UnitName)
            .NotEmpty().WithMessage("Tên đơn vị không được để trống.")
            .Length(1, 100).WithMessage("Tên đơn vị phải từ 1 đến 100 ký tự.");

        RuleFor(x => x.ConversionFactor)
            .GreaterThan(0).WithMessage("Hệ số chuyển đổi phải lớn hơn 0.");

        RuleFor(x => x.IngredientUnitId)
            .NotEqual(Guid.Empty).WithMessage("Mã đơn vị không được để trống.");

        RuleFor(x => x).SetValidator(rule);
    }
}

public sealed class CheckUpdateUnitValidator : AbstractValidator<UpdateIngredientUnitCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;

    public CheckUpdateUnitValidator(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;

        RuleFor(command => command.IngredientUnitId)
            .MustAsync(CheckIngredientId)
            .WithMessage("Không tìm thấy Id Nguyên Liệu");

        RuleFor(command => command.UnitName)
            .MustAsync(IsNameUnique)
            .WithMessage("Tên đã tồn tại trong hệ thống.");

    }

    private async Task<bool> CheckIngredientId(Guid parentId, CancellationToken token)
    {
        IngredientType? ingredientType = await _unitOfWorks.IngredientTypeRepository.GetByIdAsync(parentId,x => x.Ingredients);
        return ingredientType != null;
    }

    private async Task<bool> IsNameUnique(string name, CancellationToken token)
    {
        IngredientUnit? exists = await _unitOfWorks.IngredientUnitRepository.FirstOrDefaultAsync(x => x.UnitName == name && x.Ingredient.RestaurantId == _claimService.RestaurantId,x => x.Ingredient);
        return exists == null;
    }

}
