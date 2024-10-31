using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace FOV.Application.Features.Payments.Commands.Create;

public record CreatePaymentCommands(PaymentMethods PaymentMethods, string? PhoneNumber) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
}

public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommands, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly UserManager<User> _userManager;
    private readonly OrderHub _orderHub;
    private const int ConversePoint = 1000;

    public CreatePaymentHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, UserManager<User> userManager)
    {
        _unitOfWorks = unitOfWorks;
        _orderHub = orderHub;
        _userManager = userManager;
    }

    public async Task<Guid> Handle(CreatePaymentCommands request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng nào");

        var totalAmount = order.OrderDetails
            .Where(od => od.Quantity > od.RefundQuantity)
            .Sum(od => (od.Quantity - od.RefundQuantity) * od.Price);

        if (totalAmount == 0)
        {
            throw new Exception("No valid items for payment.");
        }

        var totalReduceMoney = 0;
        User? user = null;

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            user = await _userManager.Users.Include(x => x.Customer).FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user != null)
            {
                var availablePoint = user.Customer.Point;
                totalReduceMoney = availablePoint * ConversePoint;
                if (totalReduceMoney > totalAmount)
                {
                    totalReduceMoney = (int)totalAmount;
                }
                user.Customer.Point -= (totalReduceMoney / ConversePoint);
                _unitOfWorks.CustomerRepository.Update(user.Customer);
            }
        }

        var finalAmount = totalAmount - totalReduceMoney;

        if (finalAmount > 0 && user != null)
        {
            var pointsAwarded = (int)(finalAmount / ConversePoint);
            user.Customer.Point += pointsAwarded;
            _unitOfWorks.CustomerRepository.Update(user.Customer);
        }

        order.OrderStatus = OrderStatus.Payment;
        _unitOfWorks.OrderRepository.Update(order);

        var payment = new Domain.Entities.PaymentAggregator.Payments
        {
            OrderId = request.OrderId,
            PaymentMethods = request.PaymentMethods,
            PaymentDate = DateTime.UtcNow,
            Amount = finalAmount > 0 ? finalAmount : 0,
            PaymentStatus = PaymentStatus.Pending
        };

        await _unitOfWorks.PaymentRepository.AddAsync(payment);
        await _unitOfWorks.SaveChangeAsync();
        await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());

        return payment.Id;
    }
}
