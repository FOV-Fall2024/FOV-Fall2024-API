using System.Linq;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Features.DishGenerals.Responses;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Queries.GetProductGeneral
{
    public sealed record GetProductGeneralCommand(string? DishGeneralName, string? DishGeneralDescription, Guid? CategoryId, Status? Status, PagingRequest? PagingRequest) : IRequest<PagedResult<GetProductGeneralResponse>>;
    public class GetProductGeneralQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetProductGeneralCommand, PagedResult<GetProductGeneralResponse>>
    {
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
        private readonly IClaimService _claimService = claimService;
        public async Task<PagedResult<GetProductGeneralResponse>> Handle(GetProductGeneralCommand request, CancellationToken cancellationToken)
        {
            var restaurantId = _claimService.RestaurantId;
            var allProducts = await _unitOfWorks.DishGeneralRepository.GetAllAsync(x => x.Category, x => x.DishGeneralImages);

            if (_claimService.UserRole == Role.Manager)
            {
                allProducts = allProducts.Where(x => x.Status == Status.Active).ToList();
                var clonedDished = await _unitOfWorks.DishRepository.WhereAsync(x => x.RestaurantId == restaurantId);
                var dishGeneralIdsInDish = clonedDished.Select(x => x.DishGeneralId).Distinct().ToList();
                allProducts = allProducts.Where(x => !dishGeneralIdsInDish.Contains(x.Id)).ToList();
            }

            var filteredProducts = allProducts.AsQueryable().CustomFilterV1(new DishGeneral
            {
                CategoryId = request.CategoryId ?? Guid.Empty,
                DishName = request.DishGeneralName ?? string.Empty,
                DishDescription = request.DishGeneralDescription ?? string.Empty,
            });
            if (request.Status.HasValue)
            {
                filteredProducts = filteredProducts.Where(x => x.Status == request.Status.Value);
            }

            var mappedProducts = filteredProducts.Select(x => new GetProductGeneralResponse(
                x.Id,
                x.DishName ?? string.Empty,
                x.Price,
                x.DishDescription ?? string.Empty,
                x.Status,
                x.IsRefund,
                (Guid)x.CategoryId,
                x.Category.CategoryName,
                x.Created,
                x.LastModified ?? DateTime.Now,
                x.PercentagePriceDifference,
                x.DishGeneralImages.OrderBy(img => img.Order).Select(img => new GetAdditionalImage(img.Id, img.Url)).ToList())).ToList();

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
                
            var sortedResults = PaginationHelper<GetProductGeneralResponse>.Sorting(sortType, mappedProducts, sortField);
            var result = PaginationHelper<GetProductGeneralResponse>.Paging(sortedResults, page, pageSize);

            return result;
        }
    }
}
