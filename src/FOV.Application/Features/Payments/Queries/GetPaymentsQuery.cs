using FOV.Application.Features.Payments.Responses;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Payments.Queries;
public record GetPaymentsRequest(Guid? PaymentId, Guid? OrderId, PaymentStatus? PaymentStatus, PaymentMethods? PaymentMethods) : IRequest<List<PaymentResponse>>;

public class GetPaymentsQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetPaymentsRequest, List<PaymentResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<PaymentResponse>> Handle(GetPaymentsRequest request, CancellationToken cancellationToken)
    {
        var payments = await _unitOfWorks.PaymentRepository.GetAllAsync();
        var filterEntity = new Domain.Entities.PaymentAggregator.Payments
        {
            Id = request.PaymentId ?? Guid.Empty,
            OrderId = request.OrderId ?? Guid.Empty,
            PaymentStatus = request.PaymentStatus ?? PaymentStatus.Pending,
            PaymentMethods = request.PaymentMethods ?? PaymentMethods.Cash
        };

        var filteredPayment = payments.AsQueryable().CustomFilterV1(filterEntity);

        return filteredPayment.Select(p => new PaymentResponse(
            p.Id,
            p.OrderId,
            p.Amount,
            p.ReduceAmount,
            p.FinalAmount,
            p.PaymentStatus.ToString(),
            p.PaymentMethods.ToString(), p.Created)).ToList();
    }
}
