using System.Collections.Generic;

namespace TweetBookAPI.Contracts.v1.Responses
{
    public class IdentityResponse
    {
        public class AuthFailed
        {
            public IEnumerable<string> Errors { get; set; }
        }

        public class AuthSuccess
        {
            public string Token { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}