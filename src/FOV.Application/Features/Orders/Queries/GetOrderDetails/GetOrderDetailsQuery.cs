using FOV.Application.Features.Orders.Responses;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrderDetails;

public record GetOrderDetailsCommand(Guid OrderId) : IRequest<GetOrderDetailsResponse>;
public record GetOrderDetailsResponse(Guid OrderId, string OrderStatus, decimal TotalPrice, DateTime? OrderTime, string? Feedback, List<OrderDetailsDto> OrderDetails);
public record OrderDetailsDto(Guid Id, Guid? ComboId, Guid? ProductId, string? ComboName, string? ProductName, string? Thumbnail, string? Image, string Status, int Quantity, bool IsRefund, int RefundQuantity, decimal Price, string Note, bool? IsAddMore);

public class GetOrderDetailsQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetOrderDetailsCommand, GetOrderDetailsResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Order not found.");
        var orderDetails = await _unitOfWorks.OrderDetailRepository.WhereAsync(
            od => od.OrderId == order.Id,
            od => od.Order,
            od => od.Combo,
            od => od.Dish,
            od => od.Dish.DishGeneral,
            od => od.Dish.DishGeneral.DishGeneralImages
        );

        var orderDetailsDtos = orderDetails.Select(od => new OrderDetailsDto(
            od.Id,
            od.ComboId,
            od.ProductId,
            od.Combo != null ? od.Combo.ComboName : null,
            od.Dish != null ? od.Dish.DishGeneral.DishName : null,
            od.Combo != null ? od.Combo.Thumbnail : null,
            od.Dish != null && od.Dish.DishGeneral.DishGeneralImages.Any() ? od.Dish.DishGeneral.DishGeneralImages.FirstOrDefault().Url.ToString() : null,
            od.Status.HasValue ? od.Status.Value.ToString() : null,
            od.Quantity,
            od.IsRefund,
            od.RefundQuantity,
            od.Price,
            od.Note,
            od.IsAddMore
        )).ToList();

        return new GetOrderDetailsResponse(
            order.Id,
            order.OrderStatus.ToString(),
            order.TotalPrice,
            order.OrderTime,
            order.Feedback,
            orderDetailsDtos
        );
    }
}
