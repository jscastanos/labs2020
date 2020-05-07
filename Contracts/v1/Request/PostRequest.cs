using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBook.Contracts.v1.Request
{
    public class PostRequest
    {
        public class Create
        {
            public string Name { get; set; }
        }

        public class Update
        {
            public string Name { get; set; }
        }
    }
}
