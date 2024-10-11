using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Dishes.Commons.Inactive;
public class InactiveProductValidator : AbstractValidator<InactiveProductCommand>
{
    public InactiveProductValidator(CheckProductIdValidator IdChecking)
    {
        RuleFor(x => x.Id).SetValidator(IdChecking);
    }
}

public class CheckProductIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;
    public CheckProductIdValidator(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;


    }

    private async Task<bool> CheckId(Guid dishId)
    {
        Dish? dish = await _unitOfWorks.DishRepository.FirstOrDefaultAsync(x => x.Id == dishId && x.RestaurantId == _claimService.RestaurantId);
        return dish != null;
    }
}
