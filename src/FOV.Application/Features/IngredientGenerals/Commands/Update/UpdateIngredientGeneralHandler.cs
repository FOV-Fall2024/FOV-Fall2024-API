using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using System.Text.Json.Serialization;

namespace FOV.Application.Features.IngredientGenerals.Commands.Update;

public record UpdateIngredientGeneralCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public Guid IngredientTypeId { get; set; }
}

internal class UpdateIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateIngredientGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(UpdateIngredientGeneralCommand request, CancellationToken cancellationToken)
    {
        IngredientGeneral ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        ingredientGeneral.Update(request.Name, request.Description, request.IngredientTypeId);
        _unitOfWorks.IngredientGeneralRepository.Update(ingredientGeneral);
        await _unitOfWorks.SaveChangeAsync();
        return ingredientGeneral.Id;
    }
}
