using FOV.Application.Features.Users.Responses;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FOV.Application.Features.Users.Queries.GetAllUser
{
    public sealed record GetUsersCommand(string? UserName, string? LastName, string? FirstName, string? Email, PagingRequest? PagingRequest) : IRequest<PagedResult<GetUsersResponse>>;


    public class GetAllUserHandler(UserManager<User> userManager, IUnitOfWorks unitOfWorks) : IRequestHandler<GetUsersCommand, PagedResult<GetUsersResponse>>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

        public async Task<PagedResult<GetUsersResponse>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            // Fetch all users in the specified role
            var users = await _userManager.GetUsersInRoleAsync(Domain.Entities.UserAggregator.Enums.Role.User);

            // Filter users based on the request parameters
            var filteredUsers = users.AsQueryable().CustomFilterV1(new User
            {
                UserName = request.UserName ?? string.Empty,
                FirstName = request.FirstName ?? string.Empty,
                LastName = request.LastName ?? string.Empty,
                Email = request.Email ?? string.Empty,
            });

            // Map to response DTO
            var mappedUsers = filteredUsers.Select(x => new GetUsersResponse(
                x.Id,
                $"{x.FirstName} {x.LastName}",
                x.LastName ?? string.Empty,
                x.FirstName ?? string.Empty,
                x.Email ?? string.Empty)).ToList();

            // Get pagination and sorting values
            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            // Sort and paginate the results
            var sortedResults = PaginationHelper<GetUsersResponse>.Sorting(sortType, mappedUsers, sortField);
            var result = PaginationHelper<GetUsersResponse>.Paging(sortedResults, page, pageSize);

            return result;
        }
    }
}
