using FOV.Domain.Entities.OrderAggregator.Enums;

namespace FOV.Application.Features.Orders.Responses;

public record GetOrderDetailsResponse(Guid OrderId, string OrderStatus, decimal TotalPrice, DateTime? OrderTime, List<OrderDetailsDto> OrderDetails);
public record OrderDetailsDto(Guid Id, Guid? ComboId, Guid? ProductId, string? ComboName, string? ProductName, string? Thumbnail, string? Image, string Status, int Quantity, bool IsRefund, int RefundQuantity, decimal Price, string Note);

