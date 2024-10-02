using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.Create;
public sealed record CreateComboCommand(List<Guid> ProductInCombos, string ComboName, bool isActive, int Quantity, decimal Price, DateTime ExpiredDate) : IRequest<Guid>;
public sealed record ProductInCombo(Guid ProductId);
public class CreateComboHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<CreateComboCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;

    public async Task<Guid> Handle(CreateComboCommand request, CancellationToken cancellationToken)
    {
        Guid restaurantId = _claimService.RestaurantId;
        Combo combo = new(request.ComboName, request.Quantity, request.Price, request.ExpiredDate, _claimService.RestaurantId,request.isActive);
        await _unitOfWorks.ComboRepository.AddAsync(combo);
        decimal totalPrice = 0;
        foreach (var item in request.ProductInCombos)
        {
            Dish product = await _unitOfWorks.DishRepository.FirstOrDefaultAsync(x => x.RestaurantId == restaurantId && x.Id == item) ?? throw new Exception();
            totalPrice += (decimal)product.Price;
            await _unitOfWorks.DishComboRepository.AddAsync(new(item, combo.Id));
        }

        combo.PercentReduce = totalPrice/request.Price;
        await _unitOfWorks.SaveChangeAsync();
        return combo.Id;
    }
}
