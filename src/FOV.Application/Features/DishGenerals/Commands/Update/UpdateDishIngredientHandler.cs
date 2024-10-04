using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Update;

public sealed record UpdateProductGeneralCommand : IRequest<Result>
{
    public Guid Id { get; set; }

    public string IngredientGeneralName { get; set; } = string.Empty;

    public string IngredientGeneralDescription { get; set; } = string.Empty;

    public Guid CategoryId { get; set; }
}


internal class UpdateDishIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateProductGeneralCommand request, CancellationToken cancellationToken)
    {
        DishGeneral product = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.Update(request.IngredientGeneralName, request.IngredientGeneralDescription, request.CategoryId);

        _unitOfWorks.DishGeneralRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
