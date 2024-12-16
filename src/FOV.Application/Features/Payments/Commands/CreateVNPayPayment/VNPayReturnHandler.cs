using System;
using System.Threading;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.FCM;
using FOV.Infrastructure.FirebaseDB;
using FOV.Infrastructure.Helpers.VNPayHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FOV.Application.Features.Payments.Commands
{
    public record VNPayCallbackCommand(string vnp_Amount, string vnp_BankCode, string vnp_BankTranNo, string vnp_CardType, string orderInfo, string vnp_PayDate, string vnp_ResponseCode, string vnp_TmnCode, long vnpayTranId, string vnp_TransactionStatus, string vnp_TxnRef, string vnp_SecureHash, string responseQuery) : IRequest<VNPayCallbackResponse>;
    public record VNPayCallbackResponse
    {
        public bool Success { get; init; }
        public string Message { get; init; }
    }
    public class VNPayCallbackHandler : IRequestHandler<VNPayCallbackCommand, VNPayCallbackResponse>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public VNPayCallbackHandler(IUnitOfWorks unitOfWorks, IConfiguration configuration, UserManager<User> userManager)
        {
            _unitOfWorks = unitOfWorks;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<VNPayCallbackResponse> Handle(VNPayCallbackCommand request, CancellationToken cancellationToken)
        {
            var hashSecret = _configuration["VNPay:VnPayHashSecret"];

            #region Validate VNPay signature
            bool isValidSignature = ValidateSignature(request.responseQuery, request.vnp_SecureHash, hashSecret);
            if (!isValidSignature)
            {
                return new VNPayCallbackResponse
                {
                    Success = false,
                    Message = "Invalid VNPay signature."
                };
            }
            #endregion

            if (request.vnp_ResponseCode != "00")
            {
                return new VNPayCallbackResponse
                {
                    Success = false,
                    Message = "Payment failed. Response code: " + request.vnp_ResponseCode + " - " + request.vnp_TransactionStatus
                };
            }

            var payment = await _unitOfWorks.PaymentRepository.GetPaymentByTxnRefAsync(request.vnp_TxnRef);
            if (payment == null)
            {
                return new VNPayCallbackResponse
                {
                    Success = false,
                    Message = "Payment not found for the provided TxnRef."
                };
            }

            var order = await _unitOfWorks.OrderRepository.GetByIdAsync(payment.OrderId, x => x.OrderDetails);

            payment.PaymentStatus = Domain.Entities.PaymentAggregator.Enums.PaymentStatus.Paid;
            order.OrderStatus = Domain.Entities.OrderAggregator.Enums.OrderStatus.Finish;

            var table = await _unitOfWorks.TableRepository.GetByIdAsync(order.TableId);
            table.TableStatus = TableStatus.Available;

            foreach (var detail in order.OrderDetails)
            {
                if (detail.Status != OrderDetailsStatus.Finish)
                {
                    detail.Status = OrderDetailsStatus.Finish;
                    _unitOfWorks.OrderDetailRepository.Update(detail);
                }
            }

            _unitOfWorks.TableRepository.Update(table);
            _unitOfWorks.PaymentRepository.Update(payment);
            _unitOfWorks.OrderRepository.Update(order);
            await _unitOfWorks.SaveChangeAsync();

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
                await CloudMessagingHandlers.SendNotification(tokenUser, $"Khách hàng đã thanh toán qua VNPay", $"Khách hàng đã thanh toán qua VNPay tại bàn {table.TableNumber} thành công");
            }

            return new VNPayCallbackResponse
            {
                Success = true,
                Message = "Payment status updated successfully."
            };
        }
        private bool ValidateSignature(string rspraw, string inputHash, string secretKey)
        {
            string myChecksum = Utils.HmacSHA512(secretKey, rspraw);
            return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
