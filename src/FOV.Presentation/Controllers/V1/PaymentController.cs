using System.Web;
using FOV.Application.Features.Payments.Commands;
using FOV.Application.Features.Payments.Commands.ConfirmRecievedMoney;
using FOV.Application.Features.Payments.Commands.Create;
using FOV.Application.Features.Payments.Commands.CreateVNPayPayment;
using FOV.Application.Features.Payments.Commands.FinishPayment;
using FOV.Application.Features.Payments.Queries;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class PaymentController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    [HttpPost("{orderId:guid}/cash")]
    public async Task<IActionResult> CreatePayment(Guid orderId, [FromQuery] string? PhoneNumber, [FromQuery] bool UsePoints, [FromQuery] int? PointsToApply, [FromBody] FeedbackRequest? feedback)
    {
        var command = new CreatePaymentCommands(PhoneNumber, UsePoints, PointsToApply)
        {
            OrderId = orderId,
            Feedback = feedback?.Feedback
        };
        var response = await _sender.Send(command);
        return Ok(new OK_Result<Guid>("Đợi nhân viên xác nhận thanh toán", response));
    }

    [HttpPost("{orderId:guid}/vn-pay")]
    public async Task<IActionResult> CreateVNPayPayment(Guid orderId, [FromQuery] string? PhoneNumber, [FromQuery] bool UsePoints, [FromQuery] int? PointsToApply, [FromBody] FeedbackRequest? feedback)
    {
        var command = new VNPayPaymentCommand(PhoneNumber, UsePoints, PointsToApply)
        {
            OrderId = orderId,
            Feedback = feedback?.Feedback
        };
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPatch("{orderId:guid}/confirm")]
    public async Task<IActionResult> ConfirmPayment(Guid orderId)
    {
        var command = new FinishPaymentCommand(orderId);
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [Authorize(Roles = Role.Administrator)]
    [HttpPatch("{orderId:guid}/confirm-received-money")]
    public async Task<IActionResult> ConfirmReceivedMoney(Guid orderId)
    {
        var command = new ConfirmReceivedMoneyCommand(orderId);
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPaymentsRequest command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpGet("payment-confirm")]
    public async Task<IActionResult> PaymentConfirm()
    {
        if (Request.QueryString.HasValue)
        {
            var queryString = HttpUtility.ParseQueryString(Request.QueryString.Value);
            #region VNPay QueryString
            var command = new VNPayCallbackCommand(
                vnp_Amount: queryString["vnp_Amount"],
                vnp_BankCode: queryString["vnp_BankCode"],
                vnp_BankTranNo: queryString["vnp_BankTranNo"],
                vnp_CardType: queryString["vnp_CardType"],
                orderInfo: queryString["vnp_OrderInfo"],
                vnp_PayDate: queryString["vnp_PayDate"],
                vnp_ResponseCode: queryString["vnp_ResponseCode"],
                vnp_TmnCode: queryString["vnp_TmnCode"],
                vnpayTranId: Convert.ToInt64(queryString["vnp_TransactionNo"]),
                vnp_TransactionStatus: queryString["vnp_TransactionStatus"],
                vnp_TxnRef: queryString["vnp_TxnRef"],
                vnp_SecureHash: queryString["vnp_SecureHash"],
                responseQuery: Request.QueryString.Value.Substring(1, Request.QueryString.Value.IndexOf("&vnp_SecureHash") - 1)
            );
            #endregion
            var response = await _sender.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        return BadRequest();
    }
}
