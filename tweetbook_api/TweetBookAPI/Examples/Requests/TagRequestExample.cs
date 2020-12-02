using Swashbuckle.AspNetCore.Filters;
using TweetBookAPI.Contracts.v1.Requests;

namespace TweetBookAPI.Examples.Requests
{
    public class TagRequestExample
    {
        public class CreateTag : IExamplesProvider<TagRequest.CreateTag>
        {
            public TagRequest.CreateTag GetExamples()
            {
                return new TagRequest.CreateTag
                {
                    TagName = "new tag"
                };
            }
        }
    }
}