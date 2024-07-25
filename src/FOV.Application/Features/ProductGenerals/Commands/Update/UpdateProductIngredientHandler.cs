

using FluentResults;
using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.ProductGenerals.Commands.Update;

public sealed record UpdateProductGeneralCommand : IRequest<Result>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}


internal class UpdateProductIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateProductGeneralCommand request, CancellationToken cancellationToken)
    {
        ProductGeneral product =  await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.Update(request.Name, request.Description);

         _unitOfWorks.ProductGeneralRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
