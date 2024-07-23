using FOV.Application.Features.ProductGenerals.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;


public class ProductGeneralController(ISender sender) : DefaultController
{

    private readonly ISender _sender = sender;
    // [ ] Create 
    [HttpPost]
    public async Task<IActionResult> Add(CreateProductGeneralCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    // [ ] Update
    
    // [ ] Active 
    // [ ] Inactive
    // [ ] Get
    // [ ] Detail 





}
