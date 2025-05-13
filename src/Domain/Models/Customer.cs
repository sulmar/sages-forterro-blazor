namespace Domain.Models;

public class Customer : BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? HashedPassword { get; set; }
    public string? ConfirmedPassword { get; set; }
    public bool IsDeleted { get; set; }
}
