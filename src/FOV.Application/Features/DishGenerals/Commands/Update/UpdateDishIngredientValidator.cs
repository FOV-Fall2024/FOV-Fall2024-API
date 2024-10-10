using Elastic.Clients.Elasticsearch;
using FluentValidation;
using FOV.Application.Features.Categories.Commands.Update;
using FOV.Application.Features.DishGenerals.Commands.Create;
using FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.DishGenerals.Commands.Update;
public class UpdateDishIngredientValidator : AbstractValidator<UpdateProductGeneralCommand>
{
    public UpdateDishIngredientValidator(CheckDishGeneralNameUpdateValidator nameCheck, CheckCategoryIdValidator categoryIdCheck, CheckDishGeneralIdValidator idChecking)
    {
        RuleFor(x => x).SetValidator(nameCheck);
        RuleFor(x => x.CategoryId).SetValidator(categoryIdCheck);
        RuleFor(x => x.Id).SetValidator(idChecking);
    }
}

public sealed class CheckDishGeneralNameUpdateValidator : AbstractValidator<UpdateProductGeneralCommand>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CheckDishGeneralNameUpdateValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;

        RuleFor(command => command)
            .MustAsync(CheckName).WithMessage("Tên đã có trong hệ thống");
    }

    private async Task<bool> CheckName(UpdateProductGeneralCommand command, CancellationToken token)
    {
        // Check if the name exists for a different dish in the database
        DishGeneral? existingDish = await _unitOfWorks.DishGeneralRepository
            .FirstOrDefaultAsync(x => x.DishName == command.DishGeneralName && x.Id != command.Id);

        return existingDish == null;
    }
}

