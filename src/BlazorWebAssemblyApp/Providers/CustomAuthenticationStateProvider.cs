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

    private static AuthenticationState AnonymousState => new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var jwt = await storage.GetAsync(TokenKey);

        if (string.IsNullOrEmpty(jwt))
            return AnonymousState;

        try
        {
            var handler = new JsonWebTokenHandler();
            var token = handler.ReadJsonWebToken(jwt);
            var identity = new ClaimsIdentity(token.Claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }
        catch
        {
            return AnonymousState;
        }
    }

    public async Task NotifyUserAuthenticationAsync(string jwt)
    {
        await storage.SetAsync(TokenKey, jwt);
        var handler = new JsonWebTokenHandler();
        var token = handler.ReadJsonWebToken(jwt);
        var identity = new ClaimsIdentity(token.Claims, "jwt");
        var user = new ClaimsPrincipal(identity);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
    }

    public async Task NotifyUserLogoutAsync()
    {
        await storage.RemoveAsync(TokenKey);
        NotifyAuthenticationStateChanged(Task.FromResult(AnonymousState));
    }
}
