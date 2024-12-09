using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Helpers.VNPayHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace FOV.Application.Features.Payments.Commands.CreateVNPayPayment;
public record VNPayPaymentCommand(string? PhoneNumber, bool UsePoints, int? PointsToApply) : IRequest<VNPayPaymentResponse>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
    [JsonIgnore]
    public string? Feedback { get; set; }
}
public record VNPayPaymentResponse(string PaymentUrl, Guid PaymentId);
public class VNPayPaymentHandler : IRequestHandler<VNPayPaymentCommand, VNPayPaymentResponse>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IConfiguration _configuration;
    private const int ConversePoint = 1000;
    public VNPayPaymentHandler(IUnitOfWorks unitOfWorks, IConfiguration configuration)
    {
        _unitOfWorks = unitOfWorks;
        _configuration = configuration;
    }

    public async Task<VNPayPaymentResponse> Handle(VNPayPaymentCommand request, CancellationToken cancellationToken)
    {
        var hash_secret = _configuration["VNPay:VnPayHashSecret"];
        var tmn_code = _configuration["VNPay:VnPayTmnCode"];
        var returnUrl = _configuration["VNPay:VnPayReturnUrl"];
        var url = _configuration["VNPay:VnPayUrl"];

        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng");

        var totalAmount = order.OrderDetails
            .Where(od => od.Quantity > od.RefundQuantity && od.Status != OrderDetailsStatus.Canceled)
            .Sum(od => (od.Quantity - od.RefundQuantity) * od.Price);

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

        if (totalAmount == 0)
        {
            throw new Exception("No valid items for payment.");
        }

        var txnRef = $"{request.OrderId.ToString()}_{DateTime.UtcNow:yyyyMMddHHmmss}";
        Console.WriteLine($"Generated txnRef: {txnRef}");

        var payment = new Domain.Entities.PaymentAggregator.Payments
        {
            OrderId = request.OrderId,
            Amount = totalAmount,
            ReduceAmount = totalReduceMoney,
            FinalAmount = finalAmount,
            VnpTxnRef = txnRef,
            PaymentDate = DateTime.UtcNow,
            PaymentMethods = Domain.Entities.PaymentAggregator.Enums.PaymentMethods.VNPay,
            PaymentStatus = Domain.Entities.PaymentAggregator.Enums.PaymentStatus.Pending
        };

        await _unitOfWorks.PaymentRepository.AddAsync(payment);
        await _unitOfWorks.SaveChangeAsync();

        if (customer != null)
        {
            var pointsAwarded = (int)(totalAmount / ConversePoint);
            customer.Point += pointsAwarded;
            _unitOfWorks.CustomerRepository.Update(customer);
        }

        if (!string.IsNullOrEmpty(request.Feedback))
        {
            order.Feedback = request.Feedback;
        }

        order.OrderStatus = OrderStatus.Payment;
        _unitOfWorks.OrderRepository.Update(order);
        await _unitOfWorks.SaveChangeAsync();

        string formatDate = $"{DateTime.UtcNow:yyyyMMddHHmmss}";
        #region VNPay Request
        VnPayHandler vnPayHandler = new VnPayHandler();
        vnPayHandler.AddRequestData("vnp_Version", "2.1.0");
        vnPayHandler.AddRequestData("vnp_Command", "pay");
        vnPayHandler.AddRequestData("vnp_TmnCode", tmn_code);
        vnPayHandler.AddRequestData("vnp_Amount", ((long)(finalAmount * 100)).ToString());
        vnPayHandler.AddRequestData("vnp_BankCode", "");
        vnPayHandler.AddRequestData("vnp_CreateDate", formatDate);
        vnPayHandler.AddRequestData("vnp_CurrCode", "VND");
        vnPayHandler.AddRequestData("vnp_IpAddr", Utils.GetIpAddress());
        vnPayHandler.AddRequestData("vnp_Locale", "vn");
        vnPayHandler.AddRequestData("vnp_OrderInfo", "Payment for Order");
        vnPayHandler.AddRequestData("vnp_OrderType", "other");
        vnPayHandler.AddRequestData("vnp_ReturnUrl", returnUrl);
        vnPayHandler.AddRequestData("vnp_TxnRef", txnRef);
        #endregion

        string paymentUrl = vnPayHandler.CreateRequestUrl(url, hash_secret);

        return new VNPayPaymentResponse(paymentUrl, payment.Id);
    }
}
