using FOV.Application.Features.Users.Responses;
using FOV.Domain.Entities.UserAggregator;
using FOV.Infrastructure.Helpers.GetHelper;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Users.Queries.GetAllUser
{
    public sealed record GetUsersCommand(string? UserName, string? PhoneNumber, PagingRequest? PagingRequest) : IRequest<PagedResult<GetUsersResponse>>;
    public class GetAllUserHandler(UserManager<User> userManager, IUnitOfWorks unitOfWorks) : IRequestHandler<GetUsersCommand, PagedResult<GetUsersResponse>>
    {
        private readonly UserManager<User> _userManager = userManager;
        private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

        public async Task<PagedResult<GetUsersResponse>> Handle(GetUsersCommand request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWorks.CustomerRepository.GetAllAsync();
            var filteredUsers = users.Where(x =>
                                            (string.IsNullOrEmpty(request.UserName) || x.FullName.Contains(request.UserName, StringComparison.OrdinalIgnoreCase)) &&
                                            //(string.IsNullOrEmpty(request.FirstName) || x.FirstName.Contains(request.FirstName, StringComparison.OrdinalIgnoreCase)) &&
                                            //(string.IsNullOrEmpty(request.LastName) || x.LastName.Contains(request.LastName, StringComparison.OrdinalIgnoreCase)) &&
                                            (string.IsNullOrEmpty(request.PhoneNumber) || x.PhoneNumber.Contains(request.PhoneNumber, StringComparison.OrdinalIgnoreCase)));

            var mappedUsers = filteredUsers.Select(x => new GetUsersResponse(
                x.Id,
                x.FullName,
                x.PhoneNumber ?? string.Empty,
                x.Point,
                x.Created)).ToList();

            var (page, pageSize, sortType, sortField) = PaginationUtils.GetPaginationAndSortingValues(request.PagingRequest);

            var sortedResults = PaginationHelper<GetUsersResponse>.Sorting(sortType, mappedUsers, sortField);
            var result = PaginationHelper<GetUsersResponse>.Paging(sortedResults, page, pageSize);

            return result;
            throw new NotImplementedException();
        }
    }
}
