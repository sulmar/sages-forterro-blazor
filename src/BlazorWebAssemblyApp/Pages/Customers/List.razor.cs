using Domain.Abstractions;
using Domain.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.Pages.Customers;


// dotnet add package Microsoft.Extensions.Http
public partial class List(HttpClient http) // Primary Constructor
{
    private string message = $"Lorem ipsum {DateTime.Now}";

    private IEnumerable<Customer>? customers;

    protected override async Task OnInitializedAsync()
    {
        customers = await http.GetFromJsonAsync<IEnumerable<Customer>>("api/customers");
    }
}
