using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetBookAPI.Contracts.v1.Requests
{
    public class TagRequest
    {
        public class CreateTag
        {
            public string TagName { get; set; }
        }
    }
}
