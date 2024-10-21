using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;

namespace FOV.Application.Features.Ingredients.Commands.HandleImportFile;

public sealed record ProcessImportFileCommand(IFormFile File) : IRequest<Result>;

public class HandleImportFileHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<ProcessImportFileCommand, Result>
{
    private readonly IClaimService _claimService = claimService;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ProcessImportFileCommand request, CancellationToken cancellationToken)
    {
        var file = request.File;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream, cancellationToken);
        using var package = new ExcelPackage(stream);
        var worksheet = package.Workbook.Worksheets[0]; // Assume the first sheet
        var rowCount = worksheet.Dimension.Rows;

        // Iterate through each row (starting from row 2, assuming row 1 has headers)
        for (int row = 2; row <= rowCount; row++)
        {
            var ingredientName = worksheet.Cells[row, 1].Text;  // Column A
            var quantityText = worksheet.Cells[row, 2].Text;  // Column B
            var measurement = worksheet.Cells[row, 3].Text;  // Column C

            Ingredient? ingredient = await _unitOfWorks.IngredientRepository.FirstOrDefaultAsync(
                x => x.IngredientName == ingredientName && x.RestaurantId == _claimService.RestaurantId);

            // Skip this row if the ingredient is not found
            if (ingredient == null) continue;

            IngredientUnit? unit = await _unitOfWorks.IngredientUnitRepository.FirstOrDefaultAsync(
                x => x.IngredientId == ingredient.Id && x.UnitName == measurement);

            // Skip this row if the unit is not found
            if (unit == null) continue;

            // Parse quantity safely
            if (!decimal.TryParse(quantityText, out decimal quantity) || quantity == 0)
            {
                continue;  // Skip if the quantity is invalid or 0
            }

            // Calculate total quantity with conversion factor
            decimal conversionFactor = _unitOfWorks.IngredientRepository.GetTotalConversionFactor(unit.Id);
            decimal quantityCalculate = quantity * conversionFactor;

            // Add quantity to the ingredient
            ingredient.AddQuantity(quantityCalculate);

            // Create a new ingredient transaction
            IngredientTransaction ingredientTransaction = new(quantityCalculate, IngredientTransactionType.Add, ingredient.Id);
            await _unitOfWorks.IngredientTransactionRepository.AddAsync(ingredientTransaction);

            // Update the ingredient and save changes
            _unitOfWorks.IngredientRepository.Update(ingredient);
            await _unitOfWorks.SaveChangeAsync();
        }

        return Result.Ok();
    }
}
