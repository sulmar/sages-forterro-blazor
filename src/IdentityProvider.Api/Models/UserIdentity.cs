namespace IdentityProvider.Api.Models;

public class UserIdentity
{
    public int? Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PasswordHash { get; set; }
    public DateTime Birthdate { get; set; }
    public List<string> Roles { get; set; } = new();
}
