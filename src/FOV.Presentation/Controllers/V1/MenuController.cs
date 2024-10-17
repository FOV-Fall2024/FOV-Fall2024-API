using FOV.Application.Features.Dishes.Queries.GetMenu;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class MenuController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    [HttpGet("restaurant/{id}")]
    public async Task<IActionResult> GetMenu(Guid id, [FromQuery] GetMenuCommand command)
    {
        command.RestaurantId = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
