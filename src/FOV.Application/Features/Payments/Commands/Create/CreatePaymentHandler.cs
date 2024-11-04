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
    private readonly UserManager<User> _userManager;
    private readonly OrderHub _orderHub;
    private const int ConversePoint = 1000;

    public CreatePaymentHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager, OrderHub orderHub)
    {
        _unitOfWorks = unitOfWorks;
        _orderHub = orderHub;
        _userManager = userManager;
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
        User? user = null;

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            user = await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
            if (user != null && request.UsePoints && request.PointsToApply.HasValue)
            {
                var availablePoints = user.Point;
                var pointsToUse = Math.Min(request.PointsToApply.Value, availablePoints);
                totalReduceMoney = pointsToUse;

                if (totalReduceMoney > totalAmount)
                {
                    totalReduceMoney = (int)totalAmount;
                    pointsToUse = totalReduceMoney / ConversePoint;
                }

                user.Point -= pointsToUse;
                await _userManager.UpdateAsync(user);
            }
        }

        var finalAmount = totalAmount - totalReduceMoney;

        if (finalAmount > 0 && user != null)
        {
            var pointsAwarded = (int)(finalAmount / ConversePoint);
            user.Point += pointsAwarded;
            await _userManager.UpdateAsync(user);
        }

        if (!string.IsNullOrEmpty(request.Feedback))
        {
            order.Feedback = request.Feedback;
        }

        order.OrderStatus = OrderStatus.Payment;
        _unitOfWorks.OrderRepository.Update(order);

        var payment = new Domain.Entities.PaymentAggregator.Payments
        {
            OrderId = request.OrderId,
            PaymentMethods = PaymentMethods.Cash,
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
