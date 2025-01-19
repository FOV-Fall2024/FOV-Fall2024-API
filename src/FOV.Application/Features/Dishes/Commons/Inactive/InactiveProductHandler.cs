using FluentResults;
using FOV.Application.Common.Exceptions;
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
        Dish dish = await _unitOfWorks.DishRepository.GetByIdAsync(request.Id)
            ?? throw new AppException("Dish not found");

        dish.UpdateState(false);
        _unitOfWorks.DishRepository.Update(dish);

        var relatedCombos = await _unitOfWorks.ComboRepository.WhereAsync(
            combo => combo.DishCombos.Any(dc => dc.DishId == request.Id)
        );

        foreach (var combo in relatedCombos)
        {
            combo.UpdateState(false);
        }

        _unitOfWorks.ComboRepository.UpdateRange(relatedCombos);

        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }
}
