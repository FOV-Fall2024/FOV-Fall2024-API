using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientMeasures.Commands.Create;

public sealed record CreateIngredientMeasureCommand(string IngredientMeasureName) : IRequest<Guid>;
public class CreateIngredientMeasureHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateIngredientMeasureCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(CreateIngredientMeasureCommand request, CancellationToken cancellationToken)
    {
        IngredientMeasure ingredientMeasure = new(request.IngredientMeasureName);
        await _unitOfWorks.IngredientMeasureRepository.AddAsync(ingredientMeasure);
        await _unitOfWorks.SaveChangeAsync();
        return ingredientMeasure.Id;
    }
}
