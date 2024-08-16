using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;

namespace FOV.Application.Features.Order.Commands.Update;
public sealed record UpdateOrderCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
}
public class UpdateOrderHandler
{
}
