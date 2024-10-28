﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Infrastructure.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.RefundOrder;
public record RefundOrderCommand(Guid OrderDetailId, int RefundQuantity) : IRequest<Guid>
{
    [JsonIgnore]
    public Guid OrderId { get; set; }
}
public class RefundOrderHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub) : IRequestHandler<RefundOrderCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;
    public async Task<Guid> Handle(RefundOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new Exception("Không tìm thấy đơn hàng nào");

        var orderDetail = order.OrderDetails.FirstOrDefault(od => od.Id == request.OrderDetailId)
            ?? throw new Exception("Không tìm thấy món ăn này trong đơn hàng");

        var productIdOrComboId = orderDetail.ProductId ?? orderDetail.ComboId;

        if (request.RefundQuantity > orderDetail.Quantity || request.RefundQuantity <= 0)
        {
            throw new Exception("Số lượng hoàn trả không hợp lệ");
        }

        orderDetail.RefundQuantity += request.RefundQuantity;

        _unitOfWorks.OrderDetailRepository.Update(orderDetail);
        await _unitOfWorks.SaveChangeAsync();

        await _orderHub.RefundOrderDetails(order.Id, productIdOrComboId.Value, request.RefundQuantity);
        return order.Id;
    }
}
