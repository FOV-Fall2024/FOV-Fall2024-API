using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Attendances.Commands.CheckOut;
public record CheckOutCommand(Guid UserId, DateOnly Date, Guid ShiftId, DateTime CheckOutTime, double Latitude, double Longitude) : IRequest<Guid>;
public class CheckOutHandler(IUnitOfWorks unitOfWorks, UserManager<User> userManager) : IRequestHandler<CheckOutCommand, Guid>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;
    private readonly UserManager<User> _userManager = userManager;
    public Task<Guid> Handle(CheckOutCommand request, CancellationToken cancellationToken)
    {
        //Cuối ngày hết đơn mới được check out
        //Những ca còn lại thì thằng cuối cùng của ca đó không được checkout nếu ca sau chưa có người
        throw new NotImplementedException();
    }
}
