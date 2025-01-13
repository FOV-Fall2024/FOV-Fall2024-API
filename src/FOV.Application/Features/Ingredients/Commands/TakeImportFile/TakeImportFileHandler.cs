using FluentResults;
using MediatR;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.IngredientAggregator;

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

        int rowIngredient = 2;
        var ingredients = await _unitOfWorks.IngredientRepository.WhereAsync(
            x => x.RestaurantId == _claimService.RestaurantId,
            x => x.IngredientUnits,
            x => x.IngredientGeneral
        );

        foreach (var item in ingredients)
        {
            worksheet.Cells[rowIngredient, 1].Value = item.IngredientGeneral.IngredientName;
            worksheet.Cells[$"B{rowIngredient}"].Value = 0; // Default Quantity

            // Add list validation for Measurement (Column C)
            var listValidation = worksheet.DataValidations.AddListValidation($"C{rowIngredient}");
            List<string>? queries = [];
            foreach (var ingredientUnit in item.IngredientUnits)
            {
                listValidation.Formula.Values.Add(ingredientUnit.UnitName);
                queries.Add(@$"IF(C{rowIngredient}=""{ingredientUnit.UnitName}"",B{rowIngredient}*{await GetTotalConversionFactor(ingredientUnit.Id)}");
            }

            worksheet.Cells[$"D{rowIngredient}"].Formula = ExcelQuery(queries);
            //@$"IF(C{rowIngredient}=""kg"",B{i}*1000,IF(C{i}=""thùng"",B{i}*10000,IF(C{i}=""gam"",B{i},0)))";

            listValidation.ShowErrorMessage = true;
            listValidation.ErrorTitle = "Invalid Selection";
            listValidation.Error = "Please select a valid option from the list.";
            listValidation.AllowBlank = false;

            // Set the default value to the first item in the list
            if (item.IngredientUnits.Count != 0)
            {
                worksheet.Cells[rowIngredient, 3].Value = item.IngredientUnits.First().UnitName;
            }

            worksheet.Cells[rowIngredient, 5].Value = item.IngredientUnits.FirstOrDefault(x => x.IngredientUnitParentId == null)?.UnitName ?? "null";

            rowIngredient++;
            queries = null;
        }

        // Lock Column A
        worksheet.Cells["A2:A3000"].Style.Locked = true;
        worksheet.Cells["C2:C3000"].Style.Locked = true;
        worksheet.Cells["D3:D3000"].Style.Locked = true;
        worksheet.Cells["E3:E4000"].Style.Locked = true;
        // Unlock Columns B (Quantity) and C (Measurement)
        worksheet.Cells["B2:B3000"].Style.Locked = false;
        worksheet.Cells["C2:C3000"].Style.Locked = false;



        // Add number validation for Quantity column (Column B)
        var numberValidation = worksheet.DataValidations.AddDecimalValidation($"B2:B{rowIngredient}");
        numberValidation.ShowErrorMessage = true;
        numberValidation.ErrorTitle = "Invalid Input";
        numberValidation.Error = "Only numbers greater than 0 are allowed.";
        numberValidation.Operator = ExcelDataValidationOperator.greaterThanOrEqual;
        numberValidation.Formula.Value = 0;

        // Protect the worksheet
        worksheet.Protection.IsProtected = true;
        worksheet.Protection.AllowSelectLockedCells = true;

        // Save the Excel file to a memory stream
        var stream = new MemoryStream();
        package.SaveAs(stream);
        stream.Position = 0;

        var excelName = $"GeneratedExcel-{DateTime.Now:yyyyMMddHHmmss}.xlsx";
        return new TakeImportFileResponse(stream, excelName);
    }

    public async Task<decimal> GetTotalConversionFactor(Guid unitId)
    {
        IngredientUnit unit = await _unitOfWorks.IngredientUnitRepository.FirstOrDefaultAsync(u => u.Id == unitId)
                              ?? throw new ArgumentException("Unit not found");

        if (unit.IngredientUnitParentId == null)
        {
            return unit.ConversionFactor;
        }
        decimal parentConversionFactor = await GetTotalConversionFactor(unit.IngredientUnitParentId.Value);
        return unit.ConversionFactor * parentConversionFactor;
    }
    public string ExcelQuery(List<string> elements)
    {
        if (elements == null || elements.Count == 0)
        {
            return "0"; // Default value if there are no elements
        }

        // Dynamically combine all the queries into a single nested IF formula
        string formula = string.Join(",", elements) + ",0" + new string(')', elements.Count);

        // Wrap the queries into a single formula
        return $"={formula}";
    }


}

