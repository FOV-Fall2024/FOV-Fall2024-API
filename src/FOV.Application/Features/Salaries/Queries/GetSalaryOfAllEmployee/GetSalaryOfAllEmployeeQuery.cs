using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Behaviours.Claim;
using FOV.Application.Common.Exceptions;
using FOV.Application.Features.Salaries.Commands.Create;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Salaries.Queries.GetSalaryOfAllEmployee;
public record GetSalaryOfAllEmployeeCommand(PagingRequest? PagingRequest, DateTime? ChosenDate = null) : IRequest<PagedResult<CreateSalaryResponse>>;
public class GetSalaryOfAllEmployeeQuery(IUnitOfWorks unitOfWorks, IClaimService claimService, UserManager<User> userManager) : IRequestHandler<GetSalaryOfAllEmployeeCommand, PagedResult<CreateSalaryResponse>>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly IClaimService _claimService = claimService;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<PagedResult<CreateSalaryResponse>> Handle(GetSalaryOfAllEmployeeCommand request, CancellationToken cancellationToken)
    {
        var userRole = _claimService.UserRole;
        Guid? restaurantId = null;
        if (userRole == Role.Manager)
        {
            restaurantId = _claimService.RestaurantId;
        }
        var chosenDate = request.ChosenDate ?? DateTime.UtcNow;
        var startDate = new DateTime(chosenDate.Year, chosenDate.Month, 1);
        var endDate = startDate.AddMonths(1).AddDays(-1);

        var query = await _unitOfWorks.WaiterSalaryRepository
            .WhereAsync(ws => ws.PayDate >= startDate && ws.PayDate <= endDate
                            && (!restaurantId.HasValue || ws.User.RestaurantId == restaurantId), x => x.User);

        var mappedResult = query.Select(ws => new CreateSalaryResponse(
                ws.Id,
                ws.User.EmployeeCode,
                ws.User.FullName,
                new CreateSalaryDto(
                    ws.TotalShifts,
                    ws.TotalHoursWorked,
                    ws.ActualHoursWorked,
                    ws.RegularSalary,
                    ws.OvertimeSalary,
                    ws.Penalty,
                    ws.TotalSalaries
                )
            ))
            .ToList();

        var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);
        var sortedResults = PaginationHelper<CreateSalaryResponse>.Sorting(sortType, mappedResult, sortField);
        var result = PaginationHelper<CreateSalaryResponse>.Paging(sortedResults, page, pageSize);

        return result;
    }
}

