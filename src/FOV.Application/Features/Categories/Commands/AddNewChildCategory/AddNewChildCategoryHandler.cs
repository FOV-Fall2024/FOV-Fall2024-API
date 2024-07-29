using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Commands.AddNewChildCategory;

public sealed record AddNewChildCategoryCommand : IRequest<Guid>
{
    public required string Name { get; set; }

    public Guid CategoryParentId { get; set; }
}
public class AddNewChildCategoryHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddNewChildCategoryCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(AddNewChildCategoryCommand request, CancellationToken cancellationToken)
    {
        Category parentCategory = await _unitOfWorks.CategoryRepository.GetByIdAsync(request.CategoryParentId) ?? throw new Exception();
        Category category =  new(request.Name, parentCategory.Id, parentCategory.CategoryMain, parentCategory.Right);
        await _unitOfWorks.CategoryRepository.UpdateCategoryParent(parentCategory.Id, parentCategory.Right);
        await _unitOfWorks.CategoryRepository.AddAsync(category);
        await _unitOfWorks.SaveChangeAsync();
        return category.Id;

    }
}
