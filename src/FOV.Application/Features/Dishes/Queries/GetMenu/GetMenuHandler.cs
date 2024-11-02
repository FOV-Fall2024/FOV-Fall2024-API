using System.ComponentModel.DataAnnotations;
using FOV.Application.Features.Dishes.Responses;
using FOV.Application.Features.DishGenerals.Responses;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using System.Text.Json.Serialization;
using FOV.Application.Features.Dishes.Responses;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Notifications.Web.SignalR.Menu.Setup;

namespace FOV.Application.Features.Dishes.Queries.GetMenu;

public sealed record GetMenuCommand(string? DishName, string? CategoryName, Status? Status, bool? IsRefundDish, PagingRequest? PagingRequest) : IRequest<PagedResult<GetMenuResponse>>
{
    [Required]
    public Guid RestaurantId { get; set; }
}

public class GetMenuHandler : IRequestHandler<GetMenuCommand, PagedResult<GetMenuResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IHubContext<MenuHub> _hubContext;
    private readonly IClaimService _claimService;

    public GetMenuHandler(IUnitOfWorks unitOfWorks, IHubContext<MenuHub> hubContext, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _hubContext = hubContext;
        _claimService = claimService;
    }

    public async Task<PagedResult<GetMenuResponse>> Handle(GetMenuCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;

        var dishes = await _unitOfWorks.DishRepository.WhereAsync(
            x => x.RestaurantId == request.RestaurantId,
            d => d.DishGeneral,
            i => i.DishGeneral.DishGeneralImages,
            c => c.Category,
            c => c.RefundDishInventory
        );

        if (userRole != Role.Manager)
        {
            dishes = dishes.Where(x => x.Status == Status.Active).ToList();
        }
        
        //var combos = await _unitOfWorks.ComboRepository.WhereAsync(x )

        if (!string.IsNullOrWhiteSpace(request.DishName))
        {
            dishes = dishes.Where(x => x.DishGeneral.DishName.Contains(request.DishName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        if (!string.IsNullOrWhiteSpace(request.CategoryName))
        {
            dishes = dishes.Where(x => x.Category.CategoryName.Contains(request.CategoryName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        if (request.Status.HasValue)
        {
            dishes = dishes.Where(x => x.Status == request.Status.Value).ToList();
        }
        if (request.IsRefundDish.HasValue)
        {
            dishes = dishes.Where(x => x.DishGeneral.IsRefund == request.IsRefundDish.Value).ToList();
        }

        var dishMappers = dishes.Select(dish => new GetMenuResponse(
            dish.Id,
            dish.DishGeneral.DishName,
            dish.RefundDishInventory?.QuantityAvailable ?? 0,
            dish.Price.ToString(),
            dish.DishGeneral.PercentagePriceDifference,
            dish.DishGeneral.DishDescription,
            dish.Created,
            dish.DishGeneral.DishGeneralImages.OrderBy(img => img.Order).Select(img => new GetAdditionalImage(img.Id, img.Url)).ToList(),
            dish.Category.CategoryName,
            dish.GetType().Name,
            dish.Status,
            dish.DishGeneral.IsRefund
        )).ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<GetMenuResponse>.Sorting(sortType, dishMappers, sortField);
        var pagedResult = PaginationHelper<GetMenuResponse>.Paging(sortedResults, page, pageSize);

        await _hubContext.Clients.All.SendAsync("UpdateMenu", pagedResult);

        return pagedResult;
    }
}

