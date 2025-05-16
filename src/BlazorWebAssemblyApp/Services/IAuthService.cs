namespace BlazorWebAssemblyApp.Services;

public interface IAuthService
{
    Task<LoginResponse?> LoginAsync(string username, string password);
}

public record LoginResponse(string AccessToken);