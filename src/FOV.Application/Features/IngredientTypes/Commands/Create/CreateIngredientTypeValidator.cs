﻿using FluentValidation;
using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Application.Features.IngredientTypes.Commands.Update;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.IngredientTypes.Commands.Create;
internal class CreateIngredientTypeValidator : AbstractValidator<CreateChildIngredientTypeCommand>
{
    public CreateIngredientTypeValidator(IngredientTypeValidator validator, CheckIngredientParentIdValidator validationRules)
    {
        RuleFor(x => x.Name).NotEmpty().SetValidator(validator);

    }
}


public sealed class CheckIngredientParentIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CheckIngredientParentIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(parentId => parentId)
            .MustAsync(CheckParentId)
            .WithMessage("Not found  Ingredient");
    }

    private async Task<bool> CheckParentId(Guid parentId, CancellationToken token)
    {
        IngredientType? ingredientType = await _unitOfWorks.IngredientTypeRepository.GetByIdAsync(parentId);
        return ingredientType != null;
    }


}