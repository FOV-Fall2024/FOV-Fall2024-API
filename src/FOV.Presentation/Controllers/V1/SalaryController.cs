using FOV.Application.Features.Salaries.Commands.Create;
using FOV.Application.Features.Salaries.Commands.CreateAll;
using FOV.Application.Features.Salaries.Queries.GetSalaryOfAllEmployee;
using FOV.Application.Features.Salaries.Queries.GetSalaryOfEmployee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FOV.Presentation.Controllers.V1;

public class SalaryController(ISender sender) : DefaultController
{
    private readonly ISender _sender = sender;
    [HttpPost("create")]
    public async Task<IActionResult> CreateSalary([FromBody] CreateSalaryCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpPost("create-all")]
    public async Task<IActionResult> CreateAllSalaries([FromBody] CreateAllSalariesCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpGet("salary-restaurant")]
    public async Task<IActionResult> GetRestaurantSalaries([FromQuery] GetSalaryOfAllEmployeeCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
    [HttpGet("salary-employee")]
    public async Task<IActionResult> GetEmployeeSalaries([FromQuery] GetSalaryOfEmployeeCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }
}
