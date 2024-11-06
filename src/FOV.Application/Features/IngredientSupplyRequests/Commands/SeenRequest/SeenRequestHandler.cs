using FluentResults;
using FOV.Domain.Entities.IngredientSupplyRequestAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientSupplyRequests.Commands.SeenRequest;
public sealed record SendRequestCommand(Guid Id) : IRequest<Result>;
internal class SeenRequestHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<SendRequestCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(SendRequestCommand request, CancellationToken cancellationToken)
    {
        IngredientSupplyRequest ingredientSupplyRequest = await _unitOfWorks.IngredientSupplyRequestRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        ingredientSupplyRequest.View();
        _unitOfWorks.IngredientSupplyRequestRepository.Update(ingredientSupplyRequest);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
