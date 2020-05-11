using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TweetBookAPI.Domain;

namespace TweetBookAPI.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);

        Task<AuthenticationResult> LoginAsync(string email, string password);

        Task<AuthenticationResult> GenerateAuthenticationResultForUserAsync(IdentityUser user);

        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}