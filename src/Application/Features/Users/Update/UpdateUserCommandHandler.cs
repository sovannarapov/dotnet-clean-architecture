using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Application.Dtos.User;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Features.Users.Update;

internal sealed class UpdateUserCommandHandler(
    IApplicationDbContext context,
    IUserContext userContext) : ICommandHandler<UpdateUserCommand, UserDto>
{
    private static void UpdateUserFields(User user, UpdateUserCommand command)
    {
        if (command.FirstName is not null)
        {
            user.FirstName = command.FirstName;
        }

        if (command.LastName is not null)
        {
            user.LastName = command.LastName;
        }

        if (command.Email is not null)
        {
            user.Email = command.Email;
        }
    }

    public async Task<Result<UserDto>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        User? user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == command.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure<UserDto>(UserErrors.NotFound(command.UserId));
        }

        if (user.Id != userContext.UserId)
        {
            return Result.Failure<UserDto>(UserErrors.Unauthorized());
        }

        UpdateUserFields(user, command);

        await context.SaveChangesAsync(cancellationToken);

        var userDto = new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };

        return Result.Success(userDto);
    }
}
