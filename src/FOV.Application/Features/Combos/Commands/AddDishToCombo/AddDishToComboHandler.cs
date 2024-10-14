using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.AddDishToCombo;

public sealed record AddDishToComboCommand(decimal Price, List<DishAddingCommand> ProductAdding) : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}

public sealed record DishAddingCommand(Guid DishId, int Quantity);

public class AddDishToComboHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddDishToComboCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(AddDishToComboCommand request, CancellationToken cancellationToken)
    {
        Combo combo = await _unitOfWorks.ComboRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        combo.Update(request.Price);
        await UpdateProductInCombo(request.ProductAdding, combo.Id);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }

    private async Task UpdateProductInCombo(List<DishAddingCommand> dishIdList, Guid comboId)
    {
        foreach (var dish in dishIdList)
        {
            DishCombo? dishCombo = await _unitOfWorks.DishComboRepository.FirstOrDefaultAsync(x => x.DishId == dish.DishId);
            if (dishCombo == null)
            {
                await _unitOfWorks.DishComboRepository.AddAsync(new DishCombo(dish.DishId, comboId, dish.Quantity));

            }
            else
            {
                DishCombo combo = await _unitOfWorks.DishComboRepository.FirstOrDefaultAsync(x => x.DishId == dish.DishId && x.ComboId == comboId) ?? throw new Exception();
                combo.UpdateQuantity(dish.Quantity);
                _unitOfWorks.DishComboRepository.Update(combo);
            }
        }
    }
}
