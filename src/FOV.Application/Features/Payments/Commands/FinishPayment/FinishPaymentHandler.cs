﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Payments.Commands.FinishPayment;
public sealed record FinishPaymentCommand(Guid OrderId) : IRequest<Guid>;

public class FinishPaymentHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, IClaimService claimService, UserManager<User> userManager) : IRequestHandler<FinishPaymentCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;
    private readonly IClaimService _claimService = claimService;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<Guid> Handle(FinishPaymentCommand request, CancellationToken cancellationToken)
    {
        var userId = _claimService.UserId;
        var employee = await _userManager.FindByIdAsync(userId.ToString())
            ?? throw new AppException("Employee not found");

        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.Payments, t => t.Table)
            ?? throw new Exception("Đơn hàng không tồn tại");

        var payment = order.Payments.FirstOrDefault();
        if (payment == null)
        {
            throw new Exception("Thông tin thanh toán không tồn tại");
        }

        if (payment.PaymentStatus != PaymentStatus.Paid)
        {
            payment.PaymentStatus = PaymentStatus.Paid;
            _unitOfWorks.PaymentRepository.Update(payment);
        }

        if (order.OrderStatus != OrderStatus.Finish)
        {
            order.OrderStatus = OrderStatus.Finish;
            _unitOfWorks.OrderRepository.Update(order);
        }

        if (order.Table != null)
        {
            order.Table.TableStatus = TableStatus.Available;
            _unitOfWorks.TableRepository.Update(order.Table);
        }

        var orderResponsibility = new OrderResponsibility
        {
            OrderId = order.Id,
            EmployeeCode = employee.EmployeeCode,
            EmployeeName = $"{employee.FullName}",
            OrderResponsibilityType = OrderResponsibilityType.Payment
        };
        await _unitOfWorks.OrderResponsibilityRepository.AddAsync(orderResponsibility);

        await _unitOfWorks.SaveChangeAsync();
        await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());

        return payment.Id;
    }
}
