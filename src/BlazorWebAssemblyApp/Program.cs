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

var baseAddress = "https://localhost:7214/";
// builder.HostEnvironment.BaseAddress
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });


// Products
builder.Services.AddScoped<Faker<Product>, ProductFaker>();
builder.Services.AddScoped<IEnumerable<Product>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<Product>>();
    return faker.Generate(100);
});
builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();

await builder.Build().RunAsync();
