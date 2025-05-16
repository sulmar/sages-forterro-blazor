using IdentityProvider.Api.Abstractions;
using IdentityProvider.Api.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace IdentityProvider.Api.Infrastructures;

public class JwtSettings
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int ExpiresMinutes { get; set; }
}

public class JwtTokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenService(IOptions<JwtSettings> jwtOptions)
    {
        _jwtSettings = jwtOptions.Value;
    }

    public string GenerateAccessToken(UserIdentity userIdentity)
    {
        var claims = new Dictionary<string, object>
        {
            [JwtRegisteredClaimNames.Jti] = Guid.NewGuid().ToString(),
            [JwtRegisteredClaimNames.Name] = userIdentity.Username,
            [JwtRegisteredClaimNames.Email] = userIdentity.Email,
            [JwtRegisteredClaimNames.PhoneNumber] = userIdentity.PhoneNumber,
            [JwtRegisteredClaimNames.GivenName] = userIdentity.FirstName,
            [JwtRegisteredClaimNames.FamilyName] = userIdentity.LastName,
            [JwtRegisteredClaimNames.Birthdate] = userIdentity.Birthdate.ToShortDateString(),

            // Dodajemy role jako tablicę
            [ClaimTypes.Role] = userIdentity.Roles.ToArray(),

            ["Permission"] = userIdentity.Permissions.ToArray(),

            ["Department"] = userIdentity.Department
        };


        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresMinutes),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)),
                SecurityAlgorithms.HmacSha256Signature),
            Claims = claims
        };

        var jwt_token = new JsonWebTokenHandler().CreateToken(descriptor);

        return jwt_token;
    }
}
