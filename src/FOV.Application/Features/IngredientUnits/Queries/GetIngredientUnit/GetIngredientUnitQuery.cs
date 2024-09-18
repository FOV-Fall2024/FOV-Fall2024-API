using FOV.Application.Features.IngredientUnits.Mapper;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientUnits.Queries.GetIngredientUnit;

public sealed record GetIngredientUnitCommand(Guid IngredientId) : IRequest<List<GetIngredientUnitResponse>>;

public sealed record GetIngredientUnitResponse(Guid IngredientUnitId,Guid? IngredientUnitParentId,string UnitName,decimal ConversionFactor);
public class GetIngredientUnitQuery(IUnitOfWorks unitOfWorks): IRequestHandler<GetIngredientUnitCommand, List<GetIngredientUnitResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<GetIngredientUnitResponse>> Handle(GetIngredientUnitCommand request, CancellationToken cancellationToken)
    {
        List<IngredientUnit> ingredientUnits = await _unitOfWorks.IngredientUnitRepository.WhereAsync(x => x.IngredientId == request.IngredientId);
        return ingredientUnits.Select(x => x.MapperIngredientUnitDTO()).ToList();
       
    }
}
