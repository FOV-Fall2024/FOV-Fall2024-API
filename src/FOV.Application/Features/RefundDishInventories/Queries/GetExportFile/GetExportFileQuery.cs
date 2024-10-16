﻿using FOV.Application.Common.Behaviours.Claim;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;

namespace FOV.Application.Features.RefundDishInventories.Queries.GetExportFile;
public sealed record GetExportFileCommand(int Type, IReadOnlyList<Guid> DishIds) : IRequest<TakeImportFileAddRefundDishResponse>;

public sealed record TakeImportFileAddRefundDishResponse(MemoryStream ExcelFile, string ExcelName);
internal class GetExportFileQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetExportFileCommand, TakeImportFileAddRefundDishResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<TakeImportFileAddRefundDishResponse> Handle(GetExportFileCommand request, CancellationToken cancellationToken)
    {
        ExcelPackage.LicenseContext = LicenseContext.Commercial;

        using var package = new ExcelPackage();
        // Add a worksheet
        var worksheet = package.Workbook.Worksheets.Add("DataSheet");

        // Add headers
        worksheet.Cells[1, 1].Value = "Dish Name";      // Column A
        worksheet.Cells[1, 2].Value = "Quantity";   // Column B

        int rowIngredient = 2;
        var nameDishes = await HandleImportType(request.Type,request.DishIds);
        foreach (var item in nameDishes)
        {
            worksheet.Cells[rowIngredient, 1].Value = item;
            var listValidation = worksheet.DataValidations.AddListValidation($"C{rowIngredient}");
            rowIngredient++;
        }
        // Lock column A to make it read-only
        worksheet.Cells["A2:A10"].Style.Locked = true;

        // Unlock columns B and C
        worksheet.Cells["B2:B10"].Style.Locked = false;  // Unlock column B
        worksheet.Cells["C2:C10"].Style.Locked = false;  // Unlock column C

        // Apply number validation for the second column (B)
        int count = _unitOfWorks.IngredientRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId).Result.Count;
        var numberValidation = worksheet.DataValidations.AddDecimalValidation($"B2:B{count += 1}");
        numberValidation.ShowErrorMessage = true;
        numberValidation.ErrorTitle = "Invalid Input";
        numberValidation.Error = "Only numbers between 0 and 100 are allowed.";
        numberValidation.PromptTitle = "Enter a number";
        numberValidation.Prompt = "Only numbers between 0 and 100 are allowed in this column.";

        // Set the range (between 0 and 100)
        numberValidation.Operator = ExcelDataValidationOperator.between;
        numberValidation.Formula.Value = 0;    // Lower limit
        numberValidation.Formula2.Value = 100; // Upper limit
        // Protect the worksheet to enforce read-only on column A
        worksheet.Protection.IsProtected = true;
        worksheet.Protection.AllowSelectLockedCells = true;

        // Save the Excel file to a memory stream
        var stream = new MemoryStream();
        package.SaveAs(stream);
        stream.Position = 0;

        // Return the result with the stream and filename
        var excelName = $"GeneratedExcel-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        return new TakeImportFileAddRefundDishResponse(stream, excelName);
    }

    public async Task<List<string>> HandleImportType(int importType, IReadOnlyList<Guid> importIds)
    {
        switch (importType)
        {
            case 1:
                return _unitOfWorks.DishRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId).Result.Select(x => x.DishGeneral.DishName).ToList();
            case 2:
                return _unitOfWorks.DishRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId && x.RefundDishInventory.QuantityAvailable == 0).Result.Select(x => x.DishGeneral.DishName).ToList();
            case 3:
                // Filter the dishes by the provided importIds
                return _unitOfWorks.DishRepository
                    .WhereAsync(x => importIds.Contains(x.Id)) // Assuming x.Id is the GUID for the dish
                    .Result
                    .Select(x => x.DishGeneral.DishName)
                    .ToList();
            default:
                return new List<string>();
        }

    }
}
