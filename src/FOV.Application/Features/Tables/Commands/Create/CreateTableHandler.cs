using System.Drawing;
using System.Drawing.Imaging;
using System.Text.Json.Serialization;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using FOV.Infrastructure.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Commands.Create;

public record CreateTableCommand(Status TableStatus) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid RestaurantId { get; set; }
}
public class CreateTableHandler(IUnitOfWorks unitOfWorks, StorageHandler storageHandler, QRCodeGeneratorHandler qrCodeGeneratorHandler) : IRequestHandler<CreateTableCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly StorageHandler _storageHandler = storageHandler;
    private readonly QRCodeGeneratorHandler _qrCodeGeneratorHandler = qrCodeGeneratorHandler;

    public async Task<Guid> Handle(CreateTableCommand request, CancellationToken cancellationToken)
    {
        Table table = new(request.TableStatus);
        int nextTableNumber = await GetNextTableNumberAsync(request.RestaurantId);

        string tableCode = $"Tab_{nextTableNumber.ToString("D3")}";

        // Generate TableCode based on the next TableNumber
        table.RestaurantId = request.RestaurantId;
        table.TableCode = tableCode;
        table.TableQRCode = await GenerateAndUploadQRCodeAsync(request.RestaurantId, tableCode);

        await _unitOfWorks.TableRepository.AddAsync(table);
        await _unitOfWorks.SaveChangeAsync();
        return table.Id;
    }
    
    private async Task<int> GetNextTableNumberAsync(Guid restaurantId)
    {
        var highestTableNumber = await _unitOfWorks.TableRepository
            .GetHighestTableNumberAsync(restaurantId);

        return (highestTableNumber ?? 0) + 1;
    }

    private async Task<string> GenerateAndUploadQRCodeAsync(Guid RestaurantId, string TableCode)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(RestaurantId);
        if (restaurant == null)
        {
            throw new Exception("Restaurant not found");
        }
        string restaurantCode = restaurant.RestataurantCode;

        string qRUrl = $"https://localhost:5001/api/v1/restaurant/{restaurantCode}/table/{TableCode}"; //Change Url Later
        string fileName = $"{restaurantCode}_{TableCode}.png";

        Bitmap qrCodeImage = _qrCodeGeneratorHandler.GenerateQRCode(qRUrl);

        using (var memoryStream = new MemoryStream())
        {
            qrCodeImage.Save(memoryStream, ImageFormat.Png);
            memoryStream.Seek(0, SeekOrigin.Begin);

            var storageFile = await _storageHandler.UploadQrImageAsync(memoryStream, fileName);
            return storageFile.FileUrl;
        }
    }
}
