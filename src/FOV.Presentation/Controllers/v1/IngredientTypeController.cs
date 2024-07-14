using FOV.Application.IngredientTypes.Commands.CreateIngredientType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.v1;

public class IngredientTypeController : DefaultController 
{
    private readonly ISender _sender;
    public IngredientTypeController(ISender sender)
    {

        _sender = sender;

    }


    [HttpPost]
    public async Task<IActionResult> Add(CreateIngredientTypeCommand request)
    {
        var response = await _sender.Send(request);
        return Ok(response);
    }

    //[HttpPut]
    //public async Task<IActionResult> Update()



}
