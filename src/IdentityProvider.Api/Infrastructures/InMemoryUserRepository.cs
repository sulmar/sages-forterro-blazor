using IdentityProvider.Api.Abstractions;
using IdentityProvider.Api.Models;

namespace IdentityProvider.Api.Infrastructures;

public class InMemoryUserRepository(IdentityContext context) : IUserRepository
{
    public UserIdentity? GetUser(string username) => context.Users.SingleOrDefault(u => u.Username == username);
}
