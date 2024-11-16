using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientMeasures.Queries.Get;
public sealed record GetIngredientMeasureCommand(string? IngredientMeasureName) : IRequest<List<GetIngredientMeasureResponse>>;
public sealed record GetIngredientMeasureResponse(Guid Id, string IngredientMeasureName);
public sealed class GetIngredientMeasureQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetIngredientMeasureCommand, List<GetIngredientMeasureResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetIngredientMeasureResponse>> Handle(GetIngredientMeasureCommand request, CancellationToken cancellationToken)
    {
        var ingredientMeasures = await _unitOfWorks.IngredientMeasureRepository.GetAllAsync();
        var filteredIngredientMeasure = ingredientMeasures.AsQueryable()
           .Where(x => string.IsNullOrEmpty(request.IngredientMeasureName) ||
                       x.IngredientMeasureName.Contains(request.IngredientMeasureName, StringComparison.OrdinalIgnoreCase));
        return filteredIngredientMeasure.Select(x => new GetIngredientMeasureResponse(x.Id, x.IngredientMeasureName)).ToList();
    }
}
