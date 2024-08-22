using FOV.Application.Features.IngredientGenerals.Mapper;
using FOV.Domain.Entities.IngredientGeneralAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.IngredientGenerals.Queries.GetAllIngredientGeneral;

public sealed record GetAllIngredientCommand(string? IngredientName, Guid? IngredientTypeId) : IRequest<List<GetAllIngredientResponse>>;

public record GetAllIngredientResponse(Guid Id, string IngredientName, Guid IngredientTypeId, string IngredientDescription);
public class GetAllIngredientGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetAllIngredientCommand, List<GetAllIngredientResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetAllIngredientResponse>> Handle(GetAllIngredientCommand request, CancellationToken cancellationToken)
    {
        var allIngredient = await _unitOfWorks.IngredientGeneralRepository.GetAllAsync();
        var filteredIngredient = allIngredient.AsQueryable().CustomFilterV1(new IngredientGeneral
        {
            IngredientName = request.IngredientName ?? string.Empty,
            IngredientTypeId = request.IngredientTypeId ?? Guid.Empty,
        });

        return [.. filteredIngredient.Select(x => x.MapperGetAllDTO())];
    }

}
