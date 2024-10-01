﻿using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Dishes.Commons.Add;

public class AddProductValidator : AbstractValidator<AddProductCommand>
{
    public AddProductValidator(ProductValidator validations)
    {
        RuleFor(x => x.ProductId).NotEmpty().SetValidator(validations);
    }
}

public sealed class ProductValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;
    public ProductValidator(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;
        RuleFor(name => name)
             .MustAsync(CheckDuplicateProductId)
             .WithMessage("Món ăn này đã có trong hệ thống");
    }

    private async Task<bool> CheckDuplicateProductId(Guid productId, CancellationToken cancellationToken)
    {
        Dish? product = await _unitOfWorks.DishRepository.FirstOrDefaultAsync(x => x.RestaurantId == _claimService.RestaurantId && x.DishGeneralId == productId);
        return product == null;
    }
}