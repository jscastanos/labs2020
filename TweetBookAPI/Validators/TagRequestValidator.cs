using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1.Requests;

namespace TweetBookAPI.Validators
{
    public class TagRequestValidator
    {
        public class CreateTag : AbstractValidator<TagRequest.CreateTag>
        {
            public CreateTag()
            {
                RuleFor(x => x.TagName)
                    .NotEmpty()
                    .Matches("^[a-zA-Z0-9 ]*$");
            }
        }
    }
}
