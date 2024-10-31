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
        var response = await _sender.Send(command);
        return Ok(new OK_Result<int>("Lấy số điểm khách hàng thành công", response));
    }
}
