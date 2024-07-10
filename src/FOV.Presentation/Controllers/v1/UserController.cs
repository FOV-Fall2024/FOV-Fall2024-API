using FOV.Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.v1
{
    public class UserController : ControllerBase
    {
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
}
