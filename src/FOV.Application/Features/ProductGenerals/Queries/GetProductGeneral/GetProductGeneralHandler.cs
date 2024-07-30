using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Domain.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.ProductGenerals.Queries.GetProductGeneral;

public sealed record GetProductGeneralCommand(string? Name, bool? IsDeleted, string? ProductDescription, Guid? CateogryId) : IRequest<List<GetProductGeneralResponse>>;

public record GetProductGeneralResponse(Guid Id, string Name, string ProductDescription, bool IsDeleted, DateTimeOffset CreatedDate, DateTimeOffset UpdateTime);

public class GetProductGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetProductGeneralCommand, List<GetProductGeneralResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<List<GetProductGeneralResponse>> Handle(GetProductGeneralCommand request, CancellationToken cancellationToken)
    {
        // Fetch all products from the repository
        var allProducts = await _unitOfWorks.ProductGeneralRepository.GetAllAsync();

        // Filter products based on the request parameters
        var filteredProducts = allProducts.AsQueryable().CustomFilterV1(new ProductGeneral
        {
            CategoryId = request.CateogryId ?? Guid.Empty,
            ProductName = request.Name ?? string.Empty,
            ProductDescription = request.ProductDescription ?? string.Empty
        });

        // Select and return the response
        return [.. filteredProducts
            .Select(x => new GetProductGeneralResponse(
                x.Id,
                x.ProductName,
                x.ProductDescription,
                x.IsDeleted,
                x.Created,
                x.LastModified))];

    }
}
