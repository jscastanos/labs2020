using System;
using System.Collections.Generic;

namespace TweetBookAPI.Contracts.v1.Responses
{
    public class PostResponse
    {
        public class Post
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string UserId { get; set; }
            public IEnumerable<TagResponse.TagName> Tags { get; set; }
        }
    }
}