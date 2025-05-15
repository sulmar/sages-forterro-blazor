using IdentityProvider.Api.Models;

namespace IdentityProvider.Api.Infrastructures;

public class IdentityContext
{
    public IEnumerable<UserIdentity> Users { get; set; }
}
