using Application.Abstractions.Messaging;
using Application.Dtos.User;

namespace Application.Features.Users.Update;

public sealed record UpdateUserCommand(
    Guid UserId,
    string? FirstName = null,
    string? LastName = null,
    string? Email = null) : ICommand<UserDto>;
