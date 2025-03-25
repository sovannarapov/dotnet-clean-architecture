using Application.Features.Users.Delete;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Users;

internal sealed class Delete : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapDelete("users/{userId:guid}", async (
            Guid userId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new DeleteUserCommand(userId);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .HasApiVersion(1.0)
        .HasPermission(Permissions.UsersAccess)
        .WithTags(Tags.Users);
    }
}
