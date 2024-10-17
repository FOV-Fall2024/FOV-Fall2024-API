using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Dishes.Queries.GetMenu;
public class GetMenuValidator : AbstractValidator<GetMenuCommand>
{
    public GetMenuValidator(CheckRestaurantIdValidator restaurantIdChecking)
    {
        RuleFor(x => x.RestaurantId).SetValidator(restaurantIdChecking);
    }
}

public class CheckRestaurantIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public CheckRestaurantIdValidator(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
        RuleFor(id => id).MustAsync(CheckId).WithMessage("Không tìm thấy Nhà hàng này trong hệ thống");

    }

    private async Task<bool> CheckId(Guid id, CancellationToken token)
    {
        Restaurant? restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(id);
        return restaurant != null;
    }
}
