using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.AddFeedback;
public record AddFeedBackToOrderCommand(Guid OrderId, string Feedback) : IRequest<Guid>;
public class AddFeedbackToOrderHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddFeedBackToOrderCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(AddFeedBackToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _unitOfWorks.OrderRepository.GetByIdAsync(request.OrderId) ?? throw new Exception("Không có Order");
        order.Feedback = request.Feedback;
        _unitOfWorks.OrderRepository.Update(order);
        await _unitOfWorks.SaveChangeAsync();
        return order.Id;
    }
}
