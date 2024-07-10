using FOV.Application.IngredientTypes.Commands.CreateIngredientType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.v1;

public class IngredientTypeController(IMediator mediator) : DefaultController
{

    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> Add(CreateIngredientTypeCommand request) => Ok(await _mediator.Send(request));
}
