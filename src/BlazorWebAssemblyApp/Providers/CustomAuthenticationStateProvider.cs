using BlazorWebAssemblyApp.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace BlazorWebAssemblyApp.Providers;

// dotnet add package Microsoft.AspNetCore.Components.Authorization
// dotnet add package  Microsoft.IdentityModel.JsonWebTokens
public class CustomAuthenticationStateProvider(LocalStorageService storage) : AuthenticationStateProvider
{
    private const string TokenKey = "access_token";

    private static AuthenticationState AnonymousState => new AuthenticationState(Anonymous);

    // Anonimowy użytkownik
    private static ClaimsPrincipal Anonymous => new ClaimsPrincipal(new ClaimsIdentity());

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var jwt = await storage.GetAsync(TokenKey);

        if (string.IsNullOrEmpty(jwt))
            return AnonymousState;

        var principal = CreateUserPrincipal(jwt);

        return new AuthenticationState(principal);
    }

    // Tworzy ClaimsPrincipal na podstawie tokena JWT
    // Token jest parsowany lokalnie bez waliacji podpisu
    // W przypadku błędu zwracany jest anonimowy użytkownik
    private static ClaimsPrincipal CreateUserPrincipal(string token)
    {
        try
        {
            var handler = new JsonWebTokenHandler();
            var jwt = handler.ReadJsonWebToken(token);
            var identity = new ClaimsIdentity(jwt.Claims, "jwt", "name", "role");
            var user = new ClaimsPrincipal(identity);

            return user;
        }
        catch
        {
            return Anonymous;
        }
    }

    public async Task NotifyUserAuthenticationAsync(string jwt)
    {
        await storage.SetAsync(TokenKey, jwt);

        var principal = CreateUserPrincipal(jwt);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
    }

    public async Task NotifyUserLogoutAsync()
    {
        await storage.RemoveAsync(TokenKey);
        NotifyAuthenticationStateChanged(Task.FromResult(AnonymousState));
    }
}
