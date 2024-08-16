using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.Create;
public sealed record CreateComboCommand(List<ProductInCombo> ProductInCombos, string ComboName, string Status, int Quantity, decimal Price, DateTime ExpiredDate) : IRequest<Guid>;
public sealed record ProductInCombo(Guid ProductId);
public class CreateComboHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<CreateComboCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;

    public async Task<Guid> Handle(CreateComboCommand request, CancellationToken cancellationToken)
    {
        Combo combo = new(request.ComboName, request.Quantity, request.Price, request.ExpiredDate, _claimService.RestaurantId);
        await _unitOfWorks.ComboRepository.AddAsync(combo);
        foreach (var item in request.ProductInCombos)
        {
            await _unitOfWorks.ProductComboRepository.AddAsync(new(item.ProductId, combo.Id));
        }

        await _unitOfWorks.SaveChangeAsync();
        return combo.Id;
    }
}
