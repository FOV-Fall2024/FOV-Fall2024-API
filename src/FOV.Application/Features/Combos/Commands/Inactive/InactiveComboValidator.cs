using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Combos.Commands.Inactive;

public class InactiveComboValidator : AbstractValidator<InactiveComboCommand>
{
    public InactiveComboValidator(CheckComboIdValidator idChecking)
    {
        RuleFor(x => x.ComboId).SetValidator(idChecking);
    }
}

public class CheckComboIdValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;

    public CheckComboIdValidator(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;

        RuleFor(comboId => comboId)
            .MustAsync(CheckComboExists).WithMessage("Combo không tồn tại trong nhà hàng của bạn.")
            .MustAsync(CheckActiveOrders).WithMessage("Combo đang được sử dụng trong đơn hàng chưa hoàn thành.");
    }

    private async Task<bool> CheckComboExists(Guid comboId, CancellationToken cancellationToken)
    {
        // Kiểm tra xem Combo có tồn tại và thuộc nhà hàng của người dùng hay không
        Combo? combo = await _unitOfWorks.ComboRepository.FirstOrDefaultAsync(
            x => x.Id == comboId && x.RestaurantId == _claimService.RestaurantId
        );
        return combo != null;
    }

    private async Task<bool> CheckActiveOrders(Guid comboId, CancellationToken cancellationToken)
    {
        // Kiểm tra xem Combo có được sử dụng trong bất kỳ đơn hàng chưa hoàn thành nào hay không
        var activeOrders = await _unitOfWorks.OrderRepository.GetAllAsync(
            x => x.OrderDetails.Where(od => od.ProductId == comboId)
        );

        return !activeOrders.Any(order =>
            order.OrderStatus != OrderStatus.Finish && order.OrderStatus != OrderStatus.Canceled
        );
    }
}
