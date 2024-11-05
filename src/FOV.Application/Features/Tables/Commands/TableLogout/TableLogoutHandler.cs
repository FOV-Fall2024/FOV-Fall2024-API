using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;

namespace FOV.Application.Features.Tables.Commands.TableLogout;
public record TableLogoutCommand(Guid TableId, string EmployeeCode) : IRequest<Guid>;
public partial class TableLogoutHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<TableLogoutCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    public async Task<Guid> Handle(TableLogoutCommand request, CancellationToken cancellationToken)
    {
        //if (!MyRegex().IsMatch(request.EmployeeCode))
        //{
        //    throw new Exception("Invalid Manager Code format.");
        //}

        //var table = await _unitOfWorks.TableRepository.GetByIdAsync(request.TableId) ?? throw new Exception();
        //if (table.IsLogin == false) throw new Exception("Table is not login.");
        //if (table.TableStatus != Domain.Entities.TableAggregator.Enums.TableStatus.Available) throw new Exception("Bàn này hiện đang có đơn đang thực hiện.");

        //var restaurantId = table.RestaurantId;
        //var manager = await _unitOfWorks.EmployeeRepository.WhereAsync(x => x.RestaurantId == restaurantId && x.EmployeeCode == request.EmployeeCode);

        //if (!manager.Any())
        //{
        //    throw new Exception("Manager not found or does not belong to this restaurant.");
        //}

        //table.UpdateIsLogin(false);
        //_unitOfWorks.TableRepository.Update(table);
        //await _unitOfWorks.SaveChangeAsync();
        //return table.Id;
        throw new NotImplementedException();
    }

    [GeneratedRegex(@"^MNG_\d+$")]
    private static partial Regex MyRegex();
}
