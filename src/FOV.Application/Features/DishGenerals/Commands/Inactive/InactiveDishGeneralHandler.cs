using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Inactive;
public sealed record InactiveProductGeneralCommand(Guid Id) : IRequest<Result>;
public class InactiveDishGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveProductGeneralCommand request, CancellationToken cancellationToken)
    {
        DishGeneral productGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        productGeneral.SetState(true);
        _unitOfWorks.DishGeneralRepository.Update(productGeneral);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
