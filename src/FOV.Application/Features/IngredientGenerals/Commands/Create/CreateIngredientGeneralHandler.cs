using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Commands.Create;

public record CreateIngredientGeneralCommand(string Name, string Description, Guid IngredientType) : IRequest<Guid>;
public class CreateIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateIngredientGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWork = unitOfWorks;
    public async Task<Guid> Handle(CreateIngredientGeneralCommand request, CancellationToken cancellationToken)
    {
        IngredientGeneral ingredientGeneral = new(request.Name, request.Description, request.IngredientType);
        await _unitOfWork.IngredientGeneralRepository.AddAsync(ingredientGeneral);
        await _unitOfWork.SaveChangeAsync();
        return ingredientGeneral.Id;
    }
}
