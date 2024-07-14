using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.IngredientTypes.Commands.CreateIngredientType;

public class CreateIngredientTypeHandler : IRequestHandler<CreateIngredientTypeCommand, Guid>
{

    private readonly IUnitOfWorks _unitOfWork;
    public CreateIngredientTypeHandler(IUnitOfWorks unitOfWorks)
    {
        _unitOfWork = unitOfWorks;
    }

    public async Task<Guid> Handle(CreateIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        IngredientType ingredientType = new(request.Name, request.Description);
        await _unitOfWork.IngredientTypeRepository.AddAsync(ingredientType);
        await _unitOfWork.SaveChangeAsync();
        return ingredientType.Id;
    }
}
