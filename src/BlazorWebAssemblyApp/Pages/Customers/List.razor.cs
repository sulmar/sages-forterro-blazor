using BlazorWebAssemblyApp.Models;
using BlazorWebAssemblyApp.Services;
using Domain.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAssemblyApp.Pages.Customers;


// dotnet add package Microsoft.Extensions.Http
public partial class List(ICustomerService Api) // Primary Constructor
{
    private string message = $"Lorem ipsum {DateTime.Now}";

    private IEnumerable<Customer>? customers;

    [CascadingParameter]
    public FilterState Filter { get; set; }

    protected override async Task OnInitializedAsync()
    {
        customers = await Api.GetAllAsync();       
    }
}
