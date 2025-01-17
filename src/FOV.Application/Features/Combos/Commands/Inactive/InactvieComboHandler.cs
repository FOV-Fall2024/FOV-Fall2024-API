﻿using FluentResults;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Commands.Inactive;
public sealed record InactiveComboCommand(Guid ComboId) : IRequest<Result>;
internal class InactvieComboHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<InactiveComboCommand, Result>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Result> Handle(InactiveComboCommand request, CancellationToken cancellationToken)
    {
        Combo combo = await _unitOfWorks.ComboRepository.GetByIdAsync(request.ComboId) ?? throw new Exception();
        combo.UpdateState(false);
        _unitOfWorks.ComboRepository.Update(combo);
        await _unitOfWorks.SaveChangeAsync();
        return Result.Ok();
    }
}
