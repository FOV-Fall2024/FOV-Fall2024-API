using FluentResults;
using MediatR;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml;

namespace FOV.Application.Features.Ingredients.Commands.TakeImportFile;
public sealed record TakeImportFileCommand : IRequest<TakeImportFileResponse>;
public sealed record TakeImportFileResponse(MemoryStream ExcelFile, string ExcelName);
public class TakeImportFileHandler : IRequestHandler<TakeImportFileCommand, TakeImportFileResponse>
{
    public  async Task<TakeImportFileResponse> Handle(TakeImportFileCommand request, CancellationToken cancellationToken)
    {
        ExcelPackage.LicenseContext = LicenseContext.Commercial;

        // Define the measurement options for the dropdown
        var measurementOptions = new[] { "kg", "g", "liters", "ml" };

        // Create a memory stream to hold the Excel file
        using (var package = new ExcelPackage())
        {
            // Add a worksheet
            var worksheet = package.Workbook.Worksheets.Add("DataSheet");

            // Add headers
            worksheet.Cells[1, 1].Value = "Read-Only Column";      // Column A
            worksheet.Cells[1, 2].Value = "Number Input Column";   // Column B
            worksheet.Cells[1, 3].Value = "Measurement Options";   // Column C

            // Populate the read-only column (A)
            for (int row = 2; row <= 10; row++)
            {
                worksheet.Cells[row, 1].Value = "Fixed Data";  // This will be read-only
            }

            // Lock column A to make it read-only
            worksheet.Cells["A2:A10"].Style.Locked = true;

            // Unlock columns B and C
            worksheet.Cells["B2:B10"].Style.Locked = false;  // Unlock column B
            worksheet.Cells["C2:C10"].Style.Locked = false;  // Unlock column C

            // Apply number validation for the second column (B)
            var numberValidation = worksheet.DataValidations.AddDecimalValidation("B2:B10");
            numberValidation.ShowErrorMessage = true;
            numberValidation.ErrorTitle = "Invalid Input";
            numberValidation.Error = "Only numbers between 0 and 100 are allowed.";
            numberValidation.PromptTitle = "Enter a number";
            numberValidation.Prompt = "Only numbers between 0 and 100 are allowed in this column.";

            // Set the range (between 0 and 100)
            numberValidation.Operator = ExcelDataValidationOperator.between;
            numberValidation.Formula.Value = 0;    // Lower limit
            numberValidation.Formula2.Value = 100; // Upper limit

            // Apply dropdown list validation for the third column (C)
            for (int row = 2; row <= 10; row++)
            {
                var listValidation = worksheet.DataValidations.AddListValidation($"C{row}");
                foreach (var option in measurementOptions)
                {
                    listValidation.Formula.Values.Add(option);  // Add measurement options to the dropdown
                }
            }

            // Protect the worksheet to enforce read-only on column A
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
}
