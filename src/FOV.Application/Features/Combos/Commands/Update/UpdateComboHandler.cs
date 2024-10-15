using System.Text.Json.Serialization;
using FluentResults;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.Update;

public sealed record UpdateComboCommand(string ComboName, string ComboDescription, decimal Price, string Thumbnail) : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; set; }
}
public class UpdateComboHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<UpdateComboCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(UpdateComboCommand request, CancellationToken cancellationToken)
    {
        Combo combo = await _unitOfWorks.ComboRepository.GetByIdAsync(request.Id) ?? throw new Exception();
        combo.Update(request.ComboName, request.ComboDescription, combo.Thumbnail, request.Price);
        _unitOfWorks.ComboRepository.Update(combo);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
