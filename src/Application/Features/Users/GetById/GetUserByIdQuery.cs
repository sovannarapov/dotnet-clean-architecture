using Application.Abstractions.Messaging;
using Application.Dtos.User;

namespace Application.Features.Users.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IQuery<UserDto>;
