using Domain.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.Services;

public interface ICustomerService
{
    Task<IEnumerable<Customer>?> GetAllAsync();
}

public class ApiCustomerService(HttpClient http) : ICustomerService
{
    public Task<IEnumerable<Customer>?> GetAllAsync()
    {
        return http.GetFromJsonAsync<IEnumerable<Customer>>("api/customers");
    }
}


public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
}

public class ApiProductService(HttpClient http) : IProductService
{
    public Task<IEnumerable<Product>?> GetAllAsync()
    {
        return http.GetFromJsonAsync<IEnumerable<Product>>("api/products");
    }
}