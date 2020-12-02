using Swashbuckle.AspNetCore.Filters;
using TweetBookAPI.Contracts.v1.Responses;

namespace TweetBookAPI.Examples.Responses
{
    public class TagResponseExample
    {
        public class TagName : IExamplesProvider<TagResponse.TagName>
        {
            public TagResponse.TagName GetExamples()
            {
                return new TagResponse.TagName
                {
                    Name = "Response Tag"
                };
            }
        }
    }
}