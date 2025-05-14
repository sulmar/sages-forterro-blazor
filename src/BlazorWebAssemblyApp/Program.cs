using BlazorWebAssemblyApp;
using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure.Fakers;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


// Customers
builder.Services.AddScoped<Faker<Customer>, CustomerFaker>();
builder.Services.AddScoped<IEnumerable<Customer>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<Customer>>();
    var customers = faker.Generate(100);

    return customers;
});
builder.Services.AddScoped<ICustomerRepository, InMemoryCustomerRepository>();


// Products
builder.Services.AddScoped<Faker<Product>, ProductFaker>();
builder.Services.AddScoped<IEnumerable<Product>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<Product>>();
    return faker.Generate(100);
});
builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();

await builder.Build().RunAsync();
