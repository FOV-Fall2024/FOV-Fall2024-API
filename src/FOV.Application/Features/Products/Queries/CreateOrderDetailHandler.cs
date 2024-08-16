using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Order.Commands.Create;
public record CreateOrderDetailCommand(Guid? ComboId, Guid? ProductId, string Status, int Quantity, decimal Price);
public record CreateOrderDetailWithOrderIdCommand(Guid OrderId, Guid? ComboId, Guid? ProductId, string Status, int Quantity, decimal Price) : CreateOrderDetailCommand(ComboId, ProductId, Status, Quantity, Price), IRequest<Guid>;
public class CreateOrderDetailHandler : IRequestHandler<CreateOrderDetailWithOrderIdCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;

    public CreateOrderDetailHandler(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }

    public async Task<Guid> Handle(CreateOrderDetailWithOrderIdCommand request, CancellationToken cancellationToken)
    {
        var orderDetail = new OrderDetail(request.ComboId, request.ProductId, request.OrderId, request.Status, request.Quantity, request.Price);
        await _unitOfWorks.OrderDetailRepository.AddAsync(orderDetail);
        await _unitOfWorks.SaveChangeAsync();
        return orderDetail.Id;
    }
}
