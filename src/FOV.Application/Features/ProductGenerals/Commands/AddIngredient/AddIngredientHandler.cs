using FOV.Domain.Entities.ProductGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.ProductGenerals.Commands.AddIngredient;

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
        ProductIngredientGeneral general = new(request.Id, request.IngredientId, request.Quantity);
        await _unitOfWorks.ProductIngredientGeneralRepository.AddAsync(general);
        await _unitOfWorks.SaveChangeAsync();
        return request.Id;
    }
}
