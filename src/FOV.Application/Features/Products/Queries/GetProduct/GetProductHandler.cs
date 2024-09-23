using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Products.Queries.GetProduct;
public sealed record GetProductCommand(string? ProductName, string? ProductDescription, string? RestaurantId) : IRequest<List<GetProductResponse>>;

public sealed record GetProductResponse(Guid ProductId, string ProductName, string ProductDescription);
internal class GetProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetProductCommand, List<GetProductResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetProductResponse>> Handle(GetProductCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWorks.ProductRepository.GetAllAsync();
        var filteredProducts = products.Where(x =>
        (string.IsNullOrEmpty(request.ProductName) || x.ProductName.Contains(request.ProductName, StringComparison.OrdinalIgnoreCase)) &&
         (string.IsNullOrEmpty(request.ProductDescription) || x.ProductDescription.Contains(request.ProductDescription, StringComparison.OrdinalIgnoreCase)) &&
         (Guid.TryParse(request.RestaurantId, out var restaurantGuid) == false || x.RestaurantId == restaurantGuid)
        ).Select(x => new GetProductResponse(
            x.Id,
            x.ProductName,
            x.ProductDescription)).ToList();

        return filteredProducts;
    }
}
