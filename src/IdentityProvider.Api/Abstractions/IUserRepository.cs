using IdentityProvider.Api.Models;

namespace IdentityProvider.Api.Abstractions;

public interface IUserRepository
{
    UserIdentity? GetUser(string username);
}
