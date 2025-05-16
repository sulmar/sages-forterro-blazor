using Domain.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.Services;

public class ApiCustomerService(HttpClient http) : ICustomerService
{
    public Task<IEnumerable<Customer>?> GetAllAsync()
    {
        return http.GetFromJsonAsync<IEnumerable<Customer>>("api/customers");
    }

    public Task<Customer> GetByIdAsync(int id)
    {
        return http.GetFromJsonAsync<Customer>($"api/customers/{id}");
    }
}
