using FOV.Application.Features.Payments.Commands;
using System.Web;
using FOV.Application.Features.Payments.Commands.Create;
using FOV.Application.Features.Payments.Commands.CreateVNPayPayment;
using FOV.Application.Features.Payments.Commands.FinishPayment;
using FOV.Application.Features.Payments.Queries;
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
            var queryString = Request.QueryString.Value;
            var json = HttpUtility.ParseQueryString(queryString);

            var vnpTxnRef = json["vnp_TxnRef"];
            var amount = json["vnp_Amount"];
            var responseCode = json["vnp_ResponseCode"];
            var secureHash = json["vnp_SecureHash"];

            var command = new VNPayCallbackCommand(vnpTxnRef, amount, responseCode, secureHash);
            var result = await _sender.Send(command);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        return Redirect("INVALID_RESPONSE_URL"); // Redirect for invalid responses
    }
}
