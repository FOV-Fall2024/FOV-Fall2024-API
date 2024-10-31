using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Features.Users.Responses;
using FOV.Domain.Entities.UserAggregator;
using FOV.Domain.Entities.UserAggregator.Enums;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FOV.Application.Features.Users.Commands.CreateUser;

public sealed record CreateUserCommand : IRequest<RegisterUserResponse>
{
    public required string PhoneNumber { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    [JsonIgnore]
    public string? Email { get; set; }
    [JsonIgnore]
    public string? Address { get; set; }
}

public class CreateUserCommandHandler(UserManager<User> userManager,IUnitOfWorks unitOfWorks) : IRequestHandler<CreateUserCommand, RegisterUserResponse>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<RegisterUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await FindExistingUserAsync(request.PhoneNumber, cancellationToken);
        if (existingUser != null) return CreateResponse(existingUser,"Already in System");

        var user = CreateUser(request);
        var creationResult = await _userManager.CreateAsync(user, "12345678!Fpt");

        if (!creationResult.Succeeded) return new RegisterUserResponse("User creation failed.", null, null, null);
        

        var customer = new Customer(request.PhoneNumber+"address", user.Id, 0);
        await _userManager.AddToRolesAsync(user, [Role.User] );
        await _unitOfWorks.CustomerRepository.AddAsync(customer);
        await _unitOfWorks.SaveChangeAsync();

        return CreateResponse(user,"New Member");
    }

    private async Task<User?> FindExistingUserAsync(string phoneNumber, CancellationToken cancellationToken)
    {
        return await _userManager.Users.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber, cancellationToken);
    }

    private User CreateUser(CreateUserCommand request) => new()
    {
        LastName = request.LastName,
        FirstName = request.FirstName,
        PhoneNumber = request.PhoneNumber,
        UserName = $"{request.FirstName}{request.LastName}",
        Email = request.PhoneNumber + "@gmail.com",
    };

    private RegisterUserResponse CreateResponse(User user,string msg) => new RegisterUserResponse(user.Id, msg, $"{user.FirstName} {user.LastName}", user.PhoneNumber);
}
