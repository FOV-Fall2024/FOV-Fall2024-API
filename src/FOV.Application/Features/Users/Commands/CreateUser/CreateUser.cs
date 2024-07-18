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
        public string userName { get; set; }
        public string email { get; set; }
        public string passwordDefault { get; set; }
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
                UserName = request.userName,
                Email = request.email,

            };
            var result = await _userManager.CreateAsync(user, request.passwordDefault);

            return "LoginSucessfully";
        }
    }
}