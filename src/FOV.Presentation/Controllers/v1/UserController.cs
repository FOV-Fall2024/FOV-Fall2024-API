using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class UserController : ControllerBase
{

    //[ ] Active User  
    //[ ] Inactive User  
    //[ ] View Users 
    //[ ] View User Detail 
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }



    //[HttpPost]
    //public async  Task<IActionResult> Create(CreateUseCommand request)
    //{
    //   // return Ok(await _mediator.Send(new GetCartByUserQuery()));
    //} 
}
