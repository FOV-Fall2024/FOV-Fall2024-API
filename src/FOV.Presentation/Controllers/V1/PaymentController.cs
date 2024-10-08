﻿using System.Web;
using FOV.Application.Features.Payments.Commands;
using FOV.Application.Features.Payments.Commands.Create;
using FOV.Application.Features.Payments.Commands.CreateVNPayPayment;
using FOV.Application.Features.Payments.Commands.FinishPayment;
using FOV.Application.Features.Payments.Queries;
using FOV.Infrastructure.Helpers.VNPayHelper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class PaymentController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    [HttpPost("{orderId:guid}/cash")]
    public async Task<IActionResult> CreatePayment(Guid orderId, CreatePaymentCommands command)
    {
        command = command with { OrderId = orderId };
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpPost("{orderId:guid}/vn-pay")]
    public async Task<IActionResult> CreateVNPayPayment(Guid orderId)
    {
        var command = new VNPayPaymentCommand
        {
            OrderId = orderId
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
