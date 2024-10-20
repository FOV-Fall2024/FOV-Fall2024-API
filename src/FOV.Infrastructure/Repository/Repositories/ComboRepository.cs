using FOV.Domain.DTOs;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.Data;
using FOV.Infrastructure.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FOV.Infrastructure.Repository.Repositories;
public class ComboRepository : GenericRepository<Combo>, IComboRepository
{
    private readonly FOVContext _context;
    public ComboRepository(FOVContext context) : base(context)
    {
        _context = context;
    }

    public async Task<GetComboDetailResponse> GetComboDetail(Guid comboId)
    {
        var result = await _context.Combos
        .Where(c => c.Id == comboId)
        .Select(c => new GetComboDetailResponse(
            c.Id,
            c.ComboName,
            c.Price,
            c.DishCombos.Select(d => new GetDishComboResponse(
                d.Id,
                d.Status,
                d.Dish.DishGeneral.DishName,
                d.Dish.DishGeneral.DishDescription,
                d.Dish.DishIngredients.Select(i => new GetIngredientInDishResponse(
                    i.Id,
                    i.Ingredient.IngredientName
                )).ToList()
            )).ToList()
        )).FirstOrDefaultAsync();

        return result;
    }
}
