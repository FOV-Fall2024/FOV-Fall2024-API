using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;

namespace FOV.Application.Features.RefundDishInventories.Queries.GetExportFile;
public sealed record GetExportFileCommand() : IRequest<TakeImportFileAddRefundDishResponse>;

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
        List<string> nameDishes = _unitOfWorks.DishRepository.WhereAsync(x => x.RestaurantId == _claimService.RestaurantId && x.DishGeneral.IsRefund == true && x.DishGeneral.Status == Status.Active, x => x.DishGeneral).Result.Select(x => x.DishGeneral.DishName).ToList();
        foreach (var item in nameDishes)
        {
            worksheet.Cells[rowIngredient, 1].Value = item;
            //  var listValidation = worksheet.DataValidations.AddListValidation($"C{rowIngredient}");
            //worksheet.Cells[rowIngredient, 2].Value = 0;
            worksheet.Cells[$"B{rowIngredient}"].Value = 0;
            rowIngredient++;
        }
        // Lock column A to make it read-only
        worksheet.Cells["A2:A10"].Style.Locked = true;

        // Unlock columns B and C
        worksheet.Cells["B2:B10"].Style.Locked = false;  // Unlock column B

        // Apply number validation for the second column (B)
        int count = _unitOfWorks.DishRepository
            .WhereAsync(x => x.RestaurantId == _claimService.RestaurantId && x.DishGeneral.IsRefund == true && x.DishGeneral.Status == Status.Active, x => x.DishGeneral)
           .Result.Count;

        var numberAndNotEmptyValidation = worksheet.DataValidations.AddCustomValidation($"B2:B{count + 1}");
        numberAndNotEmptyValidation.Formula.ExcelFormula = "AND(ISNUMBER(B2), B2>=0)";
        numberAndNotEmptyValidation.ShowErrorMessage = true;
        numberAndNotEmptyValidation.ErrorTitle = "Invalid Input";
        numberAndNotEmptyValidation.Error = "Only numbers greater than or equal to 0 are allowed, and the cell cannot be empty.";
        numberAndNotEmptyValidation.PromptTitle = "Enter a number";
        numberAndNotEmptyValidation.Prompt = "Only numbers greater than or equal to 0 are allowed in this column.";


        // Set the range (>= 0)

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


}
