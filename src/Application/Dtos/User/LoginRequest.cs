using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.User;

public record LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
