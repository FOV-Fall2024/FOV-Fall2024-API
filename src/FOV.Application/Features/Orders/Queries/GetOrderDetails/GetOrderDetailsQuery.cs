using System.Linq;
using FOV.Application.Features.Orders.Responses;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrderDetails;

public record GetOrderDetailsCommand(Guid OrderId) : IRequest<GetOrderDetailsResponse>;
public record GetOrderDetailsResponse(
    Guid OrderId,
    string OrderStatus,
    decimal TotalPrice,
    DateTime? OrderTime,
    string? Feedback,
    string? ConfirmEmployeeCode,
    string? ConfirmEmployeeName,
    List<OrderResponsibilityDto>? ConfirmAddMore,
    string? PaymentEmployeeCode,
    string? PaymentEmployeeName,
    List<OrderDetailsDto> OrderDetails);

public record OrderDetailsDto(
    Guid Id,
    Guid? ComboId,
    Guid? ProductId,
    string? ComboName,
    string? ProductName,
    string? Thumbnail,
    string? Image,
    string Status,
    int Quantity,
    bool IsRefund,
    int RefundQuantity,
    decimal Price,
    string Note,
    bool? IsAddMore,
    List<OrderDetailResponsibilityDto> Responsibilities);

public record OrderResponsibilityDto(string EmployeeCode, string EmployeeName);
public record OrderDetailResponsibilityDto(string EmployeeCode, string EmployeeName, string ResponsibilityType);

public class GetOrderDetailsQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetOrderDetailsCommand, GetOrderDetailsResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Order not found.");

        var orderResponsibilities = await _unitOfWorks.OrderResponsibilityRepository
            .WhereAsync(or => or.OrderId == request.OrderId);

        var confirmAddMore = orderResponsibilities
            .Where(or => or.OrderResponsibilityType == OrderResponsibilityType.ConfirmAddMore && or.OrderDetailId == null)
            .Select(or => new OrderResponsibilityDto(or.EmployeeCode, or.EmployeeName))
            .ToList();

        var orderDetails = await _unitOfWorks.OrderDetailRepository.WhereAsync(
            od => od.OrderId == order.Id,
            od => od.Order,
            od => od.Combo,
            od => od.Dish,
            od => od.Dish.DishGeneral,
            od => od.Dish.DishGeneral.DishGeneralImages
        );

        var orderDetailsDtos = orderDetails.Select(od =>
        {
            var responsibilities = orderResponsibilities
                .Where(or => or.OrderDetailId == od.Id)
                .Select(or => new OrderDetailResponsibilityDto(or.EmployeeCode, or.EmployeeName, or.OrderResponsibilityType.ToString()))
                .ToList();

            return new OrderDetailsDto(
                od.Id,
                od.ComboId,
                od.ProductId,
                od.Combo?.ComboName,
                od.Dish?.DishGeneral.DishName,
                od.Combo?.Thumbnail,
                od.Dish?.DishGeneral.DishGeneralImages.FirstOrDefault()?.Url.ToString(),
                od.Status?.ToString(),
                od.Quantity,
                od.IsRefund,
                od.RefundQuantity,
                od.Price,
                od.Note,
                od.IsAddMore,
                responsibilities
            );
        }).ToList();

        return new GetOrderDetailsResponse(
            order.Id,
            order.OrderStatus.ToString(),
            order.TotalPrice,
            order.OrderTime,
            order.Feedback,
            orderResponsibilities.FirstOrDefault(or => or.OrderResponsibilityType == OrderResponsibilityType.ConfirmOrder)?.EmployeeCode,
            orderResponsibilities.FirstOrDefault(or => or.OrderResponsibilityType == OrderResponsibilityType.ConfirmOrder)?.EmployeeName,
            confirmAddMore,
            orderResponsibilities.FirstOrDefault(or => or.OrderResponsibilityType == OrderResponsibilityType.Payment)?.EmployeeCode,
            orderResponsibilities.FirstOrDefault(or => or.OrderResponsibilityType == OrderResponsibilityType.Payment)?.EmployeeName,
            orderDetailsDtos
        );
    }

}
