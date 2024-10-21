using FluentResults;
using MediatR;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using FOV.Application.Common.Behaviours.Claim;

namespace FOV.Application.Features.Ingredients.Commands.TakeImportFile;
public sealed record TakeImportFileCommand : IRequest<TakeImportFileResponse>;
public sealed record TakeImportFileResponse(MemoryStream ExcelFile, string ExcelName);
public class TakeImportFileHandler(IUnitOfWorks unitOfWorks,IClaimService claimService) : IRequestHandler<TakeImportFileCommand, TakeImportFileResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public  async Task<TakeImportFileResponse> Handle(TakeImportFileCommand request, CancellationToken cancellationToken)
    {
        ExcelPackage.LicenseContext = LicenseContext.Commercial;

        using var package = new ExcelPackage();
        // Add a worksheet
        var worksheet = package.Workbook.Worksheets.Add("DataSheet");

        // Add headers
        worksheet.Cells[1, 1].Value = "IngredientName";   // Column A
        worksheet.Cells[1, 2].Value = "Quantity";         // Column B
        worksheet.Cells[1, 3].Value = "Measurement";      // Column C

        int rowIngredient = 2;
        var ingredients = await _unitOfWorks.IngredientRepository.WhereAsync(
            x => x.RestaurantId == _claimService.RestaurantId,
            x => x.IngredientUnits);

        foreach (var item in ingredients)
        {
            worksheet.Cells[rowIngredient, 1].Value = item.IngredientName;

            // Add list validation for column C
            var listValidation = worksheet.DataValidations.AddListValidation($"C{rowIngredient}");
            foreach (var ingredientUnit in item.IngredientUnits)
            {
                listValidation.Formula.Values.Add(ingredientUnit.UnitName);
            }

            // Set the default value to the first item in the list
            if (item.IngredientUnits.Any())
            {
                worksheet.Cells[rowIngredient, 3].Value = item.IngredientUnits.First().UnitName;
            }

            // Lock column C (read-only)
            worksheet.Cells[rowIngredient, 3].Style.Locked = true;

            rowIngredient++;
        }

        // Lock column A to make it read-only
        worksheet.Cells["A2:A10"].Style.Locked = true;

        // Unlock columns B (for input)
        worksheet.Cells["B2:B10"].Style.Locked = false;

        // Apply number validation for column B
        int count = _unitOfWorks.IngredientRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId).Result.Count;
        var numberValidation = worksheet.DataValidations.AddDecimalValidation($"B2:B{count + 1}");
        numberValidation.ShowErrorMessage = true;
        numberValidation.ErrorTitle = "Invalid Input";
        numberValidation.Error = "Only numbers between 0 and 100 are allowed.";
        numberValidation.PromptTitle = "Enter a number";
        numberValidation.Prompt = "Only numbers between 0 and 100 are allowed in this column.";
        numberValidation.Operator = ExcelDataValidationOperator.between;
        numberValidation.Formula.Value = 0;    // Lower limit
        numberValidation.Formula2.Value = 100; // Upper limit

        // Protect the worksheet to enforce read-only on columns A and C
        worksheet.Protection.IsProtected = true;
        worksheet.Protection.AllowSelectLockedCells = true;

        // Save the Excel file to a memory stream
        var stream = new MemoryStream();
        package.SaveAs(stream);
        stream.Position = 0;

        // Return the result with the stream and filename
        var excelName = $"GeneratedExcel-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        return new TakeImportFileResponse(stream, excelName);
    }
}
