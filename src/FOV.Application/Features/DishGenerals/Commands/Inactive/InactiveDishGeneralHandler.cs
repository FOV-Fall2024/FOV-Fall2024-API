using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.DishGeneralAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.DishGenerals.Commands.Inactive;
public sealed record InactiveProductGeneralCommand(Guid Id) : IRequest<Result>;
public class InactiveDishGeneralHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveProductGeneralCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveProductGeneralCommand request, CancellationToken cancellationToken)
    {
        if (!await CheckDish(request.Id))
        {
            throw new AppException("Không thể xóa món ăn này", new List<FieldError>
    {
        new() {
            Field = "dishId",
            Message = "Món ăn này không thể xóa vì đã được một số nhà hàng sử dụng."
        }
    });
        }


        DishGeneral productGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        productGeneral.UpdateState(false);
        _unitOfWorks.DishGeneralRepository.Update(productGeneral);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }

    public async Task<bool> CheckDish(Guid dishId)
    {
        var dishGenerals = await _unitOfWorks.DishRepository.WhereAsync(x => x.DishGeneralId == dishId);
        return dishGenerals.All(dish => dish.Status != Domain.Entities.TableAggregator.Enums.Status.Active);
    }

}


