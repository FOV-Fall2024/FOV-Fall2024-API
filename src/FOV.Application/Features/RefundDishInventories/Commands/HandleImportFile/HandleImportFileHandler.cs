using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace FOV.Application.Features.RefundDishInventories.Commands.HandleImportFile;
public sealed record HandImportFileCommand(IFormFile File) : IRequest<Result>;
public class HandleImportFileHandler(IUnitOfWorks
     unitOfWorks, IClaimService claimService) : IRequestHandler<HandImportFileCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(HandImportFileCommand request, CancellationToken cancellationToken)
    {
        var file = request.File;
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using var stream = new MemoryStream();
        await file.CopyToAsync(stream, cancellationToken);
        using var package = new ExcelPackage(stream);
        var worksheet = package.Workbook.Worksheets[0]; // Assume the first sheet
        var rowCount = worksheet.Dimension.Rows;
        for (int row = 2; row <= rowCount; row++)
        {
            var dishName = worksheet.Cells[row, 1].Text;  // Column A
            var quantityText = worksheet.Cells[row, 2].Text;  // Column B
            if (string.IsNullOrEmpty(dishName) || string.IsNullOrEmpty(quantityText))
            {
                // Skip rows with missing data
                continue;
            }

            // Attempt to parse quantity
            if (!int.TryParse(quantityText, out int quantityCalculate) || quantityCalculate <= 0)
            {
                // Skip invalid or zero/negative quantities
                continue;
            }
            // Fetch the dish by name and restaurant ID, including its RefundDishInventory
            Dish? dish = await _unitOfWorks.DishRepository.FirstOrDefaultAsync(
                x => x.DishGeneral.DishName == dishName && x.RestaurantId == _claimService.RestaurantId,
                x => x.RefundDishInventory
            );

            if (dish == null || dish.RefundDishInventory == null)
            {
                // Skip if dish or refund inventory is not found
                continue;
            }

            // Fetch the refund dish inventory record
            RefundDishInventory inventory = await _unitOfWorks.RefundDishInventoryRepository.GetByIdAsync(dish.RefundDishInventory.Id)
                ?? throw new Exception("Refund Dish Inventory not found.");

            // Create a new refund dish inventory transaction
            RefundDishInventoryTransaction transaction = new(
                quantityCalculate,
                dish.RefundDishInventory.Id,
                Domain.Entities.DishAggregator.Enums.RefundDishInventoryTransactionType.Add
            );

            // Add the transaction to the repository
            await _unitOfWorks.RefundDishInventoryTransactionRepository.AddAsync(transaction);

            // Update the inventory quantity
            inventory.AddQuantity(quantityCalculate);
            _unitOfWorks.RefundDishInventoryRepository.Update(inventory);

            // Save the changes
            await _unitOfWorks.SaveChangeAsync();
        }

        return Result.Ok();
    }
}
