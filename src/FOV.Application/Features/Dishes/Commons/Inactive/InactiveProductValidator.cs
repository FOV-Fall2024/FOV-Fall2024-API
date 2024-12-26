using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
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

        RuleFor(dishId => dishId)
            .MustAsync(CheckId).WithMessage("Món ăn không tồn tại trong nhà hàng của bạn.")
            .MustAsync(CheckActiveOrders).WithMessage("Món ăn đang được sử dụng trong đơn hàng chưa hoàn thành.");
    }

    private async Task<bool> CheckId(Guid dishId, CancellationToken cancellationToken)
    {
        Dish? dish = await _unitOfWorks.DishRepository.FirstOrDefaultAsync(
            x => x.Id == dishId && x.RestaurantId == _claimService.RestaurantId
        );
        return dish != null;
    }

    private async Task<bool> CheckActiveOrders(Guid dishId, CancellationToken cancellationToken)
    {
        var activeOrders = await _unitOfWorks.OrderRepository.GetAllAsync(
            x => x.OrderDetails.Where(od => od.ProductId == dishId)
        );

        return !activeOrders.Any(order =>
            order.OrderStatus != OrderStatus.Finish && order.OrderStatus != OrderStatus.Canceled
        );
    }
}
