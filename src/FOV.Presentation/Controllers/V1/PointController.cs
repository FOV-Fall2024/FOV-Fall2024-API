using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Points.Queries.GetPointOfCustomer;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class PointController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetPointsForCustomerCommand command)
    {
        try
        {
            var response = await _sender.Send(command);
            return Ok(new OK_Result<int>("Lấy số điểm khách hàng thành công", response));
        }
        catch(AppException ex)
        {
            return BadRequest(new Error<FieldError>("Bạn không phải là thành viên của nhà hàng. Xin để lại thông tin để tích điểm", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
        }
    }
}
