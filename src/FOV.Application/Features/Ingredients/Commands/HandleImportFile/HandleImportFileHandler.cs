using System.Collections.Concurrent;
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

        // Pre-fetch ingredients and units for the given restaurant
        var ingredientNames = worksheet.Cells[2, 1, rowCount, 1].Select(c => c.Text).Distinct().ToList();

        var ingredients = await _unitOfWorks.IngredientRepository
            .WhereAsync(x => ingredientNames.Contains(x.IngredientGeneral.IngredientName) && x.RestaurantId == _claimService.RestaurantId,
                       x => x.IngredientGeneral);

        var ingredientDict = ingredients.ToDictionary(i => i.IngredientGeneral.IngredientName, i => i);

        // Pre-fetch units for the ingredients
        var ingredientIds = ingredients.Select(i => i.Id).ToList();

        // Loop through the worksheet
        for (int row = 2; row <= rowCount; row++)
        {
            var ingredientName = worksheet.Cells[row, 1].Text;  // Column A
            var quantityText = worksheet.Cells[row, 4].Text;    // Column B

            if (!ingredientDict.TryGetValue(ingredientName, out var ingredient))
                continue;
            if (!decimal.TryParse(quantityText, out decimal quantity) || quantity == 0)
                continue;
            ingredient.AddQuantity(quantity);

        }

        _unitOfWorks.IngredientRepository.UpdateRange(ingredients);

        await _unitOfWorks.SaveChangeAsync();


        return Result.Ok();
    }
}
