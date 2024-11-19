using FOV.Application.Features.Statistics.Queries.GetCurrentStatistic;
using FOV.Application.Features.Statistics.Queries.GetTopNDishGeneral;
using FOV.Application.Features.Statistics.Queries.GetTotalRevenues;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class StatisticsController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [HttpGet("top-dish")]
    public async Task<IActionResult> GetTopNDish([FromQuery] GetTopNDishGeneralCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("revenue")]
    public async Task<IActionResult> GetRevenue([FromQuery] GetTotalRevenuesCommand command)
    {
        var result = await _sender.Send(command);
        return Ok(result);
    }
    [HttpGet("current-statistic")]
    public async Task<IActionResult> GetCurrentStatistic()
    {
        var result = await _sender.Send(new GetCurrentStatisticCommand());
        return Ok(result);
    }
}
