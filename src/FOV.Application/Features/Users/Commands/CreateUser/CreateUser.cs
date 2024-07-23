using FOV.Domain.Entities.UserAggregator;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOV.Application.Features.Users.Commands.CreateUser
{
    public class CreateUseCommand : IRequest<string>
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordDefault { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUseCommand, string>
    {
        private readonly UserManager<User> _userManager;
        public CreateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<string> Handle(CreateUseCommand request, CancellationToken cancellationToken)
        {
            User user = new User
            {
                UserName = request.UserName,
                Email = request.Email,

            };
            var result = await _userManager.CreateAsync(user, request.PasswordDefault);

            return "LoginSucessfully";
        }
    }
}