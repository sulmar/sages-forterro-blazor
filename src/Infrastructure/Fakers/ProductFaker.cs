using Bogus;
using Domain.Models;

namespace Infrastructure.Fakers;

// dotnet add package Bogus
public class ProductFaker : Faker<Product>
{
    public ProductFaker()
    {
        RuleFor(p => p.Id, f => f.IndexFaker);
        RuleFor(p => p.Name, f => f.Commerce.ProductName());
        RuleFor(p => p.Description, f => f.Commerce.ProductDescription());
        RuleFor(p => p.Price, f => f.Finance.Amount(1, 1000));
        RuleFor(p => p.ValidDate, f => f.Date.Future(2));
    }
}