using FOV.Application.Features.IngredientGenerals.Responses;
using FOV.Domain.Entities.IngredientGeneralAggregator; // Adjust as necessary
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Queries.GetAllIngredientGeneral
{
    public sealed record GetAllIngredientCommand(string? IngredientGeneralName, Guid? IngredientTypeId, string? ingredientMeasureType, Status? Status, PagingRequest? PagingRequest) : IRequest<PagedResult<GetAllIngredientResponse>>;



    public class GetAllIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetAllIngredientCommand, PagedResult<GetAllIngredientResponse>>
    {
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

        public async Task<PagedResult<GetAllIngredientResponse>> Handle(GetAllIngredientCommand request, CancellationToken cancellationToken)
        {
            // Fetch all ingredients from the repository
            var allIngredients = await _unitOfWorks.IngredientGeneralRepository.GetAllAsync(x => x.IngredientType, x => x.IngredientMeasure);

            // Filter ingredients based on the request parameters
            var filteredIngredients = allIngredients.AsQueryable()
                .CustomFilterV1(new IngredientGeneral
                {
                    IngredientName = request.IngredientGeneralName ?? string.Empty,
                    IngredientTypeId = request.IngredientTypeId ?? Guid.Empty,
                    Status = request.Status ?? Status.Unknown
                });
            if (request.Status.HasValue)
            {
                filteredIngredients = filteredIngredients.Where(x => x.Status == request.Status.Value);
            }
            // Select and map to response DTO
            var mappedIngredients = filteredIngredients.Select(x => new GetAllIngredientResponse(
                x.Id,
                x.IngredientName ?? string.Empty,
                x.IngredientType.IngredientName,
                x.IngredientMeasure.IngredientMeasureName,
                x.IngredientDescription ?? string.Empty,
                x.IngredientTypeId,
                x.Status,
                x.Created)).ToList();

            // Get pagination and sorting values
            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            // Sort and paginate the results
            var sortedResults = PaginationHelper<GetAllIngredientResponse>.Sorting(sortType, mappedIngredients, sortField);
            var result = PaginationHelper<GetAllIngredientResponse>.Paging(sortedResults, page, pageSize);

            return result;
        }
    }
}
