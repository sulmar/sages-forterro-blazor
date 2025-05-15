using Domain.Abstractions;
using Domain.Models;
using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.Pages.Customers;


// dotnet add package Microsoft.Extensions.Http
public partial class List(IHttpClientFactory factory) // Primary Constructor
{
    private string message = $"Lorem ipsum {DateTime.Now}";

    private IEnumerable<Customer>? customers;

    protected override async Task OnInitializedAsync()
    {
        var http = factory.CreateClient("Api");

        customers = await http.GetFromJsonAsync<IEnumerable<Customer>>("api/customers");
    }
}
