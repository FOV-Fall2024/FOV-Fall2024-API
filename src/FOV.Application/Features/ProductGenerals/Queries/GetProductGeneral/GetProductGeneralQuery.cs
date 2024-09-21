using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.ProductGenerals.Queries.GetProductGeneral
{
    public sealed record GetProductGeneralCommand(string? Name, string? ProductDescription, Guid? CategoryId, PagingRequest PagingRequest) : IRequest<PagedResult<GetProductGeneralResponse>>;

    public record GetProductGeneralResponse(Guid Id, string Name, string ProductDescription, bool IsDeleted, string ProductImage, Guid CategoryId, DateTimeOffset CreatedDate, DateTimeOffset UpdateTime);

    public class GetProductGeneralQuery : IRequestHandler<GetProductGeneralCommand, PagedResult<GetProductGeneralResponse>>
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public GetProductGeneralQuery(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;
        }

        public async Task<PagedResult<GetProductGeneralResponse>> Handle(GetProductGeneralCommand request, CancellationToken cancellationToken)
        {
            // Fetch all products from the repository
            var allProducts = await _unitOfWorks.ProductGeneralRepository.GetAllAsync();

            // Filter products based on the request parameters
            var filteredProducts = allProducts.AsQueryable().CustomFilterV1(new ProductGeneral
            {
                CategoryId = request.CategoryId ?? Guid.Empty,
                ProductName = request.Name ?? string.Empty,
                ProductDescription = request.ProductDescription ?? string.Empty,
            });

            // Select and map to response DTO
            var mappedProducts = filteredProducts.Select(x => new GetProductGeneralResponse(
                x.Id,
                x.ProductName ?? string.Empty,
                x.ProductDescription ?? string.Empty,
                x.IsDeleted,
                x.ProductImageDefault,
                x.CategoryId ?? Guid.Empty,
                x.Created,
                x.LastModified)).ToList();

            // Get pagination and sorting values
            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            // Sort and paginate the results
            var sortedResults = PaginationHelper<GetProductGeneralResponse>.Sorting(sortType, mappedProducts, sortField);
            var result = PaginationHelper<GetProductGeneralResponse>.Paging(sortedResults, page, pageSize);

            return result;
        }
    }
}
