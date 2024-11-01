using FOV.Domain.Entities.PaymentAggregator.Enums;

namespace FOV.Application.Features.Payments.Responses;

public record PaymentResponse(Guid PaymentId, decimal Amount, string PaymentStatus, string PaymentMethods, DateTime CreatedDate);


