using FOV.Application.Features.DishGenerals.Mapper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Queries.GetProductGeneralDetail;

public sealed record GetProductGeneralDetailCommand(Guid Id) : IRequest<GetProductGeneralDetailResponse>;

public record GetProductGeneralDetailResponse(Guid Id, string Name, string Description, DateTimeOffset CreatedDate, DateTimeOffset UpdateDated, List<GetIngredientResponse> GetIngredients);

public record GetIngredientResponse(Guid Id, string Name, decimal Quantity);
public class GetDishGeneralDetailHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetProductGeneralDetailCommand, GetProductGeneralDetailResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetProductGeneralDetailResponse> Handle(GetProductGeneralDetailCommand request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        var ingredients = await _unitOfWorks.IngredientGeneralRepository.WhereAsync(x => x.DishIngredientGenerals.Any(x => x.DishGeneralId == request.Id), x => x.DishIngredientGenerals);
        return response.MapperDetailDTO(ingredients.Select(x => x.MapperIngredientDTO(request.Id)).ToList());
    }
}
