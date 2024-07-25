using FluentResults;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.ProductGenerals.Commands.UpdateIngredientQuantity;

public sealed record UpdateIngredientQuantityCommand(Guid productId, Guid IngredientId, decimal quantity) : IRequest<Result>;
internal class UpdateIngredientQuantityHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateIngredientQuantityCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateIngredientQuantityCommand request, CancellationToken cancellationToken)
    {
        ProductIngredientGeneral general = await _unitOfWorks.ProductIngredientGeneralRepository.FirstOrDefaultAsync(x => x.IngredientGeneralId == request.IngredientId && x.ProductGeneralId == request.productId) ?? throw new Exception();

        general.Update(request.productId, request.IngredientId, request.quantity);
        _unitOfWorks.ProductIngredientGeneralRepository.Update(general);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();



    }
}
