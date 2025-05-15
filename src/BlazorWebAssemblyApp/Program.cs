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

// Nazwany klient Http
builder.Services.AddHttpClient("CustomersApi", http =>
{
    http.BaseAddress = new Uri("https://localhost:7214/");    
});

builder.Services.AddHttpClient("NbpApi", http =>
{
    http.BaseAddress = new Uri("https://api.nbp.pl/");
});


// Products
builder.Services.AddScoped<Faker<Product>, ProductFaker>();
builder.Services.AddScoped<IEnumerable<Product>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<Product>>();
    return faker.Generate(100);
});
builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();

await builder.Build().RunAsync();
