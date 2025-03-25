using Application.Abstractions.Messaging;

namespace Application.Features.Users.Update;

public sealed record UpdateUserCommand(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email) : ICommand;
