using FOV.Application.Features.Ingredients.Commands.AddMultipleQuantity;
using FOV.Application.Features.Ingredients.Queries.GetIngredients;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FOV.Presentation.Controllers.V1
{
    [ApiController]
    [Route("api/v1/ingredients")]
    public class IngredientController : DefaultController
    {
        private readonly IMediator _mediator;

        public IngredientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adds multiple quantities of ingredients.
        /// </summary>
        /// <param name="command">The command containing the details for multiple quantities.</param>
        /// <returns>A success message or error details.</returns>
        [HttpPost("multiple")]
        [SwaggerOperation(Summary = "Add multiple quantities of ingredients.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMultiple(AddMultipleQuantityCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(new OK_Result<string>("Thêm nguyên liệu thành công", result.Successes.First().Message));
            }
            return BadRequest(result.Errors.Select(e => e.Message));
        }

        /// <summary>
        /// Adds a single quantity of an ingredient.
        /// </summary>
        /// <param name="command">The command containing the details for a single quantity.</param>
        /// <returns>A success message or error details.</returns>
        [HttpPost("single")]
        [SwaggerOperation(Summary = "Add a single quantity of an ingredient.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddSingle(AddMultipleQuantityCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(new OK_Result<string>("Thêm nguyên liệu thành công", result.Successes.First().Message));
            }
            return BadRequest(result.Errors.Select(e => e.Message));
        }

        /// <summary>
        /// Retrieves a list of ingredients.
        /// </summary>
        /// <param name="command">The command containing filter parameters.</param>
        /// <returns>A list of ingredients.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Retrieve a list of ingredients.")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GetIngredientsCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(new OK_Result<PagedResult<GetIngredientsResponse>>("Thành công",result));
        }
    }
}
