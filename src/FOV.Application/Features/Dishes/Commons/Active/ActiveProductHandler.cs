using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Dishes.Commons.Active;
public sealed record ActiveProductCommand(Guid Id) : IRequest<Guid>;
public class ActiveProductHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveProductCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(ActiveProductCommand request, CancellationToken cancellationToken)
    {
        Dish product = await _unitOfWorks.DishRepository.GetByIdAsync(request.Id) ?? throw new AppException("Không tìm thấy món ăn");

        var dishGeneral = await _unitOfWorks.DishGeneralRepository.GetByIdAsync(product.DishGeneralId.Value) ?? throw new AppException("Không tìm thấy món ăn gốc");
        if (dishGeneral.Status == Status.Inactive)
        {
            throw new AppException("Không thể kích hoạt món ăn này vì món này đã bị admin vô hiệu hóa");
        }
        if (product.Status == Status.Active)
        {
            throw new AppException("Món ăn đã được kích hoạt");
        }
        product.UpdateState(true);
        _unitOfWorks.DishRepository.Update(product);
        await _unitOfWorks.SaveChangeAsync();
        return product.Id;

    }
}
