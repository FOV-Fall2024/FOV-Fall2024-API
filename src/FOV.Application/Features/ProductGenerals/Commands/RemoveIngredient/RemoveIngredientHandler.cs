using FluentResults;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.ProductGenerals.Commands.RemoveIngredient;

public sealed record RemoveIngredientCommand(Guid productId, Guid IngredientId) : IRequest<Result>;

public class RemoveIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RemoveIngredientCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(RemoveIngredientCommand request, CancellationToken cancellationToken)
    {
        ProductIngredientGeneral general = await _unitOfWorks.ProductIngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientGeneralId == request.IngredientId && x.ProductGeneralId == request.productId) ?? throw new Exception();
        _unitOfWorks.ProductIngredientGeneralRepository.Remove(general);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
