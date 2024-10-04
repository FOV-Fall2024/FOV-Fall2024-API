using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;


namespace FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;

public sealed record UpdateIngredientQuantityCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid DishGeneralId { get; set; }

    [JsonIgnore]
    public Guid IngredientGeneralId { get; set; }

    public decimal Quantity { get; set; }
}
internal class UpdateIngredientQuantityHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateIngredientQuantityCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateIngredientQuantityCommand request, CancellationToken cancellationToken)
    {
        DishIngredientGeneral general = await _unitOfWorks.DishIngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientGeneralId == request.IngredientGeneralId && x.DishGeneralId == request.DishGeneralId) ?? throw new Exception();

        general.Update(request.DishGeneralId, request.IngredientGeneralId, request.Quantity);
        _unitOfWorks.DishIngredientGeneralRepository.Update(general);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();



    }
}
