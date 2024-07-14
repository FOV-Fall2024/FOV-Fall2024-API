using MediatR;

namespace FOV.Application.IngredientTypes.Commands.UpdateIngredientType;

public sealed record UpdateIngredientTypeCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

public class UpdateIngredientTypeHandler : IRequestHandler<UpdateIngredientTypeCommand, Guid>
{

    public Task<Guid> Handle(UpdateIngredientTypeCommand request, CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }
}
