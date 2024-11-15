using FOV.Application.Features.IngredientMeasures.Commands.Create;
using FOV.Application.Features.IngredientMeasures.Queries.Get;
using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Application.Features.IngredientTypes.Queries.GetParentCategories;
using FOV.Application.Features.IngredientTypes.Responses;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1;

public class IngredientMeasureController : DefaultController
{
    private readonly ISender _sender;
    public IngredientMeasureController(ISender sender)
    {
        _sender = sender;
    }


    [HttpGet]
    [SwaggerOperation(Summary = "Retrieves a list of ingredient measure")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
        var response = await _sender.Send(new GetIngredientMeasureCommand());
        return Ok(response);
    }


    [Authorize(Roles = Role.Administrator)]
    [HttpPost()]
    [SwaggerOperation(Summary = "Creates  ingredient measure.")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Add(CreateIngredientMeasureCommand request)
    {
        Guid response = await _sender.Send(request);
        return Ok(new OK_Result<Guid>("Create IngredientType Successfully", response));
    }
}
