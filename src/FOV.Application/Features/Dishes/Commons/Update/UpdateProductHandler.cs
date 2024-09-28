using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Update;
public sealed record UpdateProductCommand(string ProductName, string ProductDescription) : IRequest<Result>
{
    [JsonIgnore]
    public Guid ProductId { get; set; }
}
internal class UpdateProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Dish product = await _unitOfWorks.ProductRepository.GetByIdAsync(request.ProductId) ?? throw new Exception();
        product.Update(request.ProductName, request.ProductDescription);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
