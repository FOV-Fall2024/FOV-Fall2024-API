using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Queries.GetChildCategories;

public sealed record GetChildCategoriesCommand(Guid parentId) : IRequest<List<GetChildrenIngredientType>>;

public record GetChildrenIngredientType(Guid categoryId, int left, int right, string ingredientTypeName, string ingredientTypeDescription);

public class GetChildIngredientTypesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetChildCategoriesCommand, List<GetChildrenIngredientType>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetChildrenIngredientType>> Handle(GetChildCategoriesCommand request, CancellationToken cancellationToken)
    {
        // Implement the actual logic here to fetch and return the list of child categories.
        var ingredientTypes = await _unitOfWorks.IngredientTypeRepository.WhereAsync(x => x.ParentId == request.parentId);
        return ingredientTypes.Select(x => new GetChildrenIngredientType(
           x.Id,
           x.Left,
           x.Right,
           x.IngredientName,
           x.IngredientDescription
       )).ToList();
    }
}
