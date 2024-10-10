using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Active;
public sealed record ActiveProductCommand(Guid Id) : IRequest<Result>;
internal class ActiveProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveProductCommand request, CancellationToken cancellationToken)
    {
        Dish product = await _unitOfWorks.DishRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.UpdateState(true);
        _unitOfWorks.DishRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
