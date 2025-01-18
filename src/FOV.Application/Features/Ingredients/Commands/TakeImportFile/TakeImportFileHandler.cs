using MediatR;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using FOV.Application.Common.Behaviours.Claim;

namespace FOV.Application.Features.Ingredients.Commands.TakeImportFile;

public sealed record TakeImportFileCommand : IRequest<TakeImportFileResponse>;
public sealed record TakeImportFileResponse(MemoryStream ExcelFile, string ExcelName);

public class TakeImportFileHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<TakeImportFileCommand, TakeImportFileResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;

    public async Task<TakeImportFileResponse> Handle(TakeImportFileCommand request, CancellationToken cancellationToken)
    {
        ExcelPackage.LicenseContext = LicenseContext.Commercial;

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("DataSheet");

        // Add headers
        worksheet.Cells[1, 1].Value = "IngredientName";   // Column A
        worksheet.Cells[1, 2].Value = "Quantity";         // Column B
        worksheet.Cells[1, 3].Value = "Measurement";      // Column C
        worksheet.Cells[1, 4].Value = "ConvertedQuantity"; // Column D (Optional)
        worksheet.Cells[1, 5].Value = "Unit";             // Column E (g)

        int currentRow = 2;
        var ingredients = await _unitOfWorks.IngredientRepository.WhereAsync(
            x => x.RestaurantId == _claimService.RestaurantId,
            x => x.IngredientUnits,
            x => x.IngredientGeneral);

        foreach (var ingredient in ingredients)
        {
            worksheet.Cells[currentRow, 1].Value = ingredient.IngredientGeneral.IngredientName;
            worksheet.Cells[currentRow, 2].Value = 0; // Default Quantity

            // Add list validation for Measurement (Column C)
            var listValidation = worksheet.DataValidations.AddListValidation($"C{currentRow}");
            var conversionQueries = new List<string>();

            foreach (var unit in ingredient.IngredientUnits)
            {
                listValidation.Formula.Values.Add(unit.UnitName);
                var conversionFactor = await GetTotalConversionFactor(unit.Id);
                conversionQueries.Add($"IF(C{currentRow}=\"{unit.UnitName}\",B{currentRow}*{conversionFactor}");
            }

            worksheet.Cells[currentRow, 4].Formula = BuildExcelFormula(conversionQueries);

            listValidation.ShowErrorMessage = true;
            listValidation.ErrorTitle = "Invalid Selection";
            listValidation.Error = "Please select a valid option from the list.";
            listValidation.AllowBlank = false;

            worksheet.Cells[currentRow, 3].Value = ingredient.IngredientUnits.FirstOrDefault()?.UnitName;
            worksheet.Cells[currentRow, 5].Value = ingredient.IngredientUnits.FirstOrDefault(u => u.IngredientUnitParentId == null)?.UnitName ?? "null";

            currentRow++;
        }

        // Lock and unlock specific cells
        ProtectWorksheet(worksheet, currentRow);

        // Save the Excel file to a memory stream
        var stream = new MemoryStream();
        package.SaveAs(stream);
        stream.Position = 0;

        var excelName = $"GeneratedExcel-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        return new TakeImportFileResponse(stream, excelName);
    }

    private async Task<decimal> GetTotalConversionFactor(Guid unitId)
    {
        var unit = await _unitOfWorks.IngredientUnitRepository.FirstOrDefaultAsync(u => u.Id == unitId)
                   ?? throw new ArgumentException("Unit not found");

        if (unit.IngredientUnitParentId == null)
            return unit.ConversionFactor;

        var parentFactor = await GetTotalConversionFactor(unit.IngredientUnitParentId.Value);
        return unit.ConversionFactor * parentFactor;
    }

    private static string BuildExcelFormula(List<string> elements)
    {
        if (elements == null || elements.Count == 0)
            return "0";

        string formula = string.Join(",", elements) + ",0" + new string(')', elements.Count);
        return $"={formula}";
    }

    private static void ProtectWorksheet(ExcelWorksheet worksheet, int rowCount)
    {
        worksheet.Cells[$"A2:A{rowCount}"].Style.Locked = true;
        worksheet.Cells[$"C2:C{rowCount}"].Style.Locked = true;
        worksheet.Cells[$"D2:D{rowCount}"].Style.Locked = true;
        worksheet.Cells[$"E2:E{rowCount}"].Style.Locked = true;
        worksheet.Cells[$"B2:B{rowCount}"].Style.Locked = false;
        worksheet.Cells[$"C2:C{rowCount}"].Style.Locked = false;

        var numberValidation = worksheet.DataValidations.AddDecimalValidation($"B2:B{rowCount}");
        numberValidation.ShowErrorMessage = true;
        numberValidation.ErrorTitle = "Invalid Input";
        numberValidation.Error = "Only numbers greater than 0 are allowed.";
        numberValidation.Operator = ExcelDataValidationOperator.greaterThanOrEqual;
        numberValidation.Formula.Value = 0;

        worksheet.Protection.IsProtected = true;
        worksheet.Protection.AllowSelectLockedCells = true;
    }
}
