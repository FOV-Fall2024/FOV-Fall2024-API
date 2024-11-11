using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Commands.Create;

public record CreateIngredientGeneralCommand(string IngredientGeneralName, string IngredientGeneralDescription, Guid IngredientType, Guid ingredientMeasureId) : IRequest<Guid>;
public class CreateIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateIngredientGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWork = unitOfWorks;
    public async Task<Guid> Handle(CreateIngredientGeneralCommand request, CancellationToken cancellationToken)
    {
        IngredientGeneral ingredientGeneral = new(request.IngredientGeneralName, request.IngredientGeneralDescription, request.IngredientType,request.ingredientMeasureId);
        await _unitOfWork.IngredientGeneralRepository.AddAsync(ingredientGeneral);
        await _unitOfWork.SaveChangeAsync();
        return ingredientGeneral.Id;
    }



}



