using FOV.Domain.Common;
using FOV.Domain.Entities.OrderAggregator.Enums;
using System;

namespace FOV.Domain.Entities.OrderAggregator;

public class OrderResponsibility : BaseAuditableEntity
{
    public Guid OrderId { get; set; }
    public Guid? OrderDetailId { get; set; }
    public string EmployeeCode { get; set; } = string.Empty;
    public string EmployeeName { get; set; } = string.Empty;
    public OrderResponsibilityType OrderResponsibilityType { get; set; } // Loại trách nhiệm (ConfirmOrder, Serve, Refund,...)
    public Order? Order { get; set; }
    public OrderDetail? OrderDetail { get; set; }
    public OrderResponsibility() { }
    public OrderResponsibility(Guid orderId, string employeeCode, string employeeName, OrderResponsibilityType orderResponsibilityType, Guid? orderDetailId = null)
    {
        OrderId = orderId;
        EmployeeCode = employeeCode;
        EmployeeName = employeeName;
        OrderResponsibilityType = orderResponsibilityType;
        OrderDetailId = orderDetailId;
    }
}
