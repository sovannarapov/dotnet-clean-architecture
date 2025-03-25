using FluentValidation;

namespace Application.Features.Users.Login;

public sealed class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email format");

        RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }
}
