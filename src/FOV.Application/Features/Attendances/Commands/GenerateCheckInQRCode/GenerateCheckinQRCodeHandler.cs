using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using FOV.Infrastructure.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Attendances.Commands.GenerateCheckInQRCode;
public record GenerateCheckInQRCodeCommand : IRequest<string>
{
    public Guid RestaurantId { get; set; }
    public Guid WaiterScheduleId { get; set; }
    public DateOnly Date { get; set; }
}
public class GenerateCheckinQRCodeHandler(IUnitOfWorks unitOfWorks, QRCodeGeneratorHandler qRCodeGeneratorHandler, StorageHandler storage) : IRequestHandler<GenerateCheckInQRCodeCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly QRCodeGeneratorHandler _qRCodeGeneratorHandler = qRCodeGeneratorHandler;
    private readonly StorageHandler _storageHandler = storage;

    public async Task<string> Handle(GenerateCheckInQRCodeCommand request, CancellationToken cancellationToken)
    {
        return await GenerateAndUploadQRCodeAsync(request.Date, request.RestaurantId, request.WaiterScheduleId);
    }
    private async Task<string> GenerateAndUploadQRCodeAsync(DateOnly date, Guid restaurantId, Guid waiterScheduleId)
    {
        var restaurant = _unitOfWorks.RestaurantRepository.GetByIdAsync(restaurantId);
        if (restaurant == null)
        {
            throw new Exception("Restaurant not found");
        }
        var waiterSchedule = _unitOfWorks.WaiterScheduleRepository.GetByIdAsync(waiterScheduleId) ?? throw new Exception("Schedule not found");

        var fileName = $"Restaurant_{restaurant}_Date_{date}";
        var qrUrl = $"https://localhost:7107/api/Attendance?restaurant={restaurantId}&date={date}&schedule={waiterScheduleId}";

        Bitmap qrCodeImage = _qRCodeGeneratorHandler.GenerateQRCode(qrUrl);
        using (var memoryStream = new MemoryStream())
        {
            qrCodeImage.Save(memoryStream, ImageFormat.Png);
            memoryStream.Seek(0, SeekOrigin.Begin);

            var storageFile = await _storageHandler.UploadQrImageForAttendanceAsync(memoryStream, fileName);
            return storageFile.FileUrl;
        }
    }
}
