using Application.Abstractions.Authentication;
using Application.Abstractions.Data;
using Application.Abstractions.Messaging;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Application.Features.Users.Delete;

internal sealed class DeleteUserCommandHandler(
    IApplicationDbContext context,
    IUserContext userContext) : ICommandHandler<DeleteUserCommand>
{
    public async Task<Result> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        User? user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == command.UserId, cancellationToken);

        if (user is null)
        {
            return Result.Failure(UserErrors.NotFound(command.UserId));
        }

        if (user.Id != userContext.UserId)
        {
            return Result.Failure(UserErrors.Unauthorized());
        }

        context.Users.Remove(user);

        await context.SaveChangesAsync(cancellationToken);

        return Result.Success("User deleted successfully");
    }
}