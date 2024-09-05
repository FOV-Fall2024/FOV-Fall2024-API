using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Payments.Commands.FinishPayment;
public sealed record FinishPaymentCommand(Guid OrderId) : IRequest<Guid>;

public class FinishPaymentHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<FinishPaymentCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(FinishPaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.Payments)
            ?? throw new Exception("Order not found!");

        var payment = order.Payments.FirstOrDefault();
        if (payment == null)
        {
            throw new Exception("Payment not found!");
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

        await _unitOfWorks.SaveChangeAsync();

        return payment.Id;
    }
}
