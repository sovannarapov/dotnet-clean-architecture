using Application.Dtos.User;
using Application.Features.Users.Update;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Users;

internal sealed class Update : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPatch("users/{userId:guid}", async (
            Guid userId,
            UpdateRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new UpdateUserCommand(
                userId,
                request.FirstName,
                request.LastName,
                request.Email);

            Result result = await sender.Send(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .HasApiVersion(1.0)
        .HasPermission(Permissions.UsersAccess)
        .WithTags(Tags.Users);
    }
}
