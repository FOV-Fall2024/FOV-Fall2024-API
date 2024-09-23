using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Payments.Commands.Create;
public record CreatePaymentCommands(PaymentMethods PaymentMethods) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
}
public class CreatePaymentHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreatePaymentCommands, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreatePaymentCommands request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng nào");

        var totalAmount = order.OrderDetails
            .Where(od => od.Status != OrderDetailsStatus.Refund)
            .Sum(od => od.Quantity * od.Price);

        if (totalAmount == 0)
        {
            throw new Exception("No valid items for payment.");
        }

        var payment = new Domain.Entities.PaymentAggregator.Payments
        {
            OrderId = request.OrderId,
            PaymentMethods = request.PaymentMethods,
            PaymentDate = DateTime.UtcNow,
            Amount = totalAmount,
            PaymentStatus = PaymentStatus.Pending
        };

        await _unitOfWorks.PaymentRepository.AddAsync(payment);
        await _unitOfWorks.SaveChangeAsync();

        return payment.Id;
    }
}
