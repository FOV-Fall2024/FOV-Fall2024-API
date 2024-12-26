using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Domain.DTOs;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTopNCombo;
public record GetTopNComboCommand(int TopN, Guid? RestaurantId = null) : IRequest<List<ComboQuantityDtos>>;

public class GetTopNComboQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetTopNComboCommand, List<ComboQuantityDtos>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;

    public async Task<List<ComboQuantityDtos>> Handle(GetTopNComboCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        List<Domain.Entities.OrderAggregator.OrderDetail> orderDetails = new();

        if (userRole == Role.Manager)
        {
            var restaurantId = _claimService.RestaurantId;
            orderDetails = await _unitOfWorks.OrderDetailRepository.WhereAsync(
                x => x.Order.Table.RestaurantId == restaurantId,
                x => x.Order.Table.Restaurant);
        }
        else if (userRole == Role.Administrator)
        {
            if (request.RestaurantId.HasValue)
            {
                orderDetails = await _unitOfWorks.OrderDetailRepository.WhereAsync(
                    x => x.Order.Table.RestaurantId == request.RestaurantId,
                    x => x.Order.Table.Restaurant);
            }
            else
            {
                orderDetails = await _unitOfWorks.OrderDetailRepository.GetAllAsync();
            }
        }
        else
        {
            throw new AppException("Vai trò không hợp lệ.");
        }

        if (orderDetails == null || !orderDetails.Any())
        {
            return new List<ComboQuantityDtos>();
        }

        var comboInOrderDetails = orderDetails.Select(x => x.Combo).ToList();
        var comboQuantity = comboInOrderDetails.GroupBy(x => x.Id)
            .Select(x => new ComboQuantityDtos
            {
                ComboId = x.Key,
                ComboName = x.First().ComboName,
                TotalQuantity = x.Count()
            })
            .OrderByDescending(x => x.TotalQuantity)
            .Take(request.TopN)
            .ToList();

        return comboQuantity;
    }
}

