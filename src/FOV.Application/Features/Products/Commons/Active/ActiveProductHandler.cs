using FluentResults;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Products.Commons.Active;
public sealed record ActiveProductCommand(Guid Id) : IRequest<Result>;
internal class ActiveProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _unitOfWorks.ProductRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.UpdateState(false);
        _unitOfWorks.ProductRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
