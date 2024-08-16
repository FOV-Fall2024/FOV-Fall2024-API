using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Orders.Commands.CreateOrder;
public sealed record CreateOrderCommand(Guid RestaurantId, ProductHandler Product)  : IRequest<Guid>;
public sealed record ProductHandler(List<Guid> ProductId);
public class CreateOrderHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        //? CreateOrder with State InPrepare
        //? 

        Order order = new();
        throw new NotImplementedException();
    }
}
