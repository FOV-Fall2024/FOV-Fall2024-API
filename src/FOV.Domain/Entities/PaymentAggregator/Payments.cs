using System;
using FOV.Domain.Common;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Domain.Entities.PaymentAggregator.Enums;

namespace FOV.Domain.Entities.PaymentAggregator;
public class Payments : BaseAuditableEntity
{
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
    public decimal Amount { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public Guid OrderId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public Order? Order { get; set; }
    public PaymentMethods? PaymentMethods { get; set; }
    public Payments()
    {

    }
    public Payments(decimal amount, Guid orderId, Guid paymentMethodId)
    {
        this.Amount = amount;
        this.OrderId = orderId;
        this.PaymentMethodId = paymentMethodId;
    }
}
