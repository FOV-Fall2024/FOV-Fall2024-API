using System.ComponentModel.DataAnnotations;
using FOV.Application.Features.Dishes.Responses;
using FOV.Application.Features.DishGenerals.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.Menu.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace FOV.Application.Features.Dishes.Queries.GetMenu;

public sealed record GetMenuCommand(string? DishName, string? CategoryName, PagingRequest? PagingRequest) : IRequest<PagedResult<GetMenuResponse>>
{
    [Required]
    public Guid RestaurantId { get; set; }
}

public class GetMenuHandler : IRequestHandler<GetMenuCommand, PagedResult<GetMenuResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IHubContext<MenuHub> _hubContext;

    public GetMenuHandler(IUnitOfWorks unitOfWorks, IHubContext<MenuHub> hubContext)
    {
        _unitOfWorks = unitOfWorks;
        _hubContext = hubContext;
    }

    public async Task<PagedResult<GetMenuResponse>> Handle(GetMenuCommand request, CancellationToken cancellationToken)
    {
        var dishes = await _unitOfWorks.DishRepository.WhereAsync(
            x => x.RestaurantId == request.RestaurantId,
            d => d.DishGeneral,
            i => i.DishGeneral.DishGeneralImages,
            c => c.Category
        );

        var filterEntity = new Dish
        {
            DishGeneral = new DishGeneral
            {
                DishName = string.IsNullOrWhiteSpace(request.DishName) ? string.Empty : request.DishName,
                Category = new Category
                {
                    CategoryName = string.IsNullOrWhiteSpace(request.CategoryName) ? string.Empty : request.CategoryName
                }
            }
        };

        var filteredDishes = dishes.AsQueryable().CustomFilterV1(filterEntity);

        var dishMappers = filteredDishes.Select(dish => new GetMenuResponse(
            dish.Id,
            dish.DishGeneral.DishName,
            dish.Price.ToString(),
            dish.DishGeneral.DishDescription,
            dish.Created,
            dish.DishGeneral.DishGeneralImages.OrderBy(img => img.Order).Select(img => new GetAdditionalImage(img.Id, img.Url)).ToList(),
            dish.Category.CategoryName,
            dish.GetType().Name
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<GetMenuResponse>.Sorting(sortType, dishMappers, sortField);
        var pagedResult = PaginationHelper<GetMenuResponse>.Paging(sortedResults, page, pageSize);

        await _hubContext.Clients.All.SendAsync("UpdateMenu", pagedResult);

        return pagedResult;
    }
}

