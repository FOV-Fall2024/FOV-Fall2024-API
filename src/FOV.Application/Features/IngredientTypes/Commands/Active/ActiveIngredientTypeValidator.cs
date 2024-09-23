using Elastic.Clients.Elasticsearch;
using FluentValidation;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientTypes.Commands.Active;
public class ActiveIngredientTypeValidator : AbstractValidator<ActiveIngredientTypeCommand>
{
    public ActiveIngredientTypeValidator(IngredientIdValidator validator)
    {
        RuleFor(x => x.Id).NotEmpty().SetValidator(validator);

    }
}


public sealed class IngredientIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public IngredientIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(id => id)
            .MustAsync(CheckExist)
             .WithMessage("Không tìm thấy nguyên liệu");
    }

    private async Task<bool> CheckExist(Guid id, CancellationToken token)
    {
        IngredientType? ingredientType = await _unitOfWorks.IngredientTypeRepository.GetByIdAsync(id);
        return ingredientType != null;
    }
}
