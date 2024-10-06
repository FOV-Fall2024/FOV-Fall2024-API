using FOV.Domain.Entities.DishAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.RefundDishUnits.Commands.Create;

public sealed record CreateNewRefundDishUnitCommand(Guid RefundDishInventoryId, decimal ConversionFactor, string UnitName) : IRequest<Guid>;
public class CreateNewRefundDishUnitHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateNewRefundDishUnitCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(CreateNewRefundDishUnitCommand request, CancellationToken cancellationToken)
    {
        RefundDishUnit unit = new(request.RefundDishInventoryId, request.ConversionFactor, request.UnitName);
        await _unitOfWorks.RefundDishUnitRepository.AddAsync(unit);
        return unit.Id;
    }
}

