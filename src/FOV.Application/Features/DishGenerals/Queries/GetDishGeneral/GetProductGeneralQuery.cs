using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.DishGenerals.Responses;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Queries.GetProductGeneral
{
    public sealed record GetProductGeneralCommand(string? DishGeneralName, string? DishGeneralDescription, Guid? CategoryId,bool? IsDeleted, PagingRequest? PagingRequest) : IRequest<PagedResult<GetProductGeneralResponse>>;



    public class GetProductGeneralQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetProductGeneralCommand, PagedResult<GetProductGeneralResponse>>
    {
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
        private readonly IClaimService _claimService = claimService;



        public async Task<PagedResult<GetProductGeneralResponse>> Handle(GetProductGeneralCommand request, CancellationToken cancellationToken)
        {
            var allProducts = await _unitOfWorks.DishGeneralRepository.GetAllAsync();

            if (_claimService.UserRole == Role.Manager) allProducts = allProducts.Where(x => !x.IsDeleted).ToList();

            // Filter products based on the request parameters
            var filteredProducts = allProducts.AsQueryable().CustomFilterV1(new DishGeneral
            {
                CategoryId = request.CategoryId ?? Guid.Empty,
                DishName = request.DishGeneralName ?? string.Empty,
                DishDescription = request.DishGeneralDescription ?? string.Empty,
            });
            if (request.IsDeleted.HasValue)
            {
                filteredProducts = filteredProducts.Where(p => p.IsDeleted == request.IsDeleted.Value);
            }

            // Select and map to response DTO
            var mappedProducts = filteredProducts.Select(x => new GetProductGeneralResponse(
                x.Id,
                x.DishName ?? string.Empty,
                x.Price,
                x.DishDescription ?? string.Empty,
                x.IsDeleted,
                x.DishImageDefault,
                x.CategoryId ?? Guid.Empty,
                x.Created,
                x.LastModified ?? DateTime.Now,
                x.PercentagePriceDifference)).ToList();

            // Get pagination and sorting values
            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            // Sort and paginate the results
            var sortedResults = PaginationHelper<GetProductGeneralResponse>.Sorting(sortType, mappedProducts, sortField);
            var result = PaginationHelper<GetProductGeneralResponse>.Paging(sortedResults, page, pageSize);

            return result;
        }
    }
}
