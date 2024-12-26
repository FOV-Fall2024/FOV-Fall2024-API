using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Payments.Commands.ConfirmRecievedMoney;
public record ConfirmReceivedMoneyCommand(Guid OrderId) : IRequest<Guid>;
public class ConfirmReceivedMoneyHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ConfirmReceivedMoneyCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(ConfirmReceivedMoneyCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.Payments, t => t.Table, o => o.OrderDetails)
            ?? throw new AppException("Đơn hàng không tồn tại");

        var payment = order.Payments.FirstOrDefault();
        if (payment == null)
        {
            throw new AppException("Thông tin thanh toán không tồn tại");
        }
        if (payment.IsAdminConfirm == true)
        {
            throw new AppException("Đơn hàng đã được xác nhận trước đó");
        }
        payment.IsAdminConfirm = true;
        _unitOfWorks.PaymentRepository.Update(payment);
        await _unitOfWorks.SaveChangeAsync();

        return payment.Id;
    }
}
