using Domain.Abstractions;
using Domain.Models;

namespace BlazorWebAssemblyApp.Pages.Customers;

public partial class List
{
    private string message = $"Lorem ipsum {DateTime.Now}";
    private IEnumerable<Customer>? customers;

    private readonly ICustomerRepository repository;
    public List(ICustomerRepository repository)
    {
        this.repository = repository;
    }

    protected override async Task OnInitializedAsync()
    {
        customers = await repository.GetAllAsync();
    }
}
