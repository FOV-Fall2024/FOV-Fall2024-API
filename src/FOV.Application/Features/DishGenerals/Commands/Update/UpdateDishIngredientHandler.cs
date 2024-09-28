using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Update;

public sealed record UpdateProductGeneralCommand : IRequest<Result>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }
}


internal class UpdateDishIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateProductGeneralCommand request, CancellationToken cancellationToken)
    {
        DishGeneral product = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.Update(request.Name, request.Description, request.CategoryId);

        _unitOfWorks.ProductGeneralRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
