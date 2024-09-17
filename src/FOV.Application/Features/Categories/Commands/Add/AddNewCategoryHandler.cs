using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Commands.AddNewChildCategory;

public sealed record AddNewCategoryCommand : IRequest<Guid>
{
    public required string Name { get; set; }

}
public class AddNewCategoryHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddNewCategoryCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(AddNewCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new(request.Name);
        await _unitOfWorks.CategoryRepository.AddAsync(category);
        await _unitOfWorks.SaveChangeAsync();
        return category.Id;

    }
}
