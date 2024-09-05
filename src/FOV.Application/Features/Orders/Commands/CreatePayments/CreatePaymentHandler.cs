using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.PaymentAggregator;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.CreatePayments;
public record CreatePaymentCommands(Guid OrderId, Guid PaymentMethodId) : IRequest<Guid>;
public class CreatePaymentHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreatePaymentCommands, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreatePaymentCommands request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Order not found!");

        var payment = new Payments
        {
            OrderId = request.OrderId,
            PaymentMethodId = request.PaymentMethodId,
            PaymentDate = DateTime.UtcNow,
            Amount = order.TotalPrice,
            PaymentStatus = PaymentStatus.Pending
        };

        await _unitOfWorks.PaymentRepository.AddAsync(payment);
        await _unitOfWorks.SaveChangeAsync();

        return payment.Id;
    }
}
