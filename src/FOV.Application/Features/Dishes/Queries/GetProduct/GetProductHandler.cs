using FOV.Application.Features.Dishes.Responses;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Queries.GetProduct;
public sealed record GetProductCommand(string? ProductName, string? ProductDescription, string? RestaurantId) : IRequest<List<GetProductResponse>>;


internal class GetProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetProductCommand, List<GetProductResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetProductResponse>> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWorks.DishRepository.GetAllAsync();
        var filteredProducts = products.Where(x =>
        (string.IsNullOrEmpty(request.ProductName) || x.DishName.Contains(request.ProductName, StringComparison.OrdinalIgnoreCase)) &&
         (string.IsNullOrEmpty(request.ProductDescription) || x.DishDescription.Contains(request.ProductDescription, StringComparison.OrdinalIgnoreCase)) &&
         (Guid.TryParse(request.RestaurantId, out var restaurantGuid) == false || x.RestaurantId == restaurantGuid)
        ).Select(x => new GetProductResponse(
            x.Id,
            x.RestaurantId,
            x.DishName,
            x.DishDescription)).ToList();

        return filteredProducts;
    }
}
