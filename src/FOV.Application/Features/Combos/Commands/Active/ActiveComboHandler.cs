using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.Active;

public sealed record ActiveComboCommand(Guid ComboId) : IRequest<Guid>;

public class ActiveComboHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveComboCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Guid> Handle(ActiveComboCommand request, CancellationToken cancellationToken)
    {
        Combo combo = await _unitOfWorks.ComboRepository.GetByIdAsync(request.ComboId, c => c.DishCombos)
                          ?? throw new AppException("Combo not found");

        var dishIds = combo.DishCombos.Select(cd => cd.DishId).ToList();
        var dishes = await _unitOfWorks.DishRepository.WhereAsync(d => dishIds.Contains(d.Id), d => d.DishGeneral);

        if (dishes.Any(d => d.Status != Status.Active))
        {
            var inactiveDishNames = dishes
                .Where(d => d.Status != Status.Active)
                .Select(d => d.DishGeneral.DishName)
                .ToList();

            if (inactiveDishNames.Count != 0)
            {
                throw new AppException($"Không thể active combo này. Món ăn trong combo này đang bị Inactive: {string.Join(", ", inactiveDishNames)}");
            }
        }

        combo.UpdateState(true);
        _unitOfWorks.ComboRepository.Update(combo);
        await _unitOfWorks.SaveChangeAsync();

        return combo.Id;
    }
}
