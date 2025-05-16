namespace Domain.Models;

public class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public decimal Balance { get; set; }
    public string? HashedPassword { get; set; }
    public string? ConfirmedPassword { get; set; }
    public bool IsDeleted { get; set; }
}
