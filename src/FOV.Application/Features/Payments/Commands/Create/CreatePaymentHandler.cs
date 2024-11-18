using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FOV.Application.Common.Exceptions;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using FOV.Infrastructure.Notifications.Web.SignalR.Notification.Setup;

namespace FOV.Application.Features.Payments.Commands.Create;

public sealed record CreatePaymentCommands(
    string? PhoneNumber, 
    bool UsePoints, 
    int? PointsToApply) : IRequest<Guid> 
{
    [JsonIgnore]
    public Guid OrderId { get; init; }
    [JsonIgnore]
    public string? Feedback { get; init; }
}

public record FeedbackRequest
{
    public string? Feedback { get; init; }
}

public class CreatePaymentHandler : IRequestHandler<CreatePaymentCommands, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly OrderHub _orderHub;
    private readonly NotificationHub _notificationHub;
    private const int ConversePoint = 1000;

    public CreatePaymentHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, NotificationHub notificationHub)
    {
        _unitOfWorks = unitOfWorks;
        _orderHub = orderHub;
        _notificationHub = notificationHub;
    }

    public async Task<Guid> Handle(CreatePaymentCommands request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails, o => o.Payments)
            ?? throw new Exception("Không tìm thấy đơn hàng nào");

        if (order.Payments.Any(p => p.PaymentStatus == PaymentStatus.Paid))
        {
            throw new AppException("Đơn hàng đã được thanh toán.");
        }

        if (order.OrderStatus == OrderStatus.Payment)
        {
            throw new Exception("Đơn hàng đang được thanh toán");
        }

        var totalAmount = order.OrderDetails
            .Where(od => od.Quantity > od.RefundQuantity)
            .Sum(od => (od.Quantity - od.RefundQuantity) * od.Price);

        if (totalAmount == 0)
        {
            throw new Exception("No valid items for payment.");
        }

        var totalReduceMoney = 0;
        Customer? customer = null;

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            customer = await _unitOfWorks.CustomerRepository.FirstOrDefaultAsync(c => c.PhoneNumber == request.PhoneNumber);
            if (customer != null && request.UsePoints && request.PointsToApply.HasValue)
            {
                var availablePoints = customer.Point;
                var pointsToUse = Math.Min(request.PointsToApply.Value, availablePoints);
                totalReduceMoney = pointsToUse;

                if (totalReduceMoney > totalAmount)
                {
                    totalReduceMoney = (int)totalAmount;
                    pointsToUse = totalReduceMoney / ConversePoint;
                }

                customer.Point -= pointsToUse;
                _unitOfWorks.CustomerRepository.Update(customer);
            }
        }

        var finalAmount = totalAmount - totalReduceMoney;

        if (finalAmount > 0 && customer != null)
        {
            var pointsAwarded = (int)(finalAmount / ConversePoint);
            customer.Point += pointsAwarded;
            _unitOfWorks.CustomerRepository.Update(customer);
        }

        if (!string.IsNullOrEmpty(request.Feedback))
        {
            order.Feedback = request.Feedback;
        }

        order.OrderStatus = OrderStatus.Payment;
        _unitOfWorks.OrderRepository.Update(order);

        var employee = order.Users ?? throw new AppException("Không có nhân viên hợp lệ");
        var userId = employee.Id;

        var payment = new Domain.Entities.PaymentAggregator.Payments
        {
            OrderId = request.OrderId,
            PaymentMethods = PaymentMethods.Cash,
            PaymentDate = DateTime.UtcNow,
            Amount = finalAmount > 0 ? finalAmount : 0,
            ReduceAmount = totalReduceMoney,
            FinalAmount = finalAmount,
            PaymentStatus = PaymentStatus.Pending
        };

        await _unitOfWorks.PaymentRepository.AddAsync(payment);
        await _unitOfWorks.SaveChangeAsync();

        //await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());
        await _notificationHub.SendPaymentNotificationToWaiter(userId, order.Id);

        return payment.Id;
    }
}
