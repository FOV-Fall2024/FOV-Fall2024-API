﻿using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.ComboAggregator;
using FOV.Domain.Entities.ComboAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Combos.Queries.GetComboDetail;
public sealed record GetComboDetailCommand(Guid Id) : IRequest<GetComboDetailResponse>;
public sealed record GetComboDetailResponse(Guid Id, string ComboName, Status Stock, int Quantity, decimal Price, decimal PercentReduce, List<GetDishComboResponse> DishComboResponses);

public sealed record GetDishComboResponse(Guid DishId, bool IsDeleted);
public class GetComboDetailHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<GetComboDetailCommand, GetComboDetailResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<GetComboDetailResponse> Handle(GetComboDetailCommand request, CancellationToken cancellationToken)
    {
        Combo combo = await _unitOfWorks.ComboRepository.GetByIdAsync(request.Id) ?? throw new AppException();
        List<GetDishComboResponse> dishCombo = _unitOfWorks.DishComboRepository.WhereAsync(x => x.ComboId == request.Id).Result.Select(x => new GetDishComboResponse(x.DishId, x.IsDeleted)).ToList();
        return new GetComboDetailResponse(combo.Id, combo.ComboName, combo.Status, combo.Quantity, combo.Price, combo.PercentReduce, dishCombo);
    }
}
