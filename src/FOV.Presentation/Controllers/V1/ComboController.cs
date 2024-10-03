using FOV.Application.Features.Combos.Commands.Active;
using FOV.Application.Features.Combos.Commands.Create;
using FOV.Application.Features.Combos.Commands.Inactive;
using FOV.Application.Features.Combos.Queries.GetCombos;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ComboController : DefaultController
    {
        private readonly IMediator _mediator;

        public ComboController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retrieves all combos.
        /// </summary>
        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves all combos.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCombo([FromQuery] GetCombosCommand query)
        {
            var response = await _mediator.Send(query);
            return Ok(new OK_Result<PagedResult<GetCombosResponse>>("Lấy thông tin combo thành công", response));
        }

        /// <summary>
        /// Adds a new combo.
        /// </summary>
        [Authorize(Roles = Role.Manager)]
        [HttpPost]
        [SwaggerOperation(Summary = "Adds a new combo.")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCombo( CreateComboCommand command)
        {
            var response = await _mediator.Send(command);
            return Created("", new CREATED_Result("Tạo combo thành công"));
        }

        /// <summary>
        /// Activates a combo.
        /// </summary>
        [Authorize(Roles = Role.Manager)]
        [HttpPatch("{id:guid}/active")]
        [SwaggerOperation(Summary = "Activates a combo.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ActiveCombo(Guid id)
        {
            var response = await _mediator.Send(new ActvieComboCommand(id));
            return Ok(new OK_Result<string>("Mở trạng thái hoạt động của combo thành công", ""));
        }

        /// <summary>
        /// Deactivates a combo.
        /// </summary>
        [Authorize(Roles = Role.Manager)]
        [HttpPatch("{id:guid}/inactive")]
        [SwaggerOperation(Summary = "Deactivates a combo.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InactiveCombo(Guid id)
        {
            var response = await _mediator.Send(new InactiveComboCommand(id));
            return Ok(new OK_Result<string>("Đóng trạng thái hoạt động của combo thành công", ""));
        }
    }
}
