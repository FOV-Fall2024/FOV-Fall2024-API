using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Active;
public sealed record ActiveProductCommand(Guid Id) : IRequest<Result>;
public class ActiveProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveProductCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(ActiveProductCommand request, CancellationToken cancellationToken)
    {
        Dish product = await _unitOfWorks.DishRepository.GetByIdAsync(request.Id) ?? throw new Exception();

        var dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(product.DishGeneralId.Value) ?? throw new Exception();
        if (dishGeneral.Status == Status.Inactive)
        {
            return Result.Fail("Không thể kích hoạt món ăn này vì món này đã bị admin vô hiệu hóa");
        }
        if (product.Status == Status.Active)
        {
            return Result.Fail("Món ăn đã được kích hoạt");
        }
        product.UpdateState(true);
        _unitOfWorks.DishRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
