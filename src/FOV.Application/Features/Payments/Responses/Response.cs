using FOV.Domain.Entities.PaymentAggregator.Enums;

namespace FOV.Application.Features.Payments.Responses;

public record PaymentResponse(Guid PaymentId, Guid OrderId, decimal Amount, decimal ReduceAmount, decimal FinalAmount, string PaymentStatus, string PaymentMethods, bool IsAdminConfirm, DateTime CreatedDate);


