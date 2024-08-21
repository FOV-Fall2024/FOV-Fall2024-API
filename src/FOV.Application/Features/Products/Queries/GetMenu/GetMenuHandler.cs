using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Products.Queries.GetMenu;

public sealed record GetMenuCommand(string ProductName, string ProductDescription, string RestaurantId) : IRequest<List<GetMenuResponse>>;
public sealed record ProductCheckingCommand(Guid ProductId, int Quantity);
public sealed record ProductCommand(Guid ProductId,string ProductName,string ProductDescription);
public sealed record ComboCommand(Guid ComboId,string ComboName,string ComboDescription);
public sealed record GetMenuResponse(Guid ProductId, string ProductName, string ProductDescription);
public class GetMenuHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetMenuCommand, List<GetMenuResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetMenuResponse>> Handle(GetMenuCommand request, CancellationToken cancellationToken)
    {
        var products = await _unitOfWorks.ProductRepository.GetAllAsync();
        var filteredProducts = products.Where(x =>
        (string.IsNullOrEmpty(request.ProductName) || x.ProductName.Contains(request.ProductName, StringComparison.OrdinalIgnoreCase)) &&
         (string.IsNullOrEmpty(request.ProductDescription) || x.ProductDescription.Contains(request.ProductDescription, StringComparison.OrdinalIgnoreCase)) &&
         (Guid.TryParse(request.RestaurantId, out var restaurantGuid) == false || x.RestaurantId == restaurantGuid) &&
         x.IsDeleted == false
        ).Select(x => new GetMenuResponse(
            x.Id,
            x.ProductName,
            x.ProductDescription)).ToList();

        return filteredProducts;
    }
}
