using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Commands.Create;
public record CreateIngredientTypeCommand(string Name, string Description) : IRequest<Guid>;


public class CreateIngredientTypeHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateIngredientTypeCommand, Guid>
{

    private readonly IUnitOfWorks _unitOfWork = unitOfWorks;

    public async Task<Guid> Handle(CreateIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        IngredientType ingredientType = new(request.Name, request.Description);
        await _unitOfWork.IngredientTypeRepository.AddAsync(ingredientType);
        await _unitOfWork.SaveChangeAsync();
        return ingredientType.Id;
    }
}
