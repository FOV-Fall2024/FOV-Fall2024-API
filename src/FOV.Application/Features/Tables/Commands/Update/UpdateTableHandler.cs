using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FOV.Domain.Entities.TableAggregator;
using FOV.Domain.Helpers.FirebaseHandler;
using FOV.Domain.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Commands.Update;
public sealed record UpdateTableCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string TableNumber { get; set; } = string.Empty;
    public string TableCode { get; set; } = string.Empty;
    public string TableStatus { get; set; } = string.Empty;
    public string TableState { get; set; } = string.Empty;
    public string TableType { get; set; } = string.Empty;
    public string TableDescription { get; set; } = string.Empty;
    public string TableImage { get; set; } = string.Empty;
}
public class UpdateTableHandler(IUnitOfWorks unitOfWorks, QRCodeGeneratorHandler qrCodeGeneratorHandler, StorageHandler storageHandler) : IRequestHandler<UpdateTableCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly QRCodeGeneratorHandler _qrCodeGeneratorHandler = qrCodeGeneratorHandler;
    private readonly StorageHandler _storageHandler = storageHandler;

    public async Task<Guid> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
    {
        Table table = await _unitOfWorks.TableRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(table.RestaurantId) ?? throw new Exception();
        // Check if TableCode has changed
        if (table.TableCode != request.TableCode)
        {
            string qrUrl = $"https://localhost:5001/api/v1/restaurant/{restaurant.RestataurantCode}/table/{request.TableCode}";
            string fileName = $"{restaurant.RestataurantCode}_{request.TableCode}.png";

            Bitmap qrCodeImage = _qrCodeGeneratorHandler.GenerateQRCode(qrUrl);

            using (var memoryStream = new MemoryStream())
            {
                qrCodeImage.Save(memoryStream, ImageFormat.Png);
                memoryStream.Seek(0, SeekOrigin.Begin);

                var storageFile = await _storageHandler.UploadQrImageAsync(memoryStream, fileName);
                table.TableQRCode = storageFile.FileUrl;
            }
        }

        table.Update(request.TableNumber, request.TableCode, request.TableStatus, request.TableState, request.TableType, request.TableDescription, request.TableImage, table.TableQRCode);
        _unitOfWorks.TableRepository.Update(table);
        await _unitOfWorks.SaveChangeAsync();
        return table.Id;
    }
}
