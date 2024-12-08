using FOV.Application.Features.Salaries.Commands.Create;
using FOV.Application.Features.Salaries.Commands.CreateAll;
using FOV.Application.Features.Salaries.Queries.GetSalaryOfAllEmployee;
using FOV.Application.Features.Salaries.Queries.GetSalaryOfEmployee;
using FOV.Domain.Entities.UserAggregator.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class SalaryController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [Authorize(Roles = Role.Manager)]
    [HttpPost("create")]
    public async Task<IActionResult> CreateSalary([FromBody] CreateSalaryCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [Authorize(Roles = $"{Role.Waiter},{Role.Chef},{Role.Manager}")]
    [HttpGet("salary-restaurant")]
    public async Task<IActionResult> GetRestaurantSalaries([FromQuery] GetSalaryOfAllEmployeeCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [Authorize(Roles = $"{Role.Waiter},{Role.Chef}")]
    [HttpGet("salary-employee")]
    public async Task<IActionResult> GetEmployeeSalaries([FromQuery] GetSalaryOfEmployeeCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
