using Microsoft.AspNetCore.Authorization;

namespace BlazorWebAssemblyApp.Authorization;

public static class Permissions
{
    public const string CanPrint = "canprint";
    public const string CanEdit = "canedit";
    public const string CanDelete = "candelete";
}


/// <summary>
/// Metoda rozszerzająca AuthorizationPolicyBuilder
/// </summary>
public static class AuthorizationPolicyBuilderExtensions
{
    public static AuthorizationPolicyBuilder RequirePermission(
        this AuthorizationPolicyBuilder builder, params string[] permissions)
    {
        return builder.RequireClaim("permission", permissions);
    }
}
