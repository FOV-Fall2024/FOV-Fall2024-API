using MediatR;

namespace FOV.Application.Features.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(List<ProductCommand>  Products, List<ComboCommand> Combos,string Note) : IRequest<Guid>;
public sealed record ProductCommand(Guid ProductId,int quantity);
public sealed record ComboCommand(Guid ComboId,int quantity);
internal class CreateOrderHandler
{
}
