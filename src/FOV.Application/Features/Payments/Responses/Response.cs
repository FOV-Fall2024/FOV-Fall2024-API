using FOV.Domain.Entities.PaymentAggregator.Enums;

namespace FOV.Application.Features.Payments.Responses;

public record PaymentResponse(Guid PaymentId, decimal Amount, PaymentStatus PaymentStatus, PaymentMethods PaymentMethods, DateTime CreatedDate);


