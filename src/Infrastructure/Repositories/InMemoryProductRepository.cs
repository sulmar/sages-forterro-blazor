using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure.Repositories;

public class InMemoryProductRepository : InMemoryEntityRepository<Product>, IProductRepository
{
    public InMemoryProductRepository(IEnumerable<Product> entities) : base(entities)
    {
    }

    public Task<IEnumerable<Product>> GetByColorAsync(string color)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetByTextAsync(string text)
    {
        if (string.IsNullOrEmpty(text))
            return Enumerable.Empty<Product>();

        await Task.Delay(500);

        return _entities.Select(p => p.Value)
            .Where(c => c.Name.Contains(text, StringComparison.OrdinalIgnoreCase)
            || c.Description.Contains(text, StringComparison.OrdinalIgnoreCase) || c.Price.ToString().Contains(text));
    }
}