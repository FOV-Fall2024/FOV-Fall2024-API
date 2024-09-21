using FOV.Application.Features.Users.Mapper;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Users.Queries.GetAllUser;

public sealed record GetUsersCommand(string? UserName, string? LastName, string? FirstName, string? Email) : IRequest<List<GetUsersResponse>>;

public sealed record GetUsersResponse(string Id, string Name, string LastName, string FirstName, string Email);
public class GetAllUserHandler(UserManager<User> userManager) : IRequestHandler<GetUsersCommand, List<GetUsersResponse>>
{
    private readonly UserManager<User> _userManager = userManager;
    public async Task<List<GetUsersResponse>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
    {
        var users = await _userManager.GetUsersInRoleAsync(Domain.Entities.UserAggregator.Enums.Role.User); ;
        var filterUser = users.AsQueryable().CustomFilterV1(new User
        {
            UserName = request.UserName ?? string.Empty,
            FirstName = request.FirstName ?? string.Empty,
            Email = request.Email ?? string.Empty,
            LastName = request.LastName ?? string.Empty,
        });

        return [.. filterUser.Select(x => x.MapAllDTO())];
    }
}
