namespace TweetBookAPI.Contracts.v1.Requests
{
    public class PostRequest
    {
        public class CreatePost
        {
            public string Name { get; set; }
        }

        public class UpdatePost
        {
            public string Name { get; set; }
        }
    }
}