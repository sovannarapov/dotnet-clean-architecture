using Application.Features.Users.Update;
using FluentValidation;

namespace Application.Features.Users.Register;

internal sealed class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty()
            .WithMessage("UserId is required");

        When(c => c.FirstName is not null, () => RuleFor(c => c.FirstName)
                .NotEmpty()
                .WithMessage("First name cannot be empty")
                .MaximumLength(50)
                .WithMessage("First name must not exceed 50 characters"));

        When(c => c.LastName is not null, () => RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("Last name is required")
            .MaximumLength(50)
            .WithMessage("Last name must not exceed 50 characters"));

        When(c => c.Email is not null, () => RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid"));
    }
}
