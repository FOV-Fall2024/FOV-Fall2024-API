using System.Net.Http.Headers;
using Azure;
using FOV.Application.Features.ProductGenerals.Mapper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.ProductGenerals.Queries.GetProductGeneralDetail;

public sealed record GetProductGeneralDetailCommand(Guid Id) : IRequest<GetProductGeneralDetailResponse>;

public record GetProductGeneralDetailResponse(Guid Id, string Name, string Description, DateTimeOffset CreatedDate, DateTimeOffset UpdateDated, List<GetIngredientResponse> GetIngredients);

public record GetIngredientResponse(Guid Id, string Name, decimal Quantity);
public class GetProductGeneralDetailHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetProductGeneralDetailCommand, GetProductGeneralDetailResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetProductGeneralDetailResponse> Handle(GetProductGeneralDetailCommand request, CancellationToken cancellationToken)
    {
        var response = await _unitOfWorks.ProductGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        var ingredients = await _unitOfWorks.IngredientGeneralRepository.GetAllAsync(x => x.ProductIngredientGenerals.Where(x => x.ProductGeneralId == request.Id));
        return response.MapperDetailDTO(ingredients.Select(x => x.MapperIngredientDTO(request.Id)).ToList());
    }
}
