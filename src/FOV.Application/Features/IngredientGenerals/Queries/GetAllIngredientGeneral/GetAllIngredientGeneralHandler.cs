﻿using FOV.Application.Features.IngredientGenerals.Responses;
using FOV.Domain.Entities.IngredientGeneralAggregator; // Adjust as necessary
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Queries.GetAllIngredientGeneral
{
    public sealed record GetAllIngredientCommand(string? IngredientGeneralName, Guid? IngredientTypeId, PagingRequest? PagingRequest) : IRequest<PagedResult<GetAllIngredientResponse>>;

 

    public class GetAllIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetAllIngredientCommand, PagedResult<GetAllIngredientResponse>>
    {
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

        public async Task<PagedResult<GetAllIngredientResponse>> Handle(GetAllIngredientCommand request, CancellationToken cancellationToken)
        {
            // Fetch all ingredients from the repository
            var allIngredients = await _unitOfWorks.IngredientGeneralRepository.GetAllAsync(x => x.IngredientType);

            // Filter ingredients based on the request parameters
            var filteredIngredients = allIngredients.AsQueryable()
                .CustomFilterV1(new IngredientGeneral
                {
                    IngredientName = request.IngredientName ?? string.Empty,
                    IngredientTypeId = request.IngredientTypeId ?? Guid.Empty,
                });

            // Select and map to response DTO
            var mappedIngredients = filteredIngredients.Select(x => new GetAllIngredientResponse(
                x.Id,
                x.IngredientName ?? string.Empty,
                x.IngredientType.IngredientName,
                x.IngredientDescription ?? string.Empty,
                x.Status)).ToList();

            // Get pagination and sorting values
            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            // Sort and paginate the results
            var sortedResults = PaginationHelper<GetAllIngredientResponse>.Sorting(sortType, mappedIngredients, sortField);
            var result = PaginationHelper<GetAllIngredientResponse>.Paging(sortedResults, page, pageSize);

            return result;
        }
    }
}
