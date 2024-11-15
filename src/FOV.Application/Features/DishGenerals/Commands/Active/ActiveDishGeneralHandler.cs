using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Active;

public sealed record ActiveProductGeneralCommand(Guid id) : IRequest<Result>;
public class ActiveProductGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveProductGeneralCommand request, CancellationToken cancellationToken)
    {
        DishGeneral productGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.id) ?? throw new Exception();
        productGeneral.UpdateState(true);
        _unitOfWorks.DishGeneralRepository.Update(productGeneral);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }


}
