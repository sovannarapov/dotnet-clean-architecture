using Application.Abstractions.Messaging;

namespace Application.Features.Users.Delete;

public sealed record DeleteUserCommand(Guid UserId) : ICommand;
