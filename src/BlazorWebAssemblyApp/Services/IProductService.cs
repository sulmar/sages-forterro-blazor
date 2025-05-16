using Domain.Models;

namespace BlazorWebAssemblyApp.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
}
