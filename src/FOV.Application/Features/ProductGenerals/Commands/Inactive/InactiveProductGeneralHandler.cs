using FluentResults;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.ProductGenerals.Commands.Inactive;
public sealed record InactiveProductGeneralCommand(Guid Id) : IRequest<Result>;
public class InactiveProductGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveProductGeneralCommand request, CancellationToken cancellationToken)
    {
        ProductGeneral productGeneral = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        productGeneral.SetState(true);
        _unitOfWorks.ProductGeneralRepository.Update(productGeneral);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
