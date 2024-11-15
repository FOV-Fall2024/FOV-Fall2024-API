using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.RemoveIngredient;

public sealed record RemoveIngredientCommand(List<Guid> IngredientId) : IRequest<Result>
{
    [JsonIgnore]
    public Guid ProductId { get; set; }
};

public class RemoveIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RemoveIngredientCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(RemoveIngredientCommand request, CancellationToken cancellationToken)
    {
        foreach (var ingreId in request.IngredientId)
        {
            DishIngredientGeneral general = await _unitOfWorks.DishIngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientGeneralId == ingreId && x.DishGeneralId == request.ProductId, x => x.IngredientGeneral) ?? throw new Exception();
            _unitOfWorks.DishIngredientGeneralRepository.Remove(general);
        }

        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
