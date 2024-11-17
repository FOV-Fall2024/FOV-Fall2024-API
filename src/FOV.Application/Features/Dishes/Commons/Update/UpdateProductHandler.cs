using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Update;
public sealed record UpdateProductCommand(decimal Price) : IRequest<Result>
{
    [JsonIgnore]
    public Guid ProductId { get; set; }
}
internal class UpdateProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Dish product = await _unitOfWorks.DishRepository.GetByIdAsync(request.ProductId) ?? throw new Exception();
        product.Update(request.Price);

        _unitOfWorks.DishRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
