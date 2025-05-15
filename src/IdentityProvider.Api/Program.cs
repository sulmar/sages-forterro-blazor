using IdentityProvider.Api.Abstractions;
using IdentityProvider.Api.Infrastructures;
using IdentityProvider.Api.Models;
using IdentityProvider.Api.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IPasswordHasher<UserIdentity>, PasswordHasher<UserIdentity>>(); // TODO: Zaimplementuj własny PasswordHasher oparty o BCrypt
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<IUserRepository, InMemoryUserRepository>();
builder.Services.AddScoped<IdentityContext>(sp =>
{
    var hasher = sp.GetRequiredService<IPasswordHasher<UserIdentity>>();

    var user1 = new UserIdentity
    {
        Id = 1,
        FirstName = "John",
        LastName = "Smith",
        Username = "john",
        Email = "john@example.com",
        PhoneNumber = "5554567890",
        Birthdate = DateTime.Parse("2010-01-01")
    };
    user1.PasswordHash = hasher.HashPassword(user1, "123");

    var user2 = new UserIdentity
    {
        Id = 2,
        FirstName = "Alice",
        LastName = "Johnson",
        Username = "alice",
        Email = "alice@example.com",
        PhoneNumber = "5551112233",
        Birthdate = DateTime.Parse("1990-06-15"),
        Roles = new List<string> { "admin" }
    };
    user2.PasswordHash = hasher.HashPassword(user2, "alicepass");

    var user3 = new UserIdentity
    {
        Id = 3,
        FirstName = "Bob",
        LastName = "Taylor",
        Username = "bob",
        Email = "bob@example.com",
        PhoneNumber = "5559998877",
        Birthdate = DateTime.Parse("1985-03-20"),
        Roles = new List<string> { "dev", "support" } // ← wiele ról
    };
    user3.PasswordHash = hasher.HashPassword(user3, "bobsecure");

    return new IdentityContext
    {
        Users = new List<UserIdentity> { user1, user2, user3 }
    };
});

var app = builder.Build();


app.MapGet("/", () => "Hello Auth.Api");

app.MapPost("/api/login", async (LoginRequest request, IAuthService authService, ITokenService tokenService) => { 

    var result = await authService.AuthorizeAsync(request.Username, request.Password);

    if (result.IsAuthentication)
    {
        // Generate JWT (Json Web Token)
        var accessToken = tokenService.GenerateAccessToken(result.Identity);

        return Results.Ok(new { access_token = accessToken });
    }

    return Results.Unauthorized();

});

app.Run();

record LoginRequest(string Username, string Password);

