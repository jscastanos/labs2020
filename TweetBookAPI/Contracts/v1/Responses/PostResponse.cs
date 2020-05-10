using System;

namespace TweetBookAPI.Contracts.v1.Responses
{
    public class PostResponse
    {
        public class CreateSuccess
        {
            public Guid Id { get; set; }
        }
    }
}