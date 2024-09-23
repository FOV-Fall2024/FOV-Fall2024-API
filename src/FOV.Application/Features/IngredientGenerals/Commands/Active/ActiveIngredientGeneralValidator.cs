using FluentValidation;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientGenerals.Commands.Active;
public class ActiveIngredientGeneralValidator : AbstractValidator<ActiveIngredientGeneralCommand>
{
    public ActiveIngredientGeneralValidator(IngredientGeneralIdValidator checkId)
    {
        RuleFor(x => x.Id).NotEmpty().SetValidator(checkId);
    }
}


public sealed class IngredientGeneralIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public IngredientGeneralIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(id => id)
      .MustAsync(CheckExist)
       .WithMessage("Không tìm thấy nguyên liệu gốc");

    }

    private async Task<bool> CheckExist(Guid ingredientGeneralId, CancellationToken token)
    {
        IngredientGeneral? ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.GetByIdAsync(ingredientGeneralId);
        return ingredientGeneral != null;
    }
}
