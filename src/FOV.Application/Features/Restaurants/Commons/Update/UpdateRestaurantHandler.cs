using FOV.Application.Common.Exceptions;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Commons.Update;
public record UpdateRestaurantCommand(string RestaurantName, string? Address, string? RestaurantPhone) : IRequest<Guid>
{
    public Guid Id;
}
public class UpdateRestaurantHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateRestaurantCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        #region Validate
        var fieldErrors = new List<FieldError>();

        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.Id);
        if (restaurant == null)
        {
            throw new AppException("Nhà hàng không tồn tại");
        }
        if (!string.IsNullOrEmpty(request.RestaurantName) && restaurant.RestaurantName != request.RestaurantName)
        {
            bool existRestaurantName = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
                           r.RestaurantName == request.RestaurantName);

            if (existRestaurantName)
            {
                fieldErrors.Add(new FieldError { Field = "restaurantName", Message = "Đã có nhà hàng trùng tên" });
            }
        }

        if (!string.IsNullOrEmpty(request.Address) && restaurant.Address != request.Address)
        {
            bool existAddress = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
                r.Address == request.Address);

            if (existAddress)
            {
                fieldErrors.Add(new FieldError { Field = "address", Message = "Đã có nhà hàng trùng địa chỉ" });
            }
        }

        if (!string.IsNullOrEmpty(request.RestaurantPhone) && restaurant.RestaurantPhone != request.RestaurantPhone)
        {
            bool existPhone = await _unitOfWorks.RestaurantRepository.AnyAsync(r =>
                r.RestaurantPhone == request.RestaurantPhone);

            if (existPhone)
            {
                fieldErrors.Add(new FieldError { Field = "restaurantPhone", Message = "Đã có nhà hàng trùng số điện thoại" });
            }
        }

        if (fieldErrors.Any())
        {
            throw new AppException("Lỗi khi cập nhật nhà hàng", fieldErrors);
        }

        if (!string.IsNullOrEmpty(request.RestaurantName))
        {
            restaurant.RestaurantName = request.RestaurantName;
        }

        if (!string.IsNullOrEmpty(request.Address))
        {
            restaurant.Address = request.Address;
        }

        if (!string.IsNullOrEmpty(request.RestaurantPhone))
        {
            restaurant.RestaurantPhone = request.RestaurantPhone;
        }
        #endregion

        _unitOfWorks.RestaurantRepository.Update(restaurant);
        await _unitOfWorks.SaveChangeAsync();

        return restaurant.Id;
    }
}
