using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.IngredientTypes.Commands.CreateIngredientType;

public sealed record CreateIngredientTypeCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Descriptkon { get; set; } = string.Empty;
}

public class CreateIngredientTypeHandler : IRequestHandler<CreateIngredientTypeCommand, Guid>
{
    public Task<Guid> Handle(CreateIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
