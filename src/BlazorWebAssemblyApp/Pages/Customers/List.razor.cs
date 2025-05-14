using Domain.Abstractions;
using Domain.Models;

namespace BlazorWebAssemblyApp.Pages.Customers;

public partial class List(ICustomerRepository repository) // Primary Constructor
{
    private string message = $"Lorem ipsum {DateTime.Now}";
    private IEnumerable<Customer>? customers;

    protected override async Task OnInitializedAsync()
    {
        customers = await repository.GetAllAsync();
    }
}
