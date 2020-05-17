namespace TweetBook.Contracts.v1.Requests.Queries
{
    public class PostQueries
    {
        public class GetAllPosts
        {
            public string UserId { get; set; }
            public string PostName { get; set; }
            public string Tags { get; set; }
        }
    }
}