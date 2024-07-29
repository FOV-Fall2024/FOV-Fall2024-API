using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Commands.CreateChild;

public sealed record CreateChildIngredientTypeCommand : IRequest<Guid>
{
    public Guid ParentId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

public class CreateChildIngredientTypeHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateChildIngredientTypeCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreateChildIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        IngredientType parentIngredient = await _unitOfWorks.IngredientTypeRepository.GetByIdAsync(request.ParentId) ?? throw new Exception();
        IngredientType ingredientType = new(request.Name, request.Description, parentIngredient.Right, parentIngredient.IngredientMain, request.ParentId);
        await _unitOfWorks.IngredientTypeRepository.AddAsync(ingredientType);
        await _unitOfWorks.IngredientTypeRepository.UpdateParentIngredientType(parentIngredient.Id, parentIngredient.Right);
        await _unitOfWorks.SaveChangeAsync();
        return ingredientType.Id;
    }
}
