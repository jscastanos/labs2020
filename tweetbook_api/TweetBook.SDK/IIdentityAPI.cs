using Refit;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1.Requests;
using TweetBookAPI.Contracts.v1.Responses;

namespace TweetBook.SDK
{
    public interface IIdentityAPI
    {
        [Post("/api/v1/auth/register")]
        Task<ApiResponse<IdentityResponse.AuthSuccess>> RegisterAsync([Body] IdentityRequest.UserRegistration registrationRequest);

        [Post("/api/v1/auth/login")]
        Task<ApiResponse<IdentityResponse.AuthSuccess>> LoginAsync([Body] IdentityRequest.UserLogin loginRequest);

        [Post("/api/v1/refresh")]
        Task<ApiResponse<IdentityResponse.AuthSuccess>> RefreshAsync([Body] IdentityRequest.UserRefreshToken refreshRequest);
    }
}