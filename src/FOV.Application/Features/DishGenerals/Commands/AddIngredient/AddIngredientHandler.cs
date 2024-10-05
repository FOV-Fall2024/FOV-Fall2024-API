using System.Text.Json.Serialization;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.AddIngredient;

public sealed record AddIngredientInProductCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    [JsonIgnore]
    public Guid IngredientId { get; set; }

    public decimal Quantity { get; set; }
}
public class AddIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddIngredientInProductCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(AddIngredientInProductCommand request, CancellationToken cancellationToken)
    {
        DishIngredientGeneral general = new(request.Id, request.IngredientId, request.Quantity);
        await _unitOfWorks.DishIngredientGeneralRepository.AddAsync(general);
        await _unitOfWorks.SaveChangeAsync();
        return request.Id;
    }
}
