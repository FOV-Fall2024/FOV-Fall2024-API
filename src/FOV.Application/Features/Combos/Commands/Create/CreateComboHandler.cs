using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.Create;
public record CreateComboCommand(List<ProductInCombo> ProductInCombos, string ComboName, bool IsActive, string ComboDescription, decimal Price, string Thumbnail) : IRequest<Guid>;
public record ProductInCombo(Guid ProductId, int Quantity);
public class CreateComboHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<CreateComboCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;

    public async Task<Guid> Handle(CreateComboCommand request, CancellationToken cancellationToken)
    {
        Guid restaurantId = _claimService.RestaurantId;
        Combo combo = new(request.ComboName, request.Price, _claimService.RestaurantId, request.Thumbnail, request.ComboDescription, request.IsActive);
        await _unitOfWorks.ComboRepository.AddAsync(combo);
        decimal totalPrice = 0;
        foreach (var item in request.ProductInCombos)
        {
            Dish product = await _unitOfWorks.DishRepository.FirstOrDefaultAsync(x => x.RestaurantId == restaurantId && x.Id == item.ProductId) ?? throw new Exception();
            totalPrice += (decimal)product.Price;
            await _unitOfWorks.DishComboRepository.AddAsync(new(item.ProductId, combo.Id, item.Quantity));
        }

        combo.PercentReduce = totalPrice / request.Price;
        await _unitOfWorks.SaveChangeAsync();
        return combo.Id;
    }
}
