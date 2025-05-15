using IdentityProvider.Api.Abstractions;
using IdentityProvider.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityProvider.Api.Services;

public class AuthService(IUserRepository userRepository, IPasswordHasher<UserIdentity> passwordHasher) : IAuthService
{
    public Task<AuthenticationResult> AuthorizeAsync(string username, string password)
    {
        var user = userRepository.GetUser(username);

        if (user != null)
        {
            var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (result == PasswordVerificationResult.Success)
            {
                return Task.FromResult(new AuthenticationResult(true, user));
            }
            else
            {
                return Task.FromResult(new AuthenticationResult(false, user));
            }
        }

        return Task.FromResult(new AuthenticationResult(false, null));
    }
}
