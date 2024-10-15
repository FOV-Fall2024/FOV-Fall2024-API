using FOV.Application.Features.Dishes.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.Menu.Setup;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace FOV.Application.Features.Dishes.Queries.GetMenu;

public sealed record GetMenuCommand(Guid RestaurantId, PagingRequest? PagingRequest) : IRequest<PagedResult<GetMenuResponse>>;

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
        var dishes = await _unitOfWorks.DishRepository.WhereAsync(x => x.RestaurantId == request.RestaurantId, d => d.DishGeneral, i => i.DishGeneral.DishGeneralImages);
        var dishMappers = dishes.Select(dish => new GetMenuResponse(
            dish.Id,
            dish.DishGeneral.DishName,
            dish.DishGeneral.DishDescription,
            dish.Created
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<GetMenuResponse>.Sorting(sortType, dishMappers, sortField);
        var pagedResult = PaginationHelper<GetMenuResponse>.Paging(sortedResults, page, pageSize);

        await _hubContext.Clients.All.SendAsync("UpdateMenu", pagedResult);
        return pagedResult;
    }
}
