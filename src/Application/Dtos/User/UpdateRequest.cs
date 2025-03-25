namespace Application.Dtos.User;

public sealed record UpdateRequest(
    string FirstName,
    string LastName,
    string Email);
