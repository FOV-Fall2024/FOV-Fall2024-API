using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Helpers.FirebaseHandler;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using QRCoder;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using FOV.Domain.Helpers.QRCodeGeneratorHelper;

namespace FOV.Application.Features.Tables.Commands.Create;

public record CreateTableCommand(string TableNumber, string TableCode, string TableStatus, string TableState, string TableType, string TableDescription, string TableImage) : IRequest<Guid>
{
    public Guid RestaurantId { get; set; }
}
public class CreateTableHandler(IUnitOfWorks unitOfWorks, StorageHandler storageHandler, QRCodeGeneratorHandler qrCodeGeneratorHandler) : IRequestHandler<CreateTableCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly StorageHandler _storageHandler = storageHandler;
    private readonly QRCodeGeneratorHandler _qrCodeGeneratorHandler = qrCodeGeneratorHandler;

    public async Task<Guid> Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        Table table = new(request.TableNumber, request.TableCode, request.TableStatus, request.TableState, request.TableType, request.TableDescription, request.TableImage);
        table.RestaurantId = request.RestaurantId;
        table.TableQRCode = await GenerateAndUploadQRCodeAsync(request.RestaurantId, request.TableCode);
        await _unitOfWorks.TableRepository.AddAsync(table);
        await _unitOfWorks.SaveChangeAsync();
        return table.Id;
    }
    private async Task<string> GenerateAndUploadQRCodeAsync(Guid RestaurantId, string TableCode)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(RestaurantId);
        if (restaurant == null)
        {
            throw new Exception("Restaurant not found");
        }
        string restaurantCode = restaurant.RestataurantCode;

        string QRUrl = $"https://localhost:5001/api/v1/restaurant/{restaurantCode}/table/{TableCode}"; //Change Url Later
        string fileName = $"{restaurantCode}_{TableCode}.png";

        Bitmap qrCodeImage = _qrCodeGeneratorHandler.GenerateQRCode(QRUrl);

        using (var memoryStream = new MemoryStream())
        {
            qrCodeImage.Save(memoryStream, ImageFormat.Png);
            memoryStream.Seek(0, SeekOrigin.Begin);

            var storageFile = await _storageHandler.UploadQrImageAsync(memoryStream, fileName);
            return storageFile.FileUrl;
        }
    }
}