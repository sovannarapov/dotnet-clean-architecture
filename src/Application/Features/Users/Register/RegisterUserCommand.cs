using Application.Abstractions.Messaging;
using Application.Dtos.User;

namespace Application.Features.Users.Register;

public sealed record RegisterUserCommand(string Email, string FirstName, string LastName, string Password)
    : ICommand<UserDto>;
