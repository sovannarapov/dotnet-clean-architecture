using System.ComponentModel.DataAnnotations.Schema;
using SharedKernel;

namespace Domain.Users;

[Table("Users")]
public class User : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
}
