using FluentValidation;
using FOV.Domain.Entities.RestaurantAggregator;
using FOV.Infrastructure.UnitOfWork.IUnitOfWorkSetup;

namespace FOV.Application.Features.Authorize.Commands.UserLogin;
public class UserLoginValidator : AbstractValidator<UserLoginCommand>
{
    public UserLoginValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
            .WithMessage("Invalid email format.");
        RuleFor(x => x.Password).NotNull();


    }
}



