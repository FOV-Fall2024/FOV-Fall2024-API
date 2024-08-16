using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FOV.Domain.Entities.OrderAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Order.Commands.Update;
public class UpdateOrderDetailCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public Guid ComboId { get; set; }
    public Guid ProductId { get; set; }
    public string? Status { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
public class UpdateOrderDetailHandler : IRequestHandler<UpdateOrderDetailCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    public UpdateOrderDetailHandler(IUnitOfWorks unitOfWorks)
    {
        _unitOfWorks = unitOfWorks;
    }
    public async Task<Guid> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        OrderDetail orderDetail = await _unitOfWorks.OrderDetailRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        orderDetail.Update(request.ComboId, request.ProductId, request.Status, request.Quantity, request.Price);
        _unitOfWorks.OrderDetailRepository.Update(orderDetail);
        await _unitOfWorks.SaveChangeAsync();
        return orderDetail.Id;
    }
}
