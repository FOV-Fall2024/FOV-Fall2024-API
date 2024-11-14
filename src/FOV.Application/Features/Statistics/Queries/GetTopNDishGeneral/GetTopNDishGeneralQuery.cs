using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Statistics.Queries.GetTopNDishGeneral;
public record GetTopNDishGeneralCommand(int TopM) : IRequest<List<DishGeneralsDto>>;
public record DishGeneralsDto(Guid DishGeneralId, string DishGeneralName, int TotalAmount);
public class GetTopNDishGeneralQuery(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<GetTopNDishGeneralCommand, List<DishGeneralsDto>>
{
    private readonly IUnitOfWorks _unitOfWork = unitOfWorks;
    private readonly IClaimService _claimService = claimService;

    public async Task<List<DishGeneralsDto>> Handle(GetTopNDishGeneralCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        if (userRole == Role.Manager)
        {
            var restaurantId = _claimService.RestaurantId;
            var dishes = await _unitOfWork.OrderDetailRepository.GetTopNDishOfAllOrderDetail(request.TopM, restaurantId);
            return dishes.Select(d => new DishGeneralsDto(d.DishId, d.DishName, d.TotalQuantity)).ToList();
        } else
        {
            var dishGeneral = await _unitOfWork.OrderDetailRepository.GetTopNProductGeneralOfAllOrderDetail(request.TopM);
            return dishGeneral.Select(dg => new DishGeneralsDto(dg.DishId, dg.DishName, dg.TotalQuantity)).ToList();
        }
    }
}
