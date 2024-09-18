using FluentResults;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientUnits.Commands.CreateNewIngredientUnit;

public sealed record CreateNewIngredientUnitCommand(string UnitName, decimal ConversionFactor, Guid IngredientUnitParentId, Guid IngredientId) : IRequest<Result>;


public class CreateNewIngredientUnitHandler(IUnitOfWorks unitOfWorks, IClaimService claimService) : IRequestHandler<CreateNewIngredientUnitCommand, Result>
{
    private readonly IClaimService _claimService = claimService;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(CreateNewIngredientUnitCommand request, CancellationToken cancellationToken)
    {
        IngredientUnit ingredientUnit = new(request.UnitName, request.IngredientId, request.IngredientUnitParentId, request.ConversionFactor);
        await _unitOfWorks.IngredientUnitRepository.AddAsync(ingredientUnit);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }
}
