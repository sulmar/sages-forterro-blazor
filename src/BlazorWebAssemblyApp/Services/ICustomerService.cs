using Domain.Models;

namespace BlazorWebAssemblyApp.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>?> GetAllAsync();
    Task<Customer> GetByIdAsync(int id);
}
