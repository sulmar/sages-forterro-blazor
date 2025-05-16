using Domain.Models;
using FluentValidation;

namespace Domain.Validators;

// dotnet add package FluentValidation
public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(10);

        RuleFor(p => p.Email)
            .EmailAddress();

        RuleFor(p => p.Balance)
            .InclusiveBetween(-1000, 1000);

        RuleFor(p => p.ConfirmedPassword)
            .Equal(p => p.HashedPassword);
    }
}
