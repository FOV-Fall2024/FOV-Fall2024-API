using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.RemoveIngredient;

public sealed record RemoveIngredientCommand(Guid productId, Guid IngredientId) : IRequest<Result>;

public class RemoveIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RemoveIngredientCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(RemoveIngredientCommand request, CancellationToken cancellationToken)
    {
        DishIngredientGeneral general = await _unitOfWorks.ProductIngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientGeneralId == request.IngredientId && x.DishGeneralId == request.productId) ?? throw new Exception();
        _unitOfWorks.ProductIngredientGeneralRepository.Remove(general);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
