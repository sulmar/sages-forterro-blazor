using System.Net.Http.Json;

namespace BlazorWebAssemblyApp.Services;

public class ApiAuthService(HttpClient http) : IAuthService
{
    public async Task<LoginResponse?> LoginAsync(string username, string password)
    {
        var response = await http.PostAsJsonAsync("api/login", new  { username, password });

        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<LoginResponse>();

    }
}
