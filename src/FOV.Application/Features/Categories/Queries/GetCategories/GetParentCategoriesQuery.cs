using FOV.Application.Features.Categories.Reponses;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Queries.GetParentCategories;

public sealed record GetCategoriesCommand : IRequest<List<GetParentCategoriesResponse>>;



public class GetParentCategoriesQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetCategoriesCommand, List<GetParentCategoriesResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetParentCategoriesResponse>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
    {
        var responses = await _unitOfWorks.CategoryRepository.GetAllAsync();
        return responses.Select(x => new GetParentCategoriesResponse(x.Id, x.CategoryName)).ToList();
    }
}
