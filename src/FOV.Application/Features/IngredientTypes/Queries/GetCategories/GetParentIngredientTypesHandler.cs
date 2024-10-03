using FOV.Application.Features.IngredientTypes.Responses;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Queries.GetParentCategories;

public sealed record GetParentCategoriesCommand : IRequest<List<GetParentCategoriesResponse>>;



public class GetParentIngredientTypesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetParentCategoriesCommand, List<GetParentCategoriesResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetParentCategoriesResponse>> Handle(GetParentCategoriesCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWorks.IngredientTypeRepository.GetAllAsync();
        return data.Select(x => new GetParentCategoriesResponse(x.Id, x.IngredientName, x.IngredientDescription)).ToList();
    }
}
