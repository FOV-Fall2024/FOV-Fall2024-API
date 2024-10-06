using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.RefundDishUnits.Commands.Update;
public sealed record UpdateRefundUnitCommand(string Name, decimal ConversionFactor) : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
public class UpdateRefundDishUnitHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateRefundUnitCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateRefundUnitCommand request, CancellationToken cancellationToken)
    {
        RefundDishUnit unit = await _unitOfWorks.RefundDishUnitRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        unit.Update(request.Name, request.ConversionFactor);
        _unitOfWorks.RefundDishUnitRepository.Update(unit);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();

    }
}
