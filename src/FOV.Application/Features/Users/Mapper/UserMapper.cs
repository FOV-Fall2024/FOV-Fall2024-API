using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FOV.Application.Features.Users.Queries.GetAllUser;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Application.Features.Users.Mapper;
public static class UserMapper
{
    public static GetUsersResponse MapAllDTO(this User user)
    {
        return new GetUsersResponse(user.Id, user.UserName, user.LastName, user.FirstName, user.Email);
    }
}
