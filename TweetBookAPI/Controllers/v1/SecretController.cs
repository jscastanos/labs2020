using Microsoft.AspNetCore.Mvc;
using TweetBookAPI.Filters;

namespace TweetBookAPI.Controllers.v1
{
    [ApiKeyAuth]
    public class SecretController : ControllerBase
    {
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            return Ok("Secret got exposed");
        }
    }
}