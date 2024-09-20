using Elastic.Clients.Elasticsearch;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.NewRecommendProducts.Commands.AdjustRequest;
using FOV.Application.Features.NewRecommendProducts.Commands.ApproveResponse;
using FOV.Application.Features.NewRecommendProducts.Commands.DenyResponse;
using FOV.Application.Features.NewRecommendProducts.Commands.NeedsUpdateResponse;
using FOV.Application.Features.NewRecommendProducts.Commands.NewRequest;
using FOV.Application.Features.NewRecommendProducts.Commands.UpdateRequest;
using FOV.Application.Features.NewRecommendProducts.Queries.GetAll;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class NewProductRecommendController : DefaultController
{
    private readonly ISender _sender;
    public NewProductRecommendController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("request")]
    public async Task<IActionResult> SendRequest(NewRequestCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> AdjustRequest(AdjustRequestCommand command, Guid id)
    {
        command.RecommendProductId = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPost("{id:guid}")]
    public async Task<IActionResult> UpdateRequest(UpdateRequestCommand command, Guid id)
    {
        command.NewRecommendProductId = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }


    [HttpPost("{id:guid}/approved")]
    public async Task<IActionResult> ApproveRequest(ApproveResponseCommand command, Guid id)
    {
        command.NewProductRecommendId = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpPost("{id:guid}/denied")]
    public async Task<IActionResult> DenyRequest(DenyResponseCommand command, Guid id)
    {
        command.NewProductRecommendId = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }


    [HttpPost("{id:guid}/needsUpdate")]
    public async Task<IActionResult> NeedsUpdateRequest(NeedsUpdateResponseCommand command, Guid id)
    {
        command.NewRecommendProductId = id;
        var response = await _sender.Send(command);
        return Ok(response);
    }


    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PagingRequest pagingRequest)
    {
        try
        {
            var command = new GetNewProductRecommendCommand(pagingRequest);
            var response = await _sender.Send(command);
            return Ok(new OK_Result<PagedResult<GetNewProductRecommendResponse>>("Lấy danh sách sản phẩm gợi ý thành công", response));
        }
        catch (AppException ex)
        {
            return BadRequest(new Error<FieldError>("Lấy danh sách sản phẩm gợi ý thất bại", ErrorStatusCodeConfig.BAD_REQUEST, ex.FieldErrors));
        }
    }
}
