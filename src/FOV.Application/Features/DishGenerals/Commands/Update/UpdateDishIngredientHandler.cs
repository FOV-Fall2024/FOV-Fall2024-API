using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Update;

public sealed record UpdateProductGeneralCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public string DishGeneralName { get; set; } = string.Empty;

    public string DishGeneralDescription { get; set; } = string.Empty;
    public string DishGeneralImage { get; set; } = string.Empty;

    public List<string>? ImageUrl { get; set; } = [];
    public Guid CategoryId { get; set; }
}


internal class UpdateDishIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateProductGeneralCommand request, CancellationToken cancellationToken)
    {
        DishGeneral product = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.Update(request.DishGeneralName, request.DishGeneralDescription, request.CategoryId, request.DishGeneralImage);

        if(request.ImageUrl is not null) await UpdateImage(request.ImageUrl,request.Id);
        _unitOfWorks.DishGeneralRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }

    public async ValueTask UpdateImage(List<string> images, Guid dishGeneralId)
    {
        var dishGeneralImages = await _unitOfWorks.DishGeneralImageRepository.WhereAsync(x => x.DishGeneralId == dishGeneralId);

        for (int i = 0; i < dishGeneralImages.Count; i++)
        {
            dishGeneralImages[i].UpdateImage(images[i]);
             _unitOfWorks.DishGeneralImageRepository.Update(dishGeneralImages[i]);

        }
        await _unitOfWorks.SaveChangeAsync();
    }
}
