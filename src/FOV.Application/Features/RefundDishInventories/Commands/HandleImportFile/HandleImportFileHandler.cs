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
            var quantity = worksheet.Cells[row, 2].Text;  // Column B
            var measurement = worksheet.Cells[row, 3].Text;  // Column C

            Dish? dish = await _unitOfWorks.DishRepository.FirstOrDefaultAsync(x => x.DishGeneral.DishName == dishName && x.RestaurantId == _claimService.RestaurantId, x => x.RefundDishInventory);
            RefundDishInventory inventory = await _unitOfWorks.RefundDishInventoryRepository.GetByIdAsync(dish.RefundDishInventory.Id) ?? throw new Exception();
            if (dish == null) break;
            RefundDishUnit unit = await _unitOfWorks.RefundDishUnitRepository.FirstOrDefaultAsync(x => x.RefundDishInventoryId == dish.RefundDishInventory.Id && x.UnitName == measurement) ?? throw new Exception();
            int quantityCalculate = int.Parse(quantity) * _unitOfWorks.RefundDishUnitRepository.GetTotalConversionFactor(unit.Id);
            RefundDishInventoryTransaction transaction = new(quantityCalculate, dish.RefundDishInventory.Id, Domain.Entities.DishAggregator.Enums.RefundDishInventoryTransactionType.Add);

            await _unitOfWorks.RefundDishInventoryTransactionRepository.AddAsync(transaction);
            inventory.AddQuantity(quantityCalculate);
            _unitOfWorks.RefundDishInventoryRepository.Update(inventory);
        }
        return Result.Ok();
    }
}
