using BlazorWebAssemblyApp.Services;
using Domain.Models;

namespace BlazorWebAssemblyApp.Pages.Customers;


// dotnet add package Microsoft.Extensions.Http
public partial class List(ICustomerService Api) // Primary Constructor
{
    private string message = $"Lorem ipsum {DateTime.Now}";

    private IEnumerable<Customer>? customers;

    protected override async Task OnInitializedAsync()
    {
        customers = await Api.GetAllAsync();       
    }
}
