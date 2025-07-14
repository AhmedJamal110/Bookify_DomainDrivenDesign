using Bookify.Application.Authentications;

namespace Bookify.Infrastructre.Authentication;
internal sealed class AuthenticationService : IAuthenticationService
{
    public Task<string> RegisterAsync(
        User user,
        string password, 
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
