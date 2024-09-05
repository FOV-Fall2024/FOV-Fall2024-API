using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Products.Commons.Add;

public sealed record AddProductCommand(Guid ProductId) : IRequest<Result>;


internal class AddProductHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<AddProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        ProductGeneral productGeneral = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(request.ProductId) ?? throw new Exception();
        Product product = new(productGeneral.ProductName, _claimService.RestaurantId, productGeneral.CategoryId
            , productGeneral.Id);
        await _unitOfWorks.ProductRepository.AddAsync(product);
        await AddIngredient(request.ProductId);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }

    private async Task AddIngredient(Guid productId)
    {
        var ingredients = await _unitOfWorks.IngredientGeneralRepository.WhereAsync(x => x.ProductIngredientGenerals.Any(pig => pig.ProductGeneralId == productId));
        foreach (var item in ingredients)
        {

            if (_unitOfWorks.IngredientRepository.WhereAsync(x => x.IngredientName == item.IngredientName) is null)
            {
                await _unitOfWorks.IngredientRepository.AddAsync(new Domain.Entities.IngredientAggregator.Ingredient(item.IngredientName, item.IngredientTypeId, _claimService.RestaurantId));
            }
        }
    }
}
