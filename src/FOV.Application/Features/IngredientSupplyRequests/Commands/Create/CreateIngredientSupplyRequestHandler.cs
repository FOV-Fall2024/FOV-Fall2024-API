using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientSupplyRequests.Commands.Create;
public sealed record CreateIngredientSupplyRequestCommand(List<Guid> Ingredients) : IRequest<Result>;

public class CreateIngredientSupplyRequestHandler(IUnitOfWorks unitOfWorks,IClaimService claimService) : IRequestHandler<CreateIngredientSupplyRequestCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    public async Task<Result> Handle(CreateIngredientSupplyRequestCommand request, CancellationToken cancellationToken)
    {
        IngredientSupplyRequest ingredientSupplyRequest = new(_claimService.UserId,_claimService.RestaurantId);
        await _unitOfWorks.IngredientSupplyRequestRepository.AddAsync(ingredientSupplyRequest);
        foreach (var ingredient in request.Ingredients)
        {
            IngredientSupplyRequestDetail IngredientSupplyRequestDetail = new(ingredient,ingredientSupplyRequest.Id);
            await _unitOfWorks.IngredientSupplyRequestDetailRepository.AddAsync(IngredientSupplyRequestDetail); 
        }
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
