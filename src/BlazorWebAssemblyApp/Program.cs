using BlazorWebAssemblyApp;
using BlazorWebAssemblyApp.Models;
using BlazorWebAssemblyApp.Providers;
using BlazorWebAssemblyApp.Services;
using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure.Fakers;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Silnie typowany klient Http
builder.Services.AddHttpClient<ICustomerService, ApiCustomerService>(http =>
{
    http.BaseAddress = new Uri("https://localhost:7214/");    
});

builder.Services.AddHttpClient<IProductService, ApiProductService>(http =>
{
    http.BaseAddress = new Uri("https://localhost:7214/");
});

builder.Services.AddHttpClient("NbpApi", http =>
{
    http.BaseAddress = new Uri("https://api.nbp.pl/");
});


builder.Services.AddHttpClient<IAuthService, ApiAuthService>(http =>
{
    http.BaseAddress = new Uri("https://localhost:7227/");
});


builder.Services.AddCascadingValue<ApplicationState>(sp => new ApplicationState
{
    ApplicationName = "Shopper",
    ApplicationVersion = "1.0",
    RunnedOn = DateTime.Now,
});

builder.Services.AddCascadingValue<FilterState>(sp => new FilterState {  SelectedCustomerId = 1, SelectedUserId  = 2 });


builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
