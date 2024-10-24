using Elastic.Clients.Elasticsearch;
using FOV.Application.Features.Tables.Commands.Active;
using FOV.Application.Features.Tables.Commands.Create;
using FOV.Application.Features.Tables.Commands.Inactive;
using FOV.Application.Features.Tables.Commands.TableLogin;
using FOV.Application.Features.Tables.Commands.TableLogout;
using FOV.Application.Features.Tables.Queries;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Presentation.Controllers.V1;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.v1;
public class TableController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;

    [Authorize(Roles = Role.Manager)]
    [HttpPost("{restaurantId:guid}")]
    public async Task<IActionResult> Add(Guid restaurantId, [FromQuery] int Amount)
    {
        var request = new CreateTableCommand(restaurantId, Amount);
        var response = await _sender.Send(request);
        return Ok(new OK_Result<List<Guid>>("Thêm bàn mới thành công", response));
    }
    //[HttpPut("{id:guid}")]
    //public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTableCommand command)
    //{
    //    command.Id = id;
    //    var response = await _sender.Send(command);
    //    return Ok(response);
    //}
    [Authorize(Roles = Role.Manager)]
    [HttpPost("{id:guid}/active")]
    public async Task<IActionResult> Active(Guid id)
    {
        var response = await _sender.Send(new ActiveTableCommand(id));
        return Ok(new OK_Result<Guid>("Đổi trạng thái của bàn thành công", response));
    }
    [Authorize(Roles = Role.Manager)]
    [HttpPost("{id:guid}/inactive")]
    public async Task<IActionResult> Inactive(Guid id)
    {
        var response = await _sender.Send(new InactiveTableCommand(id));
        return Ok(new OK_Result<Guid>("Đổi trạng thái của bàn thành công", response));
    }
    [HttpPatch("{id:guid}/TableLogin")]
    public async Task<IActionResult> TableLogin(Guid id)
    {
        var response = await _sender.Send(new TableLoginCommand(id));
        return Ok(new OK_Result<Guid>("Đăng nhập bàn thành công", response));
    }
    [Authorize(Roles = Role.Manager)]
    [HttpPatch("{id:guid}/TableLogout")]
    public async Task<IActionResult> TableLogout(Guid id, [FromQuery] string employeeCode)
    {
        var response = await _sender.Send(new TableLogoutCommand(id, employeeCode));
        return Ok(new OK_Result<Guid>("Đăng xuất bàn thành công", response));
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetTableCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
