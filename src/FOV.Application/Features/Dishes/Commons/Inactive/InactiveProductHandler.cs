using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Inactive;
public sealed record InactiveProductCommand(Guid Id) : IRequest<Result>;
internal class InactiveProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveProductCommand request, CancellationToken cancellationToken)
    {
        Dish product = await _unitOfWorks.DishRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.UpdateState(true);
        _unitOfWorks.DishRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
