using FOV.Domain.Entities.IngredientAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Commons.Create;

public sealed record CreateRestaurantCommand : IRequest<Guid>
{
    public required string RestaurantName { get; set; }

    public required string Address { get; set; }

    public required string Phone { get; set; }

    public ICollection<Guid> Products { get; set; } = [];
}



internal class CreateRestaurantHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateRestaurantCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {

        Restaurant restaurant = new(request.RestaurantName, request.Address, request.Phone, GeneratedCode());
        await _unitOfWorks.RestaurantRepository.AddAsync(restaurant);
        await AddNewProdut(request.Products, restaurant.Id);
        await _unitOfWorks.SaveChangeAsync();
        return restaurant.Id;
    }


    private string GeneratedCode()
    {
        Restaurant? restaurant = _unitOfWorks.RestaurantRepository.GetAllAsync().Result.LastOrDefault();

        if (restaurant is null)
        {
            return "RE_001";
        }
        string currentIdentifier = restaurant.RestataurantCode; // Assuming restaurant has a property 'Identifier' like 'RE_001'
        int currentNumber = int.Parse(currentIdentifier.Substring(3));
        int newNumber = currentNumber + 1;
        return $"RE_{newNumber:D3}";

    }

    private async Task AddNewProdut(ICollection<Guid> products, Guid restaurantId)
    {
        foreach (var product in products)
        {
            ProductGeneral productGeneral = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(product) ?? throw new Exception();
            Product productAdding = new(productGeneral.ProductName, restaurantId);
            await _unitOfWorks.ProductRepository.AddAsync(productAdding);
            _ = Task.Run(() => ProductIngredientAdd(productGeneral.Ingredients.Select(x => x.IngredientGeneral.IngredientName).ToList(), restaurantId, productAdding.Id).ConfigureAwait(false));
        }
    }

    private async Task ProductIngredientAdd(ICollection<string> ingredientNames, Guid restaurantId, Guid productId)
    {
        foreach (var item in ingredientNames)
        {
            Ingredient? ingredient = _unitOfWorks.IngredientRepository.FirstOrDefaultAsync(x => x.IngredientName == item && x.RestaurantId == restaurantId).Result;
            if (ingredient == null)
            {
                IngredientGeneral ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientName == item) ?? throw new Exception();
                await _unitOfWorks.IngredientRepository.AddAsync(new Ingredient(ingredientGeneral.IngredientName, ingredientGeneral.IngredientTypeId, restaurantId));
                await _unitOfWorks.ProductIngredientRepository.AddAsync(new ProductIngredient(productId, ingredientGeneral.Id));
            }
        }


    }

}



