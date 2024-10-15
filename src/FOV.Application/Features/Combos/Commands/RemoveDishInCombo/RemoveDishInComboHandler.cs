using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.RemoveDishInCombo;

public sealed record RemoveDishInComboCommand(List<Guid> ProductId) : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
public class RemoveDishInComboHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<RemoveDishInComboCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(RemoveDishInComboCommand request, CancellationToken cancellationToken)
    {
        foreach (var dishId in request.ProductId)
        {
            DishCombo dishCombo = await _unitOfWorks.DishComboRepository.FirstOrDefaultAsync(x => x.DishId == dishId && x.ComboId == request.Id) ?? throw new Exception();
            dishCombo.UpdateState(false);
            _unitOfWorks.DishComboRepository.Update(dishCombo);
        }
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
