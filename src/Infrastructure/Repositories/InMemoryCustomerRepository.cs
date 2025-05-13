using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure.Repositories;

public class InMemoryCustomerRepository : InMemoryEntityRepository<Customer>, ICustomerRepository
{
    public InMemoryCustomerRepository(IEnumerable<Customer> entities) : base(entities)
    {
    }

    public async Task<IEnumerable<Customer>> GetByTextAsync(string text)
    {
        if (string.IsNullOrEmpty(text))
            return Enumerable.Empty<Customer>();

        await Task.Delay(500);

        return _entities.Select(p => p.Value).Where(c => c.Name.Contains(text, StringComparison.OrdinalIgnoreCase) || c.Email.Contains(text, StringComparison.OrdinalIgnoreCase));
    }
}
