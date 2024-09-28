using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.AddIngredient;

public sealed record AddIngredientCommand : IRequest<Guid>
{
    public Guid Id { get; set; }

    public Guid IngredientId { get; set; }

    public decimal Quantity { get; set; }
}
public class AddIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddIngredientCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
    {
        DishIngredientGeneral general = new(request.Id, request.IngredientId, request.Quantity);
        await _unitOfWorks.DishIngredientGeneralRepository.AddAsync(general);
        await _unitOfWorks.SaveChangeAsync();
        return request.Id;
    }
}
