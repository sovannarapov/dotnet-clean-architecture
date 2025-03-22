using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.User;

public record RegisterRequest
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}
