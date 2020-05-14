using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1.Requests;
using TweetBookAPI.Domain;

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
