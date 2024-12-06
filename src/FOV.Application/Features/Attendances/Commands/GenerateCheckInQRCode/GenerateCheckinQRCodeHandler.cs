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
    //public Guid WaiterScheduleId { get; set; }
    public DateOnly Date { get; set; }
    public Guid ShiftId { get; set; }
}
public class GenerateCheckinQRCodeHandler(IUnitOfWorks unitOfWorks, QRCodeGeneratorHandler qRCodeGeneratorHandler, StorageHandler storage) : IRequestHandler<GenerateCheckInQRCodeCommand, string>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly QRCodeGeneratorHandler _qRCodeGeneratorHandler = qRCodeGeneratorHandler;
    private readonly StorageHandler _storageHandler = storage;

    public async Task<string> Handle(GenerateCheckInQRCodeCommand request, CancellationToken cancellationToken)
    {
        return await GenerateAndUploadQRCodeAsync(request.RestaurantId, request.ShiftId, request.Date);
    }
    private async Task<string> GenerateAndUploadQRCodeAsync(Guid restaurantId, Guid shiftId, DateOnly date)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(restaurantId);
        if (restaurant == null)
        {
            throw new AppException("Không tìm thấy nhà hàng");
        }
        var shift = await _unitOfWorks.ShiftRepository.GetByIdAsync(shiftId);
        if (shift == null)
        {
            throw new AppException("Không tìm thấy ca làm việc");
        }

        var fileName = $"Restaurant_{restaurant.Id}_Date_{date}_Shift_{shift.ShiftName}";
        var qrUrl = $"http://vktrng.ddns.net:8080/api/Attendance/checkin?restaurantId={restaurantId}&shiftId={shiftId}&date={date}"; //&userId=&latitude=&longitude="
        //var qrUrl = $"https://localhost:7107/api/Attendance/checkin?restaurantId={restaurantId}&shiftId={shiftId}&date={date}"; //&userId=&latitude=&longitude="

        var qrCodeBytes = _qRCodeGeneratorHandler.GenerateQRCode(qrUrl);

        using var memoryStream = new MemoryStream(qrCodeBytes);

        var storageFile = await _storageHandler.UploadQrImageForAttendanceAsync(memoryStream, fileName);
        return storageFile.FileUrl;
    }
}
