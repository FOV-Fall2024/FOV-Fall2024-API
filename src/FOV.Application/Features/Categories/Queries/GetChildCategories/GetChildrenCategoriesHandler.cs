using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Queries.GetChildCategories;

public sealed record GetChilCategoriesCommand(Guid Id) : IRequest<List<GetChildCategoriesResponse>>;

public record GetChildCategoriesResponse(Guid Id, int Left, int Right, string Name);

public class GetChildrenCategoriesHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetChilCategoriesCommand, List<GetChildCategoriesResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetChildCategoriesResponse>> Handle(GetChilCategoriesCommand request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWorks.CategoryRepository.WhereAsync(x => x.CategoryParentId == request.Id);
        return response.Select(x => new GetChildCategoriesResponse(x.Id, x.Left, x.Right, x.CategoryName)).ToList();
    }
}
