using FOV.Domain.DTOs;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;

namespace FOV.Infrastructure.Repository.Repositories;

public class ProductGeneralRepository : GenericRepository<ProductGeneral>, IProductGeneralRepository
{
    private readonly FOVContext _context;
    public ProductGeneralRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public List<ProductCheckDTO> GetProduct(Guid restaurantId) => GetProducts(_context, restaurantId).ToList();

    public List<ComboCheckDTO> GetCombo(Guid restaurantId) => GetCombos(_context, restaurantId).ToList();

    public static IEnumerable<ComboCheckDTO> GetCombos(FOVContext context, Guid RestaurantId)
    {
        // Fetch and precompute product availability
        var productAvailability = context.Products
            .Where(p => p.RestaurantId == RestaurantId)
            .Select(p => new
            {
                p.Id,
                MinCreatable = context.ProductIngredients
                    .Select(pi => pi.Ingredient.IngredientAmount / pi.Quantity)
                    .DefaultIfEmpty(0)
                    .Min()
            })
            .ToDictionary(p => p.Id, p => p.MinCreatable);

        // Fetch combo data and calculate availability
        var comboData = context.Combos
            .Where(c => c.RestaurantId == RestaurantId)
            .Select(combo => new
            {
                combo.Id,
                Products = context.ProductCombos
                    .Where(cp => cp.ComboId == combo.Id)
                    .Select(cp => new
                    {
                        cp.ProductId,
                    }).ToList()
            })
            .AsParallel() // Parallelize the computation
            .Select(combo =>
            {
                int minCombos = (int)combo.Products
                    .Select(product => productAvailability.TryGetValue(product.ProductId, out decimal available)
                        ? available / 1
                        : 0)
                    .DefaultIfEmpty(0)
                    .Min();

                return new ComboCheckDTO(combo.Id, minCombos);
            })
            .ToList();

        return comboData;
    }

    public static IEnumerable<ProductCheckDTO> GetProducts(FOVContext context, Guid RestaurantId)
    {
        // Fetch data from the database and materialize it into memory
        var productData = context.Products
            .Where(x => x.RestaurantId == RestaurantId)
            .Select(product => new
            {
                product.Id,
                Ingredients = context.ProductIngredients
                    .Where(pi => pi.ProductId == product.Id)
                    .Select(pi => new IngredientCheckDTO(
                        pi.IngredientId,
                        pi.Quantity,
                        pi.Ingredient.IngredientAmount
                    )).ToList()
            })
            .ToList();

        // Process data in memory
        var result = productData
            .Select(product =>
            {
                // Calculate the minimum creatable products based on available ingredients
                int minCreatable = (int)product.Ingredients
                    .Min(i => i.TotalQuantity / i.QuantityNeeded); // Integer division

                return new ProductCheckDTO(product.Id, minCreatable);
            })
            .ToList();

        return result;
    }
}
