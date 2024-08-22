﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Features.Tables.Queries;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Shift.Queries;
public record GetShiftRequest(Guid? Id, string? ShiftName, DateTime? StartTime, DateTime? EndTime) : IRequest<List<GetShiftResponse>>;
public record GetShiftResponse(Guid Id, string ShiftName, DateTime StartTime, DateTime EndTime);
public class GetShiftQuery(IUnitOfWorks unitOfWorks) : IRequestHandler<GetShiftRequest, List<GetShiftResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<List<GetShiftResponse>> Handle(GetShiftRequest request, CancellationToken cancellationToken)
    {
        var shifts = await _unitOfWorks.ShiftRepository.GetAllAsync();
        var filterEntity = new Domain.Entities.ShiftAggregator.Shift
        {
            Id = request.Id.HasValue ? request.Id.Value : Guid.Empty,
            ShiftName = string.IsNullOrEmpty(request.ShiftName) ? string.Empty : request.ShiftName,
            StartTime = request.StartTime.HasValue ? request.StartTime.Value : DateTime.MinValue,
            EndTime = request.EndTime.HasValue ? request.EndTime.Value : DateTime.MinValue
        };
        var filterTable = shifts.AsQueryable().CustomFilterV1(filterEntity);
        return filterTable.Select(shift => new GetShiftResponse(shift.Id, shift.ShiftName ?? string.Empty, shift.StartTime ?? DateTime.MinValue, shift.EndTime ?? DateTime.MinValue)).ToList();
    }
}
