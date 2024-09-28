using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;


namespace FOV.Application.Features.DishGenerals.Commands.UpdateIngredientQuantity;

public sealed record UpdateIngredientQuantityCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid ProductId { get; set; }

    [JsonIgnore]
    public Guid IngredientId { get; set; }

    public decimal Quantity { get; set; }
}
internal class UpdateIngredientQuantityHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateIngredientQuantityCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateIngredientQuantityCommand request, CancellationToken cancellationToken)
    {
        DishIngredientGeneral general = await _unitOfWorks.DishIngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientGeneralId == request.IngredientId && x.DishGeneralId == request.ProductId) ?? throw new Exception();

        general.Update(request.ProductId, request.IngredientId, request.Quantity);
        _unitOfWorks.DishIngredientGeneralRepository.Update(general);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();



    }
}
