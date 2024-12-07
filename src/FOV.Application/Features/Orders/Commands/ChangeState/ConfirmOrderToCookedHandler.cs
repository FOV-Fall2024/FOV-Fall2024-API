using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.OrderAggregator.Enums;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.FCM;
using FOV.Infrastructure.FirebaseDB;
using FOV.Infrastructure.Notifications.Web.SignalR.Order.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Orders.Commands.ChangeState;
public record ConfirmOrderCookedCommand(Guid OrderId, Guid OrderDetailId) : IRequest<Guid>;
public class ConfirmOrderToCookedHandler(IUnitOfWorks unitOfWorks, OrderHub orderHub, IClaimService claimService, UserManager<User> userManager) : IRequestHandler<ConfirmOrderCookedCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly OrderHub _orderHub = orderHub;
    private readonly IClaimService _claimService = claimService;
    private readonly UserManager<User> _userManager = userManager;
    public async Task<Guid> Handle(ConfirmOrderCookedCommand request, CancellationToken cancellationToken)
    {
        var userId = _claimService.UserId;
        var employee = await _userManager.FindByIdAsync(userId.ToString())
            ?? throw new AppException("Employee not found");

        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderDetails)
            ?? throw new AppException("Order not found");

        var orderDetail = order.OrderDetails.FirstOrDefault(d => d.Id == request.OrderDetailId)
            ?? throw new AppException("Order detail not found");

        if (orderDetail.Status != OrderDetailsStatus.Cook)
        {
            throw new AppException("Món ăn này chưa được confirm nên không thể confirm là nấu xong được");
        }

        var orderResponsibility = new OrderResponsibility
        {
            OrderId = order.Id,
            EmployeeCode = employee.EmployeeCode,
            EmployeeName = $"{employee.FullName}",
            OrderResponsibilityType = OrderResponsibilityType.Cooked,
            OrderDetailId = orderDetail.Id
        };
        await _unitOfWorks.OrderResponsibilityRepository.AddAsync(orderResponsibility);

        orderDetail.Status = OrderDetailsStatus.Cooked;

        if (order.OrderDetails.All(d => d.Status == OrderDetailsStatus.Cooked))
        {
            order.OrderStatus = OrderStatus.Cooked;
            await _orderHub.UpdateOrderStatus(order.Id, order.OrderStatus.ToString());
        }

        _unitOfWorks.OrderDetailRepository.Update(orderDetail);
        await _unitOfWorks.SaveChangeAsync();

        var table = await _unitOfWorks.TableRepository.GetByIdAsync(order.TableId);
        var restaurantId = table.Restaurant.Id;
        var userInRestaurantAlreadyCheckAttendance = _userManager.Users
            .Where(x => x.RestaurantId == restaurantId &&
                        x.WaiterSchedules.Any(ws =>
                            ws.Attendances.Any(a =>
                                a.CheckInTime != null &&
                                a.CheckOutTime == null &&
                                ws.DateTime == DateOnly.FromDateTime(DateTime.Now.AddHours(7)))))
            .Include(x => x.WaiterSchedules)
                .ThenInclude(ws => ws.Attendances)
            .ToList();

        foreach (var eachUserInRestaurantAlreadyCheckAttendance in userInRestaurantAlreadyCheckAttendance)
        {
            var tokenUser = await FCMTokenHandler.GetFCMToken(eachUserInRestaurantAlreadyCheckAttendance.Id);
            await CloudMessagingHandlers.SendNotification(tokenUser, $"Đầu bếp đã nấu xong", $"Đầu bếp đã nấu xong món ăn tại bàn {table.TableNumber}");
        }
        return order.Id;
    }
}
