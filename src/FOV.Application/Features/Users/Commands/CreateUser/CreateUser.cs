using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using FOV.Application.Common.Exceptions;
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
    public required string FullName { get; set; }
    [JsonIgnore]
    public string? Email { get; set; }
    [JsonIgnore]
    public string? Address { get; set; }
}

public class CreateUserCommandHandler(IUnitOfWorks unitOfWorks) : IRequestHandler<CreateUserCommand, RegisterUserResponse>
{
    private readonly IUnitOfWorks _unitOfWorks = unitOfWorks;

    public async Task<RegisterUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existPhoneUser = await _unitOfWorks.CustomerRepository.AnyAsync(x => x.PhoneNumber == request.PhoneNumber);

        if (existPhoneUser)
        {
            throw new AppException("Đã trùng số điện thoại");
        }

        var customer = new Customer(request.PhoneNumber, request.FullName);
        await _unitOfWorks.CustomerRepository.AddAsync(customer);
        await _unitOfWorks.SaveChangeAsync();

        return CreateResponse(customer, "New Member");
    }
    private RegisterUserResponse CreateResponse(Customer customer, string msg) => new RegisterUserResponse(customer.Id, msg, $"{customer.FullName}", customer.PhoneNumber);
}
