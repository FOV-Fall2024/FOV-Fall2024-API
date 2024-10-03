using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Ingredients.Commands.AddMultipleQuantity;
using FOV.Application.Features.Ingredients.Commands.AddSingleQuantity;
using FOV.Application.Features.Ingredients.Commands.HandleImportFile;
using FOV.Application.Features.Ingredients.Commands.TakeImportFile;
using FOV.Application.Features.Ingredients.Queries.GetIngredients;
using FOV.Application.Features.Ingredients.Responses;
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
            try
            {
                List<Guid> transactionIds = await _mediator.Send(command);

                return Ok(new OK_Result<List<Guid>>("Thêm nguyên liệu thành công", transactionIds));
            }
            catch (AppException ex)
            {
                return BadRequest(new Error<FieldError>("Thêm nguyên liệu thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An unexpected error occurred: " + ex.Message });
            }
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
        public async Task<IActionResult> AddSingle(AddSingleQuantityCommand command)
        {
            try
            {
                Guid ingredientId = await _mediator.Send(command);
                return Ok(new OK_Result<Guid>("Thêm nguyên liệu thành công", ingredientId));
            }
            catch (AppException ex)
            {
                return BadRequest(new Error<FieldError>("Thêm nguyên liệu thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Error = "An unexpected error occurred: " + ex.Message });
            }
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
            return Ok(new OK_Result<PagedResult<GetIngredientsResponse>>("Thành công", result));
        }

        [HttpGet("import-file")]
        public async Task<IActionResult> TakeImportFile()
        {
            var result = await _mediator.Send(new TakeImportFileCommand());
            var stream = result.ExcelFile;
            var excelName = result.ExcelName;

            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);

        }

        [HttpPost("import-file")]
        public async Task<IActionResult> ImportFile([FromForm] ProcessImportFileCommand file)
        {
            if (file == null)
            {
                return BadRequest("No file uploaded.");
            }

            var result = await _mediator.Send(file);

            return result.IsSuccess ? Ok("File processed successfully.") : BadRequest(result.Errors);
        }


    }
}
