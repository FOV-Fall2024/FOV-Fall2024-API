using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.AddAdditionalImage;
public sealed record AddAdditionalImageCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }

    public required ICollection<string> Images { get; set; }

}
public class AddAdditionalImageHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<AddAdditionalImageCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(AddAdditionalImageCommand request, CancellationToken cancellationToken)
    {
        DishGeneral dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id)
                                    ?? throw new Exception($"DishGeneral with Id {request.Id} not found.");

        _unitOfWorks.DishGeneralRepository.Update(dishGeneral);
        var currentImagesCount = (await _unitOfWorks.DishGeneralImageRepository
            .WhereAsync(x => x.DishGeneralId == request.Id)).Count;

        await _unitOfWorks.DishGeneralImageRepository.AddRangeAsync(
            request.Images.Select((item, index) =>
                new DishGeneralImage(item, request.Id, currentImagesCount + index + 1)
            ).ToList()
        );
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }


}
