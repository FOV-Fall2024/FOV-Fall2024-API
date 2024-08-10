using FluentResults;
using FOV.Domain.Entities.ProductAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Products.Commons.Inactive;
public sealed record InactiveProductCommand(Guid Id) : IRequest<Result>;
internal class InactiveProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _unitOfWorks.ProductRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.UpdateState(true);
        _unitOfWorks.ProductRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
