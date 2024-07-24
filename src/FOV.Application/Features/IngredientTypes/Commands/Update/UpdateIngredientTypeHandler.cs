using System.Text.Json.Serialization;
using FOV.Domain.Entities.IngredientAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientTypes.Commands.Update;

public sealed record UpdateIngredientTypeCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}

public class UpdateIngredientTypeHandler(IUnitOfWorks unitOfWork) : IRequestHandler<UpdateIngredientTypeCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(UpdateIngredientTypeCommand request, CancellationToken cancellationToken)
    {
        IngredientType ingredientType = await _unitOfWork.IngredientTypeRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        ingredientType.Update(request.Name, request.Description);
        _unitOfWork.IngredientTypeRepository.Update(ingredientType);
        await _unitOfWork.SaveChangeAsync();
        return ingredientType.Id;
    }
}
