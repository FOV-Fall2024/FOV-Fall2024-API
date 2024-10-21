using System.IO;
using FOV.Application.Features.RefundDishInventories.Commands.AddMultiple;
using FOV.Application.Features.RefundDishInventories.Commands.AddSingle;
using FOV.Application.Features.RefundDishInventories.Commands.HandleImportFile;
using FOV.Application.Features.RefundDishInventories.Queries.GetExportFile;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Presentation.Infrastructure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.DataValidation;

namespace FOV.Presentation.Controllers.V1
{
    public class RefundDishInventoryController : DefaultController
    {
        private readonly ISender _sender;
        public RefundDishInventoryController(ISender sender)
        {
            _sender = sender;
        }



        [HttpPost("dish/{id}/add-single")]
        public async Task<IActionResult> AddSingle(Guid id, AddSingleRefundDishInventoryCommand command)
        {
            command.DishId = id;
            var response = await _sender.Send(command);
            return Ok(response);
        }


        [HttpPost("/add-multiple")]
        public async Task<IActionResult> AddMultiple(AddMultipleRefundDishInventoryCommand command)
        {
            var response = await _sender.Send(command);
            return Ok(response);
        }

        [Authorize(Roles = Role.Manager)]
        [HttpGet("/export-file")]
        public async Task<IActionResult> ExportInventoryFile()
        {
            var response = await _sender.Send(new GetExportFileCommand());
            var stream = response.ExcelFile;
            var excelName = response.ExcelName;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

        [Authorize(Roles = Role.Manager)]
        [HttpPost("/upload-file")]
        public async Task<IActionResult> UploadInventoryFile([FromForm] HandImportFileCommand file)
        {
            var response = await _sender.Send(file);
            return response.IsSuccess ? Ok(new OK_Result<string>("Thêm số lượng  thành công")) : BadRequest(response.Errors);
        }

    }
}
