using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientUnits.Commands.Update;

public sealed record UpdateIngredientUnitCommand(string UnitName, decimal ConversionFactor) : IRequest<Result>
{
    [JsonInclude]
    public Guid IngredientUnitId { get; set; }
}

public class UpdateIngredientUnitHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateIngredientUnitCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateIngredientUnitCommand request, CancellationToken cancellationToken)
    {
        IngredientUnit ingredientUnit = await _unitOfWorks.IngredientUnitRepository.GetByIdAsync(request.IngredientUnitId) ?? throw new Exception();
        ingredientUnit.Update(request.UnitName, request.ConversionFactor);
        _unitOfWorks.IngredientUnitRepository.Update(ingredientUnit);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }
}
