using FluentResults;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Active;

public sealed record ActiveProductGeneralCommand(Guid Id) : IRequest<Result>;
public class ActiveProductGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveProductGeneralCommand request, CancellationToken cancellationToken)
    {
        DishGeneral productGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        productGeneral.UpdateState(true);
        _unitOfWorks.DishGeneralRepository.Update(productGeneral);

        //? inactvie another general dish
        //? inactive  another dish
        //await UpdateGeneralDish(request.Id);
        await InactiveGeneralDish(productGeneral.DishName);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }

    public async Task InactiveGeneralDish(string generalDishName)
    {
        var generalDishes = await _unitOfWorks.DishGeneralRepository.WhereAsync(x => x.DishName == generalDishName);
        foreach (var generalDish in generalDishes)
        {
            if (generalDish.Status == Domain.Entities.TableAggregator.Enums.Status.Active)
            {
                generalDish.UpdateState(false);
                _unitOfWorks.DishGeneralRepository.Update(generalDish);
                 await UpdateDish(generalDish.Id);
                await _unitOfWorks.SaveChangeAsync();
                break;

            }
        }
    }

    //public async Task UpdateGeneralDish(Guid generalDishId)
    //{
    //    // Get the target dish
    //    DishGeneral dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(generalDishId)
    //        ?? throw new Exception("DishGeneral not found");

    //    // Check if it has a parent dish
    //    if (dishGeneral.DishGeneralParentId != null)
    //    {
    //        // Get the parent dish
    //        DishGeneral dishGeneralCheck = await _unitOfWorks.DishGeneralRepository.GetByIdAsync((Guid)dishGeneral.DishGeneralParentId)
    //            ?? throw new Exception("Parent DishGeneral not found");

    //        // If the parent is active, deactivate it
    //        if (dishGeneralCheck.Status == Domain.Entities.TableAggregator.Enums.Status.Active)
    //        {
    //            dishGeneralCheck.UpdateState(false);
    //            await UpdateDish(dishGeneral.Id);
    //            _unitOfWorks.DishGeneralRepository.Update(dishGeneralCheck);
    //        }
    //    }
    //    else
    //    {
    //        // If it has children, deactivate all active ones
    //        var childDishes = await _unitOfWorks.DishGeneralRepository.WhereAsync(x => x.DishGeneralParentId == dishGeneral.Id);
    //        foreach (var item in childDishes)
    //        {
    //            if (item.Status == Domain.Entities.TableAggregator.Enums.Status.Active)
    //            {
    //                item.UpdateState(false);
    //                await UpdateDish(item.Id);
    //                _unitOfWorks.DishGeneralRepository.Update(item);
    //                break;
    //            }
    //            await UpdateGeneralDish(item.Id);
    //        }
    //    }

    //    dishGeneral.UpdateState(true);
    //    _unitOfWorks.DishGeneralRepository.Update(dishGeneral);

    //    await _unitOfWorks.SaveChangeAsync();
    //}

    public async Task UpdateDish(Guid dishGeneralId)
    {
        var dishes = await _unitOfWorks.DishRepository.WhereAsync(x => x.DishGeneralId == dishGeneralId);
        foreach (var item in dishes)
        {
            item.UpdateState(false);
            _unitOfWorks.DishRepository.Update(item);
        }
        await _unitOfWorks.SaveChangeAsync();
    }
}

