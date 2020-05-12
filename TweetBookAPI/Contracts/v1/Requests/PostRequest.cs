using System.Collections.Generic;

namespace TweetBookAPI.Contracts.v1.Requests
{
    public class PostRequest
    {
        public class CreatePost
        {
            public string Name { get; set; }
            public IEnumerable<string> Tags { get; set; }
        }

        public class UpdatePost
        {
            public string Name { get; set; }
        }
    }
}