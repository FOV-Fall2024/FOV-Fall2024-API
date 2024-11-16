using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.CreateVariant;
public sealed record CreateVariantGeneralDishCommand(Guid GeneralDishId) : IRequest<Result>;
public class CreateVariantGeneralDishHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateVariantGeneralDishCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(CreateVariantGeneralDishCommand request, CancellationToken cancellationToken)
    {
        DishGeneral dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.GeneralDishId, x => x.DishGeneralImages, x => x.Ingredients) ?? throw new Exception();
        DishGeneral variantGeneralDish = new(dishGeneral.DishName, dishGeneral.Price, dishGeneral.DishDescription, dishGeneral.CategoryId, dishGeneral.IsRefund, dishGeneral.PercentagePriceDifference);

        await _unitOfWorks.DishGeneralRepository.AddAsync(variantGeneralDish);
        await IngredientHandler(dishGeneral, variantGeneralDish.Id);
        await ImageHandler(dishGeneral,variantGeneralDish.Id);

        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();

    }

    public async Task IngredientHandler(DishGeneral dishGeneral, Guid variantGeneralDishId)
    {
        foreach (var ingredient in dishGeneral.Ingredients)
        {
            DishIngredientGeneral ingredientAdd = new(variantGeneralDishId, ingredient.Id, ingredient.Quantity);
            await _unitOfWorks.DishIngredientGeneralRepository.AddAsync(ingredientAdd);
        }
    }

    public async Task ImageHandler(DishGeneral dishGeneral, Guid variantGeneralDishId)
    {
        foreach (var image in dishGeneral.DishGeneralImages)
        {
            DishGeneralImage generalImage = new(image.Url, variantGeneralDishId, image.Order);
            await _unitOfWorks.DishGeneralImageRepository.AddAsync(generalImage);
        }

    }
}
