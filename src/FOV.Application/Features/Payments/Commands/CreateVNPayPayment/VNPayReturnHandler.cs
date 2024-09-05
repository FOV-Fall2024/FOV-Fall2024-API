using System;
using System.Threading;
using System.Threading.Tasks;
using FOV.Infrastructure.Helpers.VNPayHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FOV.Application.Features.Payments.Commands
{
    public record VNPayCallbackCommand(string vnp_TxnRef, string VnpAmount, string VnpResponseCode, string VnpSecureHash) : IRequest<VNPayCallbackResponse>;
    public record VNPayCallbackResponse
    {
        public bool Success { get; init; }
        public string Message { get; init; }
    }
    public class VNPayCallbackHandler : IRequestHandler<VNPayCallbackCommand, VNPayCallbackResponse>
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IConfiguration _configuration;

        public VNPayCallbackHandler(IUnitOfWorks unitOfWorks, IConfiguration configuration)
        {
            _unitOfWorks = unitOfWorks;
            _configuration = configuration;
        }

        public async Task<VNPayCallbackResponse> Handle(VNPayCallbackCommand request, CancellationToken cancellationToken)
        {
            var hashSecret = _configuration["VNPay:VnPayHashSecret"];
            var tmnCode = _configuration["VNPay:VnPayTmnCode"];

            var rspraw = $"vnp_TxnRef={request.vnp_TxnRef}&vnp_Amount={request.VnpAmount}&vnp_ResponseCode={request.VnpResponseCode}";
            //var vnPayHandler = new VnPayHandler();
            //vnPayHandler.AddResponseData("vnp_TxnRef", request.vnp_TxnRef);
            //vnPayHandler.AddResponseData("vnp_Amount", request.VnpAmount);
            //vnPayHandler.AddResponseData("vnp_ResponseCode", request.VnpResponseCode);
            //vnPayHandler.AddResponseData("vnp_SecureHash", request.VnpSecureHash);

            bool isValidSignature = ValidateSignature(rspraw, request.VnpSecureHash, hashSecret);
            if (!isValidSignature)
            {
                return new VNPayCallbackResponse
                {
                    Success = false,
                    Message = "Invalid VNPay signature."
                };
            }

            //var payment = await _unitOfWorks.PaymentRepository.GetFirstOrDefaultAsync(p => p.OrderId == Guid.Parse(request.OrderId));
            //if (payment == null)
            //{
            //    return new VNPayCallbackResponse
            //    {
            //        Success = false,
            //        Message = "Payment not found."
            //    };
            //}

            //// Step 3: Update the payment status based on VNPay's response
            //payment.PaymentStatus = request.VnpResponseCode == "00"
            //    ? Domain.Entities.PaymentAggregator.Enums.PaymentStatus.Paid
            //    : Domain.Entities.PaymentAggregator.Enums.PaymentStatus.Failed;

            //payment.PaymentDate = DateTime.UtcNow;
            //_unitOfWorks.PaymentRepository.Update(payment);
            //await _unitOfWorks.SaveChangeAsync();

            return new VNPayCallbackResponse
            {
                Success = true,
                Message = "Payment status updated successfully."
            };
        }

        public bool ValidateSignature(string rspraw, string inputHash, string secretKey)
        {
            string myChecksum = Utils.HmacSHA512(secretKey, rspraw);
            return myChecksum.Equals(inputHash, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
