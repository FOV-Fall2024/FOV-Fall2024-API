using FOV.Application.Features.IngredientTypes.Commands.Active;
using FOV.Application.Features.IngredientTypes.Commands.Create;
using FOV.Application.Features.IngredientTypes.Commands.CreateChild;
using FOV.Application.Features.IngredientTypes.Commands.Inactive;
using FOV.Application.Features.IngredientTypes.Commands.Update;
using FOV.Application.Features.IngredientTypes.Queries.GetChildCategories;
using FOV.Application.Features.IngredientTypes.Queries.GetParentCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class IngredientTypeController(ISender sender) : DefaultController
{

    private readonly ISender _sender = sender;

    //[ ] Get
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _sender.Send(new GetParentCategoriesCommand());
        return Ok(response);
    }

    //[ ] Get Detail
    [HttpGet("{parentId}")]
    public async Task<IActionResult> GetChildrenIngredientType(Guid parentId)
    {
        var resposne = await _sender.Send(new GetChildCategoriesCommand(parentId));
        return Ok(resposne);
    }

    //[x] Create 
    [HttpPost("parent")]
    public async Task<IActionResult> Add(CreateIngredientTypeCommand request)
    {
        var response = await _sender.Send(request);
        return Ok(response);
    }

    [HttpPost("child")]
    public async Task<IActionResult> AddChild(CreateChildIngredientTypeCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }


    //[x] Update 
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateIngredientTypeCommand command)
    {
        command.Id = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }

    //[x] Active
    [HttpPost("{id:guid}/active")]
    public async Task<IActionResult> Actvie(Guid id)
    {
        var response = await _sender.Send(new ActiveIngredientTypeCommand(id));
        return Ok(response);
    }

    //[x] Inactive
    [HttpPost("{id:guid}/inactive")]
    public async Task<IActionResult> InActive(Guid id)
    {
        var response = await _sender.Send(new InactiveIngredientTypeCommand(id));
        return Ok(response);
    }







}
