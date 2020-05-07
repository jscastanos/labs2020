using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Contracts.v1.Request
{
    public class IdentityRequest
    {
        public class UserRegistration
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
    }
}
