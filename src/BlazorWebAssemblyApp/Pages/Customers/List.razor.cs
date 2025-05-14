using Domain.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAssemblyApp.Pages.Customers;

public partial class List
{
    private string message = $"Lorem ipsum {DateTime.Now}";

    private IEnumerable<Customer>? customers;

    [Inject] 
    private ICustomerRepository Repository { get; set; }

    protected override async Task OnInitializedAsync()
    {
        customers = await Repository.GetAllAsync();
    }
}
