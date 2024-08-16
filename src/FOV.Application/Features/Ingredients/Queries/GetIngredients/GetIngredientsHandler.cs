using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Ingredients.Queries.GetIngredients;
public sealed record GetIngredienetsCommand(string IngredientName) : IRequest<List<GetIngredientsResponse>>;

public sealed record GetIngredientsResponse(Guid IngredientId, string IngredientName, decimal Amount);
public class GetIngredientsHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetIngredienetsCommand, List<GetIngredientsResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetIngredientsResponse>> Handle(GetIngredienetsCommand request, CancellationToken cancellationToken)
    {
        var ingredients = await _unitOfWorks.IngredientRepository.GetAllAsync();
        var filteredIngredients = ingredients.Where(x =>
        (string.IsNullOrEmpty(request.IngredientName) || x.IngredientName.Contains(request.IngredientName, StringComparison.OrdinalIgnoreCase))).Select(
            x => new GetIngredientsResponse(
                x.Id, x.IngredientName, x.ExpriedQuantity)).ToList();
        return filteredIngredients;
    }
}
