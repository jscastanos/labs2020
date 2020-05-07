using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Contracts.v1.Request
{
    public class UserRegistrationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
