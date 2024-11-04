using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Payments.Commands.FinishPayment;
public sealed record FinishPaymentCommand(Guid OrderId) : IRequest<Guid>;

public class FinishPaymentHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub) : IRequestHandler<FinishPaymentCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;

    public async Task<Guid> Handle(FinishPaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.Payments, t => t.Table)
            ?? throw new Exception("Đơn hàng không tồn tại");

        var payment = order.Payments.FirstOrDefault();
        if (payment == null)
        {
            throw new Exception("Thông tin thanh toán không tồn tại");
        }

        if (payment.PaymentStatus != PaymentStatus.Paid)
        {
            payment.PaymentStatus = PaymentStatus.Paid;
            _unitOfWorks.PaymentRepository.Update(payment);
        }

        if (order.OrderStatus != OrderStatus.Finish)
        {
            order.OrderStatus = OrderStatus.Finish;
            _unitOfWorks.OrderRepository.Update(order);
        }

        if (order.Table != null)
        {
            order.Table.TableStatus = TableStatus.Available;
            _unitOfWorks.TableRepository.Update(order.Table);
        }

        await _unitOfWorks.SaveChangeAsync();
        await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());

        return payment.Id;
    }
}
