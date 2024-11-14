using FOV.Application.Features.Statistics.Queries.GetTopNDishGeneral;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class StatisticsController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [HttpGet]
    public async Task<IActionResult> GetTopNDish([FromQuery] GetTopNDishGeneralCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
}
