using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.PaymentAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Payments.Queries;
public record GetPaymentsRequest(Guid? PaymentId, PaymentStatus? PaymentStatus, PaymentMethods? PaymentMethods) : IRequest<List<PaymentResponse>>;
public record PaymentResponse(Guid PaymentId, decimal Amount, PaymentStatus PaymentStatus, PaymentMethods PaymentMethods);
public class GetPaymentsQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetPaymentsRequest, List<PaymentResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<PaymentResponse>> Handle(GetPaymentsRequest request, CancellationToken cancellationToken)
    {
        var payments = await _unitOfWorks.PaymentRepository.GetAllAsync();
        var filterEntity = new Domain.Entities.PaymentAggregator.Payments
        {
            Id = request.PaymentId ?? Guid.Empty,
            PaymentStatus = request.PaymentStatus ?? PaymentStatus.Pending,
            PaymentMethods = request.PaymentMethods ?? PaymentMethods.Cash
        };

        var filteredPayment = payments.AsQueryable().CustomFilterV1(filterEntity);

        return filteredPayment.Select(p => new PaymentResponse(
                       p.Id,
                                  p.Amount,
                                             p.PaymentStatus,
                                                        p.PaymentMethods)).ToList();
    }
}
