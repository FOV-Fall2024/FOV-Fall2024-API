using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Points.Queries.GetPointOfCustomer;
public record GetPointsForCustomerCommand(string PhoneNumber) : IRequest<int>;
public class GetPointsOfCustomerQuery : IRequestHandler<GetPointsForCustomerCommand, int>
{
    private readonly UserManager<User> _userManager;
    public GetPointsOfCustomerQuery(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    public async Task<int> Handle(GetPointsForCustomerCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users.Include(x => x.Customer).FirstOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber);
        if (user == null) throw new AppException("Bạn không phải là thành viên của nhà hàng. Xin để lại thông tin để tích điểm");

        return user.Point;
    }
}
