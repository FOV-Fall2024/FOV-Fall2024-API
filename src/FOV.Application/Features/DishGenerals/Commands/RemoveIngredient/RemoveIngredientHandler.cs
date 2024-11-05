using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.RemoveIngredient;

public sealed record RemoveIngredientCommand(List<Guid> IngredientId) : IRequest<Result>
{
    [JsonIgnore]
    public Guid ProductId { get; set; }
};

public class RemoveIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RemoveIngredientCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(RemoveIngredientCommand request, CancellationToken cancellationToken)
    {
        foreach (var ingreId in request.IngredientId)
        {
            DishIngredientGeneral general = await _unitOfWorks.DishIngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientGeneralId == ingreId && x.DishGeneralId == request.ProductId, x => x.IngredientGeneral) ?? throw new Exception();
            await UpdateDishesWithIngredient(request.ProductId, general.IngredientGeneral.IngredientName);
            _unitOfWorks.DishIngredientGeneralRepository.Remove(general);
            await UpdateDishesWithIngredient(request.ProductId, general.IngredientGeneral.IngredientName);
        }

        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }

    private async Task UpdateDishesWithIngredient(Guid dishGeneralId, string ingredientName)
    {
        var dishes = await _unitOfWorks.DishRepository.WhereAsync(d => d.DishGeneralId == dishGeneralId);

        foreach (var dish in dishes)
        {
            var ingredient = await _unitOfWorks.IngredientRepository
                .FirstOrDefaultAsync(i => i.IngredientGeneral.IngredientName == ingredientName && i.RestaurantId == dish.RestaurantId);
            await UpdateDishIngredient(dish.Id, ingredient.Id);
        }
    }



    private async Task UpdateDishIngredient(Guid dishId, Guid ingredientId)
    {
        DishIngredient dishIngredient = await _unitOfWorks.DishIngredientRepository.FirstOrDefaultAsync(x => x.IngredientId == ingredientId && x.DishId == dishId) ?? throw new Exception();
        dishIngredient.ChangeState(Domain.Entities.DishAggregator.Enums.DishIngredientStatus.RecentRemove);
        _unitOfWorks.DishIngredientRepository.Update(dishIngredient);
        await _unitOfWorks.SaveChangeAsync();
    }


}
