using System.Linq;
using FOV.Application.Features.Orders.Responses;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrderDetails;

public record GetOrderDetailsCommand(Guid OrderId) : IRequest<GetOrderDetailsResponse>;
public record GetOrderDetailsResponse(
    Guid OrderId,
    string OrderStatus,
    decimal TotalPrice,
    DateTime? OrderTime,
    string? Vnp_TxnRef,
    string? Feedback,
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
    string? ConfirmOrderEmployeeCode,
    string? ConfirmOrderEmployeeName,
    string? CookedEmployeeCode,
    string? CookedEmployeeName,
    string? ServeEmployeeCode,
    string? ServeEmployeeName,
    string? RefundEmployeeCode,
    string? RefundEmployeeName,
    string? CancelEmployeeCode,
    string? CancelEmployeeName
);


public record OrderDetailResponsibilityDto(string EmployeeCode, string EmployeeName, string ResponsibilityType);

public class GetOrderDetailsQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetOrderDetailsCommand, GetOrderDetailsResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<GetOrderDetailsResponse> Handle(GetOrderDetailsCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails, o => o.Payments)
            ?? throw new Exception("Order not found.");

        var orderResponsibilities = await _unitOfWorks.OrderResponsibilityRepository
            .WhereAsync(or => or.OrderId == request.OrderId);

        var orderDetails = await _unitOfWorks.OrderDetailRepository.WhereAsync(
            od => od.OrderId == order.Id,
            od => od.Order,
            od => od.Order.Payments,
            od => od.Combo,
            od => od.Dish,
            od => od.Dish.DishGeneral,
            od => od.Dish.DishGeneral.DishGeneralImages
        );

        var orderDetailsDtos = orderDetails.Select(od =>
        {
            var confirmAddMoreResponsibility = orderResponsibilities
                .FirstOrDefault(or => or.OrderDetailId == od.Id && or.OrderResponsibilityType == OrderResponsibilityType.ConfirmAddMore);
            var confirmOrderResponsibility = orderResponsibilities
                .FirstOrDefault(or => or.OrderDetailId == od.Id && or.OrderResponsibilityType == OrderResponsibilityType.ConfirmOrder);
            var cancelResponsibility = orderResponsibilities
                .FirstOrDefault(or => or.OrderDetailId == od.Id && or.OrderResponsibilityType == OrderResponsibilityType.Cancel);
            var cookedResponsibility = orderResponsibilities
                .Where(or => or.OrderDetailId == od.Id && or.OrderResponsibilityType == OrderResponsibilityType.Cooked)
                .FirstOrDefault();
            var serveResponsibility = orderResponsibilities
                .Where(or => or.OrderDetailId == od.Id && or.OrderResponsibilityType == OrderResponsibilityType.Serve)
                .FirstOrDefault();
            var refundResponsibility = orderResponsibilities
                .Where(or => or.OrderDetailId == od.Id && or.OrderResponsibilityType == OrderResponsibilityType.Refund)
                .FirstOrDefault();

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
                confirmOrderResponsibility?.EmployeeCode,
                confirmOrderResponsibility?.EmployeeName,
                cookedResponsibility?.EmployeeCode,
                cookedResponsibility?.EmployeeName,
                serveResponsibility?.EmployeeCode,
                serveResponsibility?.EmployeeName,
                refundResponsibility?.EmployeeCode,
                refundResponsibility?.EmployeeName,
                cancelResponsibility?.EmployeeCode,
                cancelResponsibility?.EmployeeName
            );
        }).ToList();

        return new GetOrderDetailsResponse(
            order.Id,
            order.OrderStatus.ToString(),
            order.TotalPrice,
            order.OrderTime,
            order.Payments.Where(x => x.PaymentStatus != PaymentStatus.Failed && x.PaymentStatus != PaymentStatus.Paid)
                .OrderByDescending(x => x.Created)
                .FirstOrDefault().VnpTxnRef,
            order.Feedback,
            orderResponsibilities.FirstOrDefault(or => or.OrderResponsibilityType == OrderResponsibilityType.Payment)?.EmployeeCode,
            orderResponsibilities.FirstOrDefault(or => or.OrderResponsibilityType == OrderResponsibilityType.Payment)?.EmployeeName,
            orderDetailsDtos
        );
    }
}
