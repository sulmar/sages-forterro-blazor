using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Customer : BaseEntity
{
    [Required, MinLength(1), MaxLength(10)]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [Range(-1000, 1000)]
    public decimal Balance { get; set; }
    public string? HashedPassword { get; set; }
    [Compare(nameof(HashedPassword))]
    public string? ConfirmedPassword { get; set; }
    public bool IsDeleted { get; set; }
}
