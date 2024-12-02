using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Queries.GetOrderResponsibility;
public record OrderResponsibilitiesCommand(Guid OrderId) : IRequest<OrderResponsibilitiesResponse>;
public record OrderResponsibilitiesResponse(Guid OrderId, List<OrderResponsibilityDto> OrderResponsibilities);
public record OrderResponsibilityDto(Guid? OrderDetailId, string EmployeeCode, string EmployeeName, string OrderResponsibilityType);
public class OrderResponsibilitiesQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<OrderResponsibilitiesCommand, OrderResponsibilitiesResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<OrderResponsibilitiesResponse> Handle(OrderResponsibilitiesCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId, o => o.OrderResponsibilities)
                ?? throw new AppException("Order not found.");

        var orderResponsibilities = order.OrderResponsibilities
                .GroupBy(r => r.OrderId)
                .Select(g => new OrderResponsibilitiesResponse(
                    g.Key,
                    g.Select(r => new OrderResponsibilityDto(
                        r.OrderDetailId,
                        r.EmployeeCode,
                        r.EmployeeName,
                        r.OrderResponsibilityType.ToString()
                    )).ToList()
                ))
                .FirstOrDefault();

        if (orderResponsibilities == null)
        {
            return new OrderResponsibilitiesResponse(request.OrderId, new List<OrderResponsibilityDto>());
        }

        return orderResponsibilities;
    }
}
