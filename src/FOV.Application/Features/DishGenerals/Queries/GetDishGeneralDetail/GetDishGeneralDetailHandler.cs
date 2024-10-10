using FOV.Application.Features.DishGenerals.Mapper;
using FOV.Application.Features.DishGenerals.Responses;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Queries.GetProductGeneralDetail;

public sealed record GetProductGeneralDetailCommand(Guid Id) : IRequest<GetProductGeneralDetailResponse>;



public class GetDishGeneralDetailHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetProductGeneralDetailCommand, GetProductGeneralDetailResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetProductGeneralDetailResponse> Handle(GetProductGeneralDetailCommand request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id,x => x.DishGeneralImages) ?? throw new Exception();
        
        var ingredients = await _unitOfWorks.IngredientGeneralRepository.WhereAsync(x => x.DishIngredientGenerals.Any(x => x.DishGeneralId == request.Id), x => x.DishIngredientGenerals);
        return response.MapperDetailDTO(ingredients.Select(x => x.MapperIngredientDTO(request.Id)).ToList());
    }
}
