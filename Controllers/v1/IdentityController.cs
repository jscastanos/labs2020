using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Contracts;
using TweetBook.Contracts.v1.Request;
using TweetBook.Contracts.v1.Response;
using TweetBook.Services;

namespace TweetBook.Controllers.v1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] IdentityRequest.UserRegistration request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new IdentityResponse.AuthFailed
                {
                    Errors = ModelState.Values.SelectMany(err => err.Errors.Select(errMsg => errMsg.ErrorMessage))
                });
            }

            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new IdentityResponse.AuthFailed
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new IdentityResponse.AuthSuccess
            {
                Token = authResponse.Token
            });
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] IdentityRequest.UserLogin request)
        {
            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new IdentityResponse.AuthFailed
                {
                    Errors = authResponse.Errors
                });
            }

            return Ok(new IdentityResponse.AuthSuccess
            {
                Token = authResponse.Token
            });
        }
    }
}
