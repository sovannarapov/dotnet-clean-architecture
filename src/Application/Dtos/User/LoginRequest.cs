namespace Application.Dtos.User;

public sealed record LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
