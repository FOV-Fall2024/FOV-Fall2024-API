using FluentValidation;

namespace FOV.Application.Features.Authorize.Commands.UserRegister;
public sealed class UserRegisterValidator : AbstractValidator<UserRegisterCommand>
{
    public UserRegisterValidator()
    {
        RuleFor(x => x.Email)
            .NotNull()
            .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")
            .WithMessage("Invalid email format.");
        RuleFor(x => x.Password).NotNull();
        RuleFor(x => x.FirstName).NotNull();
        RuleFor(x => x.LastName).NotNull();
    }
}
