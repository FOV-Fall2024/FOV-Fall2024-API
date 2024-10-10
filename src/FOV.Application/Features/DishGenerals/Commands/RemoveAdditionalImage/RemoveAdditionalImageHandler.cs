using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.RemoveAdditionalImage;

public sealed record RemoveAdditionalImageCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public required Guid DishGeneralImageId { get; set; }
}

public class RemoveAdditionalImageHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RemoveAdditionalImageCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(RemoveAdditionalImageCommand request, CancellationToken cancellationToken)
    {
        DishGeneral dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        DishGeneralImage image = await _unitOfWorks.DishGeneralImageRepository.GetByIdAsync(request.DishGeneralImageId) ?? throw new Exception();
        // dishGeneral.RemoveImage(request.ImageUrl);
        _unitOfWorks.DishGeneralRepository.Update(dishGeneral);
        await UpdateInBranch(request.Id, image.Url);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }


    public async Task UpdateInBranch(Guid dishId, string images)
    {
        var dishes = await _unitOfWorks.DishRepository.WhereAsync(x => x.DishGeneralId == dishId, x => x.DishImages);
        foreach (var dish in dishes)
        {
            var imageToRemove = dish.DishImages.FirstOrDefault(x => x.ImageUrl == images);

            if (imageToRemove != null)
            {
                // Remove the image from the repository
                _unitOfWorks.DishImageRepository.Remove(imageToRemove);
            }
        }
        await _unitOfWorks.SaveChangeAsync();

    }


}
