using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Queries.GetParentCategories;

public sealed record GetParentCategoriesCommand : IRequest<List<GetParentCategoriesResponse>>;

public record GetParentCategoriesResponse(Guid Id, string Name, string Des);

public class GetParentIngredientTypesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetParentCategoriesCommand, List<GetParentCategoriesResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetParentCategoriesResponse>> Handle(GetParentCategoriesCommand request, CancellationToken cancellationToken)
    {
        var data = await _unitOfWorks.IngredientTypeRepository.WhereAsync(x => x.ParentId == null);
        return data.Select(x => new GetParentCategoriesResponse(x.Id, x.IngredientName, x.IngredientDescription)).ToList();
    }
}
