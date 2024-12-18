using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Tables.Commands.TableLogout;
public record TableLogoutCommand(Guid TableId, string EmployeeCode) : IRequest<Guid>;
public partial class TableLogoutHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<TableLogoutCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    public async Task<Guid> Handle(TableLogoutCommand request, CancellationToken cancellationToken)
    {
        if (!MyRegex().IsMatch(request.EmployeeCode))
        {
            throw new AppException("Invalid Manager Code format.");
        }

        var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.TableId) ?? throw new AppException();
        if (table.IsLogin == false) throw new AppException("Table is not login.");
        if (table.TableStatus != Domain.Entities.TableAggregator.Enums.TableStatus.Available) throw new AppException("Bàn này hiện đang có đơn đang thực hiện.");

        var restaurantId = table.RestaurantId;
        var manager = await _userManager.Users.FirstOrDefaultAsync(u => u.EmployeeCode == request.EmployeeCode && u.RestaurantId == restaurantId);

        if (manager == null)
        {
            throw new AppException("Manager not found or does not belong to this restaurant.");
        }

        table.UpdateIsLogin(false);
        _unitOfWorks.TableRepository.Update(table);
        await _unitOfWorks.SaveChangeAsync();
        return table.Id;
    }

    [GeneratedRegex(@"^MNG_\d+$")]
    private static partial Regex MyRegex();
}
