using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Contracts.v1.Response
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
        }
    }
}
