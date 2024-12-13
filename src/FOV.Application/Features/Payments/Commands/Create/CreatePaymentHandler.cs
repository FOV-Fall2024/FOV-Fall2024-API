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
using FOV.Application.Common.Behaviours.Claim;
using FOV.Infrastructure.FCM;
using FOV.Infrastructure.FirebaseDB;

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
    private const int ConversePoint = 1000;
    public CreatePaymentHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager)
    {
        _unitOfWorks = unitOfWorks;
        _userManager = userManager;
    }

    public async Task<Guid> Handle(CreatePaymentCommands request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails, o => o.Payments, o => o.Table)
            ?? throw new AppException("Không tìm thấy đơn hàng nào");

        if (order.Payments.Any(p => p.PaymentStatus == PaymentStatus.Paid))
        {
            throw new AppException("Đơn hàng đã được thanh toán.");
        }

        if (order.OrderStatus == OrderStatus.Payment)
        {
            throw new AppException("Đơn hàng đang được thanh toán");
        }

        var totalAmount = order.OrderDetails
            .Where(od => od.Quantity > od.RefundQuantity && od.Status != OrderDetailsStatus.Canceled)
            .Sum(od => (od.Quantity - od.RefundQuantity) * od.Price);

        if (totalAmount == 0)
        {
            throw new AppException("No valid items for payment.");
        }

        var totalReduceMoney = 0;
        Customer? customer = null;

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            customer = await _unitOfWorks.CustomerRepository.FirstOrDefaultAsync(c => c.PhoneNumber == request.PhoneNumber);
            if (customer != null && request.UsePoints && request.PointsToApply.HasValue)
            {
                order.Customer = customer;
                order.CustomerId = customer.Id;

                var availablePoints = customer.Point;
                var pointsToUse = Math.Min(request.PointsToApply.Value, availablePoints);
                totalReduceMoney = pointsToUse;

                if (totalReduceMoney > totalAmount)
                {
                    totalReduceMoney = (int)totalAmount;
                    pointsToUse = totalReduceMoney / ConversePoint;
                }

                customer.Point -= pointsToUse;
            }
            order.Customer = customer;
            order.CustomerId = customer.Id;

            _unitOfWorks.CustomerRepository.Update(customer);

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

        var payment = new Domain.Entities.PaymentAggregator.Payments
        {
            OrderId = request.OrderId,
            PaymentMethods = PaymentMethods.Cash,
            PaymentDate = DateTime.UtcNow,
            Amount = totalAmount > 0 ? totalAmount : 0,
            ReduceAmount = totalReduceMoney,
            FinalAmount = finalAmount,
            PaymentStatus = PaymentStatus.Pending
        };

        await _unitOfWorks.PaymentRepository.AddAsync(payment);
        await _unitOfWorks.SaveChangeAsync();

        var table = await _unitOfWorks.TableRepository.GetByIdAsync(order.TableId, x => x.Restaurant);
        var restaurantId = table.Restaurant.Id;
        var userInRestaurantAlreadyCheckAttendance = _userManager.Users
            .Where(x => x.RestaurantId == restaurantId &&
                        x.WaiterSchedules.Any(ws =>
                            ws.Attendances.Any(a =>
                                a.CheckInTime != null &&
                                a.CheckOutTime == null &&
                                ws.DateTime == DateOnly.FromDateTime(DateTime.Now.AddHours(7)))))
            .Include(x => x.WaiterSchedules)
                .ThenInclude(ws => ws.Attendances)
            .ToList();

        foreach (var eachUserInRestaurantAlreadyCheckAttendance in userInRestaurantAlreadyCheckAttendance)
        {
            var tokenUser = await FCMTokenHandler.GetFCMTokenByUserID(eachUserInRestaurantAlreadyCheckAttendance.Id);
            await CloudMessagingHandlers.SendNotification(tokenUser, $"Khách hàng yêu cầu thanh toán", $"Khách hàng yêu cầu thanh toán tại bàn {table.TableNumber}");
        }
        return payment.Id;
    }
}
