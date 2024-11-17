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
    public decimal Price { get; set; }

    public decimal PercentagePriceDifference { get; set; }

    public string DishGeneralName { get; set; } = string.Empty;

    public string DishGeneralDescription { get; set; } = string.Empty;
    public List<string>? ImageUrl { get; set; } = [];
    public Guid CategoryId { get; set; }
}


public class UpdateDishIngredientHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateProductGeneralCommand request, CancellationToken cancellationToken)
    {
        DishGeneral product = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        product.Update(request.DishGeneralName, request.DishGeneralDescription, request.CategoryId,request.Price,request.PercentagePriceDifference);

        if (request.ImageUrl is not null)
        {
            await UpdateImage(request.ImageUrl, request.Id);

            //var updatedImages = await _unitOfWorks.DishGeneralImageRepository.WhereAsync(x => x.DishGeneralId == request.Id);
            //product.DishGeneralImages = [.. updatedImages.OrderBy(x => x.Order)];
        }

        _unitOfWorks.DishGeneralRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }


    public async Task UpdateImage(List<string> images, Guid dishGeneralId)
    {
        var existingImages = await _unitOfWorks.DishGeneralImageRepository.WhereAsync(x => x.DishGeneralId == dishGeneralId);

        for (int i = 0; i < existingImages.Count; i++)
        {
            if (i < images.Count)
            {
                existingImages[i].UpdateImage(images[i]);
                _unitOfWorks.DishGeneralImageRepository.Update(existingImages[i]);
            }
        }

        if (images.Count > existingImages.Count)
        {
            var newImages = images.Skip(existingImages.Count)
                                  .Select((imageUrl, index) => new DishGeneralImage(imageUrl, dishGeneralId, existingImages.Count + index))
                                  .ToList();
            await _unitOfWorks.DishGeneralImageRepository.AddRangeAsync(newImages);
        }

        await _unitOfWorks.SaveChangeAsync();
    }

}
