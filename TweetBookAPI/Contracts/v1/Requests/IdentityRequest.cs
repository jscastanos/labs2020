using System.ComponentModel.DataAnnotations;

namespace TweetBookAPI.Contracts.v1.Requests
{
    public class IdentityRequest
    {
        public class UserRegister
        {
            [EmailAddress]
            public string Email { get; set; }

            public string Password { get; set; }
        }

        public class UserLogin
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserRefreshToken
        {
            public string Token { get; set; }
            public string RefreshToken { get; set; }
        }
    }
}