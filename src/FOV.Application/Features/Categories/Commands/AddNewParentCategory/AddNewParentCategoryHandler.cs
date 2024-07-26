using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Commands.AddNewParentCategory;

public sealed record AddNewParentCategoryCommand : IRequest<Guid>
{
    public required string Name { get; set; }
}
public class AddNewParentCategoryHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddNewParentCategoryCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(AddNewParentCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new(request.Name);
        await _unitOfWorks.CategoryRepository.AddAsync(category);
        await _unitOfWorks.SaveChangeAsync();
        return category.Id;
    }
}
