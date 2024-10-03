using FOV.Application.Features.IngredientTypes.Responses;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Queries.GetChildCategories;

public sealed record GetChildCategoriesCommand(Guid ParentId) : IRequest<List<GetChildrenIngredientType>>;



public class GetChildIngredientTypesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetChildCategoriesCommand, List<GetChildrenIngredientType>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetChildrenIngredientType>> Handle(GetChildCategoriesCommand request, CancellationToken cancellationToken)
    {
        var ingredientTypes = await _unitOfWorks.IngredientTypeRepository.WhereAsync(x => x.ParentId == request.ParentId);
        return ingredientTypes.Select(x => new GetChildrenIngredientType(
           x.Id,
           x.Left,
           x.Right,
           x.IngredientName,
           x.IngredientDescription
       )).ToList();
    }
}
