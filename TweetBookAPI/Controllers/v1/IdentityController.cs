using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1;
using TweetBookAPI.Contracts.v1.Requests;
using TweetBookAPI.Contracts.v1.Responses;
using TweetBookAPI.Domain;
using TweetBookAPI.Services;

namespace TweetBookAPI.Controllers.v1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] IdentityRequest.UserRegister request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new IdentityResponse.AuthFailed
                {
                    Errors = ModelState.Values.SelectMany(err => err.Errors.Select(errMsg => errMsg.ErrorMessage))
                });
            }

            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            return AuthResponse(authResponse);
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] IdentityRequest.UserLogin request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            return AuthResponse(authResponse);
        }

        public IActionResult AuthResponse(AuthenticationResult response)
        {
            if (!response.Success)
            {
                return BadRequest(new IdentityResponse.AuthFailed
                {
                    Errors = response.Errors
                });
            }
            return Ok(new IdentityResponse.AuthSuccess
            {
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }

        [HttpPost(ApiRoutes.Identity.Refresh)]
        public async Task<IActionResult> RefreshToken([FromBody] IdentityRequest.UserRefreshToken request)
        {
            var authResponse = await _identityService.RefreshTokenAsync(request.Token, request.RefreshToken);

            return AuthResponse(authResponse);
        }
    }
}