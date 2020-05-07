using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Contracts.v1.Response
{
    public class PostResponse
    {
        public class CreateSuccess
        {
            public Guid Id { get; set; }
        }
    }
}
