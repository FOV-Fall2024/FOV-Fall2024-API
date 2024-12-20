﻿using FOV.Application.Features.Dishes.Mappers;
using FOV.Application.Features.Dishes.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Queries.GetDetail;

public sealed record GetDetailCommand(Guid Id) : IRequest<GetDetailResponse>;
public class GetDetailQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetDetailCommand, GetDetailResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetDetailResponse> Handle(GetDetailCommand request, CancellationToken cancellationToken)
    {
        Dish? dish = await _unitOfWorks.DishRepository.GetByIdAsync(request.Id, x => x.DishGeneral.DishGeneralImages, x => x.DishIngredients, x => x.Category);
        var ingredient = await _unitOfWorks.DishIngredientRepository.WhereAsync(x => x.DishId == request.Id, x => x.Ingredient, x => x.Ingredient.IngredientType, x => x.Ingredient.IngredientGeneral, x => x.Ingredient.IngredientGeneral.IngredientMeasure);

        return dish.MapperDetailDTO(dish.DishGeneral.DishGeneralImages.Select(x => x.Url).ToList(), ingredient);

    }
}
