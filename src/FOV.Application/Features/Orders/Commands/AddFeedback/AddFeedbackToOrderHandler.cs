using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.AddFeedback;
public record AddFeedBackToOrderCommand(Guid OrderId, string FeedBack) : IRequest<Guid>;
public class AddFeedbackToOrderHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddFeedBackToOrderCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public Task<Guid> Handle(AddFeedBackToOrderCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
