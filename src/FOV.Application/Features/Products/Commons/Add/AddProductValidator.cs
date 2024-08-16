using FluentValidation;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Products.Commons.Add;

public class AddProductValidator : AbstractValidator<AddProductCommand>
{
    public AddProductValidator(ProductValidator validations)
    {
        RuleFor(x => x.ProductId).NotEmpty().SetValidator(validations);
    }
}

public sealed class ProductValidator : AbstractValidator<Guid>
{
    private readonly IUnitOfWorks _unitOfWorks;
    private readonly IClaimService _claimService;
    public ProductValidator(IUnitOfWorks unitOfWorks, IClaimService claimService)
    {
        _unitOfWorks = unitOfWorks;
        _claimService = claimService;
        RuleFor(name => name)
             .MustAsync(CheckDuplicateProductId)
             .WithMessage("This Product have already in system");
    }

    private async Task<bool> CheckDuplicateProductId(Guid productId, CancellationToken cancellationToken)
    {
        Product? product = await _unitOfWorks.ProductRepository.FirstOrDefaultAsync(x => x.RestaurantId == _claimService.RestaurantId && x.ProductGeneralId == productId);
        return product == null;
    }
}
