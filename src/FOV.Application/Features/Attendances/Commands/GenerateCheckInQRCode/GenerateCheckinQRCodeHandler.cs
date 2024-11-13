using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
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
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
public class GenerateCheckinQRCodeHandler(IUnitOfWorks unitOfWorks, QRCodeGeneratorHandler qRCodeGeneratorHandler, StorageHandler storage) : IRequestHandler<GenerateCheckInQRCodeCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly QRCodeGeneratorHandler _qRCodeGeneratorHandler = qRCodeGeneratorHandler;
    private readonly StorageHandler _storageHandler = storage;

    public async Task<string> Handle(GenerateCheckInQRCodeCommand request, CancellationToken cancellationToken)
    {
        return await GenerateAndUploadQRCodeAsync(request.RestaurantId, request.WaiterScheduleId, request.Longitude, request.Latitude);
    }
    private async Task<string> GenerateAndUploadQRCodeAsync(Guid restaurantId, Guid waiterScheduleId, double latitude, double longitude)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(restaurantId);
        if (restaurant == null)
        {
            throw new AppException("Không tìm thấy nhà hàng");
        }
        var waiterSchedule = await _unitOfWorks.WaiterScheduleRepository.GetByIdAsync(waiterScheduleId, x => x.Shift);
        if (waiterSchedule == null)
        {
            throw new AppException("Không tìm thấy lịch làm việc");
        }

        if (waiterSchedule.Shift == null)
        {
            throw new AppException("Không tìm thấy thông tin ca làm việc");
        }

        var fileName = $"Restaurant_{restaurant.Id}_Date_{waiterSchedule.DateTime}_Shift_{waiterSchedule.Shift.ShiftName}";
        var qrUrl = $"https://localhost:7107/api/Attendance/CheckIn?restaurant={restaurantId}&schedule={waiterScheduleId}&latitude={latitude}&longitude={longitude}";

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
