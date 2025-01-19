using FluentResults;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.DishAggregator;
using FOV.Domain.Entities.TableAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.Active;

public sealed record ActiveComboCommand(Guid ComboId) : IRequest<Result>;

public class ActiveComboHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<ActiveComboCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<Result> Handle(ActiveComboCommand request, CancellationToken cancellationToken)
    {
        Combo combo = await _unitOfWorks.ComboRepository.GetByIdAsync(request.ComboId, c => c.DishCombos)
                          ?? throw new Exception("Combo not found");

        var dishIds = combo.DishCombos.Select(cd => cd.DishId).ToList();
        var dishes = await _unitOfWorks.DishRepository.WhereAsync(d => dishIds.Contains(d.Id));

        if (dishes.Any(d => d.Status != Status.Active))
        {
            var inactiveDishNames = dishes
                .Where(d => d.Status != Status.Active)
                .Select(d => d.DishGeneral.DishName)
                .ToList();

            return Result.Fail($"Không thể active combo này. Món ăn trong combo này đang bị Inactive: {string.Join(", ", inactiveDishNames)}");
        }

        combo.UpdateState(true);
        _unitOfWorks.ComboRepository.Update(combo);
        await _unitOfWorks.SaveChangeAsync();

        return Result.Ok();
    }
}
