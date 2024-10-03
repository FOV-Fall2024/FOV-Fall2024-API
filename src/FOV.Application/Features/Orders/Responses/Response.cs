using FOV.Domain.Entities.OrderAggregator.Enums;

namespace FOV.Application.Features.Orders.Responses;

public record GetOrderDetailsResponse(Guid OrderId, List<OrderDetailsDto> OrderDetails);
public record OrderDetailsDto(Guid Id, Guid? ComboId, Guid? ProductId, OrderDetailsStatus? Status, int Quantity, decimal Price);

