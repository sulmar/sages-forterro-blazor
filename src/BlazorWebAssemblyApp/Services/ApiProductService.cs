using Domain.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.Services;

public class ApiProductService(HttpClient http) : IProductService
{
    public Task<IEnumerable<Product>?> GetAllAsync()
    {
        return http.GetFromJsonAsync<IEnumerable<Product>>("api/products");
    }
}