using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Queries.GetParentCategories;

public sealed record GetParentCategoriesCommand : IRequest<List<GetParentCategoriesResponse>>;

public record GetParentCategoriesResponse(Guid Id, string Name);

public class GetParentCategoriesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetParentCategoriesCommand, List<GetParentCategoriesResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetParentCategoriesResponse>> Handle(GetParentCategoriesCommand request, CancellationToken cancellationToken)
    {
        var reponse = await _unitOfWorks.CategoryRepository.WhereAsync(x => x.CategoryMain == null);
        return reponse.Select(x => new GetParentCategoriesResponse(x.Id, x.CategoryName)).ToList();
    }
}
