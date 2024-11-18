using FOV.Domain.Entities.PaymentAggregator.Enums;

namespace FOV.Application.Features.Payments.Responses;

public record PaymentResponse(Guid PaymentId, decimal Amount, decimal ReduceAmount, decimal FinalAmount, string PaymentStatus, string PaymentMethods, DateTime CreatedDate);


