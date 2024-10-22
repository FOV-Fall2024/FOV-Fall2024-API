using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientUnits.Commands.CreateNewIngredientUnit;
public class CreateNewIngredientUnitValidator : AbstractValidator<CreateNewIngredientUnitCommand>
{
    public CreateNewIngredientUnitValidator(CheckIngredientParentIdValidator rule)
    {
        RuleFor(x => x.UnitName)
          .NotEmpty().WithMessage("Tên đơn vị không được để trống.")
          .Length(1, 100).WithMessage("Tên đơn vị phải từ 1 đến 100 ký tự.");

        RuleFor(x => x.ConversionFactor)
            .GreaterThan(0).WithMessage("Hệ số chuyển đổi phải lớn hơn 0.");

        RuleFor(x => x.IngredientUnitParentId)
            .NotEqual(Guid.Empty).WithMessage("Mã đơn vị cha không được để trống.");

        RuleFor(x => x).SetValidator(rule);
        RuleFor(x => x.IngredientId)
            .NotEqual(Guid.Empty).WithMessage("Mã nguyên liệu không được để trống.");
    }
}

public sealed class CheckIngredientParentIdValidator : AbstractValidator<CreateNewIngredientUnitCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;

    public CheckIngredientParentIdValidator(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;

        RuleFor(command => command.IngredientId)
            .MustAsync(CheckIngredientId)
            .WithMessage("Không tìm thấy Id Nguyên Liệu");

        RuleFor(command => command)
            .MustAsync(IsNameUnique)
            .WithMessage("Tên đã tồn tại trong hệ thống.");
        RuleFor(command => command.IngredientUnitParentId)
          .MustAsync(CheckParentId)
          .WithMessage("Không Tìm thấy Id Nguyên liệu đơn vị");

    }

    private async Task<bool> CheckIngredientId(Guid parentId, CancellationToken token)
    {
        Ingredient? ingredientType = await _unitOfWorks.IngredientRepository.GetByIdAsync(parentId);
        return ingredientType != null;
    }

    private async Task<bool> IsNameUnique(CreateNewIngredientUnitCommand command, CancellationToken token)
    {
        IngredientUnit? exists = await _unitOfWorks.IngredientUnitRepository.FirstOrDefaultAsync(x => x.UnitName == command.UnitName && x.Ingredient.RestaurantId == _claimService.RestaurantId&& x.IngredientId == command.IngredientId,x => x.Ingredient);
        return exists == null;
    }

    private async Task<bool> CheckParentId(Guid parentId, CancellationToken token)
    {
        IngredientUnit? exists = await _unitOfWorks.IngredientUnitRepository.FirstOrDefaultAsync(x => x.IngredientId == parentId && x.Ingredient.RestaurantId == _claimService.RestaurantId,x => x.Ingredient);
        return exists == null;
    }



}
