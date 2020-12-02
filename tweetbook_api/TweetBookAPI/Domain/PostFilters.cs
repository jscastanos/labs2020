namespace TweetBookAPI.Domain
{
    public class PostFilters
    {
        public class GetAllPost
        {
            public string UserId { get; set; }
            public string PostName { get; set; }
            public string Tags { get; set; }
        }
    }
}