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

        await UpdateInBranch(dishGeneral.Id, request.Images);


        // Save all changes in the unit of work

        // Save all changes in the unit of work

    public async Task UpdateInBranch(Guid dishId, ICollection<string> images)
    {
        List<Dish> dishes = await _unitOfWorks.DishRepository.WhereAsync(x => x.DishGeneralId == dishId);
        foreach (var dish in dishes)
        {
            await _unitOfWorks.DishImageRepository.AddRangeAsync(images.Select(x => new DishImage(dish.Id, x)).ToList());
        }
        await _unitOfWorks.SaveChangeAsync();
    }
            
        }
        await _unitOfWorks.SaveChangeAsync();

    }
            
        }
        await _unitOfWorks.SaveChangeAsync();

    }
            
        }
        await _unitOfWorks.SaveChangeAsync();

    }
}
