using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Features.IngredientGenerals.Responses;
using FOV.Domain.Entities.IngredientGeneralAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Queries.GetDetailIngredientGeneral;
public record GetDetailIngredientGeneralCommand(Guid Id) : IRequest<GetDetailIngredientGeneralResponse>;
public class GetDetailIngredientGeneralQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetDetailIngredientGeneralCommand, GetDetailIngredientGeneralResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetDetailIngredientGeneralResponse> Handle(GetDetailIngredientGeneralCommand request, CancellationToken cancellationToken)
    {
        var ingredientGeneral = await _unitOfWorks.IngredientGeneralRepository.GetByIdAsync(request.Id);
        return new GetDetailIngredientGeneralResponse(ingredientGeneral.Id, ingredientGeneral.IngredientName, ingredientGeneral.IngredientTypeId, ingredientGeneral.IngredientMeasure + 1, ingredientGeneral.IngredientDescription, ingredientGeneral.Status, ingredientGeneral.Created);
    }
}
