using Application.Abstractions.Messaging;

namespace Application.Features.Users.Login;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<string>;
