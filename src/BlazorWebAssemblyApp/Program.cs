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
builder.Services.AddHttpClient("Api", http =>
{
    http.BaseAddress = new Uri("https://localhost:7214/");    
});

builder.Services.AddHttpClient("NbpApi", http =>
{
    http.BaseAddress = new Uri("https://api.nbp.pl/");
});


await builder.Build().RunAsync();
