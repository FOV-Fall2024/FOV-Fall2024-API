﻿using System.Text.Json.Serialization;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Commands.Update;

public record UpdateIngredientGeneralCommand : IRequest<Guid>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string IngredientGeneralName { get; set; } = string.Empty;

    public string IngredientGeneralDescription { get; set; } = string.Empty;

    public Guid IngredientTypeId { get; set; }
}

internal class UpdateIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateIngredientGeneralCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(UpdateIngredientGeneralCommand request, CancellationToken cancellationToken)
    {
        IngredientGeneral ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        ingredientGeneral.Update(request.IngredientGeneralName, request.IngredientGeneralDescription, request.IngredientTypeId);
        _unitOfWorks.IngredientGeneralRepository.Update(ingredientGeneral);
        await _unitOfWorks.SaveChangeAsync();
        return ingredientGeneral.Id;
    }
}
