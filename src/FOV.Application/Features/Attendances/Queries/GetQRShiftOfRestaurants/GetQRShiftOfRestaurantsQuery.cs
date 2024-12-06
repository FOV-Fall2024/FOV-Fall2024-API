using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.ShiftAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.FirebaseHandler;
using FOV.Infrastructure.Helpers.QRCodeGeneratorHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Attendances.Queries.GetQRShiftOfRestaurants;
public record GetQRShiftOfRestaurantCommand : IRequest<GetQRShiftOfRestaurantsResponse>
{
    public Guid RestaurantId { get; set; }
    public Guid ShiftId { get; set; }
    public DateOnly Date { get; set; }
}
public record GetQRShiftOfRestaurantsResponse(string Url);
public class GetQRShiftOfRestaurantsQuery(IUnitOfWorks unitOfWorks, QRCodeGeneratorHandler qRCodeGeneratorHandler, StorageHandler storage) : IRequestHandler<GetQRShiftOfRestaurantCommand, GetQRShiftOfRestaurantsResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly QRCodeGeneratorHandler _qRCodeGeneratorHandler = qRCodeGeneratorHandler;
    private readonly StorageHandler _storageHandler = storage;
    public async Task<GetQRShiftOfRestaurantsResponse> Handle(GetQRShiftOfRestaurantCommand request, CancellationToken cancellationToken)
    {
        var existingQrCodes = await _unitOfWorks.ShiftRestaurantRepository.WhereAsync(x => x.RestaurantId == request.RestaurantId && x.ShiftId == request.ShiftId && x.Date == request.Date);
        if (existingQrCodes.Any())
        {
            return new GetQRShiftOfRestaurantsResponse(existingQrCodes.First().Url);
        }

        return await GenerateAndUploadQRCodeAsync(request.RestaurantId, request.ShiftId, request.Date);
    }
    private async Task<GetQRShiftOfRestaurantsResponse> GenerateAndUploadQRCodeAsync(Guid restaurantId, Guid shiftId, DateOnly date)
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

        var fileName = $"Restaurant_{restaurant.Id}_Date_{date:yyyy-MM-dd}_Shift_{shift.ShiftName}";
        var qrUrl = $"http://vktrng.ddns.net:8080/api/Attendance/checkin?restaurantId={restaurantId}&shiftId={shiftId}&date={date}";

        var qrCodeBytes = _qRCodeGeneratorHandler.GenerateQRCode(qrUrl);

        using var memoryStream = new MemoryStream(qrCodeBytes);

        var storageFile = await _storageHandler.UploadQrImageForAttendanceAsync(memoryStream, fileName);

        var shiftRestaurant = new ShiftRestaurant
        {
            RestaurantId = restaurantId,
            ShiftId = shiftId,
            Date = date,
            Url = storageFile.FileUrl,
            Status = Status.Active
        };
        await _unitOfWorks.ShiftRestaurantRepository.AddAsync(shiftRestaurant);
        await _unitOfWorks.SaveChangeAsync();

        return new GetQRShiftOfRestaurantsResponse(storageFile.FileUrl);
    }
}
