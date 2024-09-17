using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Categories.Commands.Update;

public sealed record UpdateCategoryCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
}
public class UpdateCategoryHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateCategoryCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = await _unitOfWorks.CategoryRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        category.Update(request.CategoryName);
        _unitOfWorks.CategoryRepository.Update(category);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
