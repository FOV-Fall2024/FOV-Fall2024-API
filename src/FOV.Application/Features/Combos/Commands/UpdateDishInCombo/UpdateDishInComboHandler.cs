using FluentResults;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.UpdateDishInCombo;
public sealed record UpdateDishInComboCommand(List<DishCommand> Dishes, Guid ComboId) : IRequest<Result>;
public sealed record DishCommand(int Quantity, Guid DishId);

public class UpdateDishInComboHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateDishInComboCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateDishInComboCommand request, CancellationToken cancellationToken)
    {
        foreach (var dish in request.Dishes)
        {
            DishCombo dishCombo = await _unitOfWorks.DishComboRepository.FirstOrDefaultAsync(x => x.DishId == dish.DishId && x.ComboId == request.ComboId) ?? throw new Exception();
            dishCombo.UpdateQuantity(dish.Quantity);
        }
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
