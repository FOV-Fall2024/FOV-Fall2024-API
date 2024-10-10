using FOV.Application.Features.Users.Responses;
using FOV.Domain.Entities.UserAggregator;

namespace FOV.Application.Features.Users.Mapper;
public static class UserMapper
{
    public static GetUsersResponse MapAllDTO(this User user)
    {
        return new GetUsersResponse(user.Id, user.UserName, user.Email, user.Customer.Created);
    }
}
