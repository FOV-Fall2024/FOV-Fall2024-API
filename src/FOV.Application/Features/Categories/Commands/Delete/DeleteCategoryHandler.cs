using FluentResults;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Commands.Delete;

public sealed record DeleteCategoryCommand(Guid Id) : IRequest<Result>;
internal class DeleteCategoryHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<DeleteCategoryCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _unitOfWorks.CategoryRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        category.SetState(true);
        _unitOfWorks.CategoryRepository.Update(category);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }

}
