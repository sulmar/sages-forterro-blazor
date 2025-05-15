using IdentityProvider.Api.Models;

namespace IdentityProvider.Api.Abstractions;

public interface ITokenService
{
    string GenerateAccessToken(UserIdentity user);
}
