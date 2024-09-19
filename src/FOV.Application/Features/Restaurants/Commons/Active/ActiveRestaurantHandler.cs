using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Restaurants.Commons.Active;
public sealed record ActiveRestaurantCommand(Guid Id) : IRequest<Guid>;
public class ActiveRestaurantHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveRestaurantCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(ActiveRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _unitOfWorks.RestaurantRepository.GetByIdAsync(request.Id) ?? throw new Exception("Nhà hàng không tồn tại");
        restaurant.UpdateState(true);
        _unitOfWorks.RestaurantRepository.Update(restaurant);
        await _unitOfWorks.SaveChangeAsync();
        return restaurant.Id;
    }
}
