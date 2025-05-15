using Bogus;
using Domain.Abstractions;
using Domain.Models;
using Infrastructure.Fakers;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Customers
builder.Services.AddScoped<Faker<Customer>, CustomerFaker>();
builder.Services.AddScoped<IEnumerable<Customer>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<Customer>>();
    var customers = faker.Generate(100);

    return customers;
});
builder.Services.AddScoped<ICustomerRepository, InMemoryCustomerRepository>();


builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
{
    // policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowAnyMethod();

    policy.WithOrigins("https://localhost:7034").WithMethods("GET").AllowAnyHeader();
}));

// Products
builder.Services.AddScoped<Faker<Product>, ProductFaker>();
builder.Services.AddScoped<IEnumerable<Product>>(sp =>
{
    var faker = sp.GetRequiredService<Faker<Product>>();
    return faker.Generate(100);
});
builder.Services.AddScoped<IProductRepository, InMemoryProductRepository>();

var app = builder.Build();

app.UseCors();

app.MapGet("/", () => "Hello Api!");

app.MapGet("api/customers", async (ICustomerRepository repository) => await repository.GetAllAsync());
app.MapGet("api/products", async (IProductRepository productRepository) => await productRepository.GetAllAsync());

app.Run();
