using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Commands.Create;

public sealed record CreateChildIngredientTypeCommand : IRequest<Guid>
{
    public string IngredientTypeName { get; set; } = string.Empty;

    public string IngredientTypeDescription { get; set; } = string.Empty;
}

public class CreateIngredientTypeHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateChildIngredientTypeCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreateChildIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        IngredientType ingredientType = new(request.IngredientTypeName, request.IngredientTypeDescription);
        await _unitOfWorks.IngredientTypeRepository.AddAsync(ingredientType);
        await _unitOfWorks.SaveChangeAsync();
        return ingredientType.Id;
    }
}
