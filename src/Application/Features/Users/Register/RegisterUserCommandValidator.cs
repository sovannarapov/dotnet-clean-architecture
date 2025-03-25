using FluentValidation;

namespace Application.Features.Users.Register;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("First name must not exceed 50 characters");

        RuleFor(c => c.LastName)
            .NotEmpty()
            .MaximumLength(50)
            .WithMessage("Last name must not exceed 50 characters");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email format");

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long");
    }
}
