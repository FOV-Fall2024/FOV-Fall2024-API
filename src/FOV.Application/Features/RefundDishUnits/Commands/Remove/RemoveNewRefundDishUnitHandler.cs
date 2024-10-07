using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.RefundDishUnits.Commands.Remove;
public sealed record RemoveNewRefundDishUnitCommand : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
public class RemoveNewRefundDishUnitHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RemoveNewRefundDishUnitCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(RemoveNewRefundDishUnitCommand request, CancellationToken cancellationToken)
    {
        RefundDishUnit unit = await _unitOfWorks.RefundDishUnitRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        _unitOfWorks.RefundDishUnitRepository.Remove(unit);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
