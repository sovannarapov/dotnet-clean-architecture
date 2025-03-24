using Application.Abstractions.Messaging;
using Application.Dtos.User;

namespace Application.Features.Users.GetByEmail;

public sealed record GetUserByEmailQuery(string Email) : IQuery<UserDto>;
