using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1.Responses;
using TweetBookAPI.Domain;

namespace TweetBookAPI.Mapping
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Post, PostResponse.Post>()
                .ForMember(dest => dest.Tags, opt =>
                    opt.MapFrom(src => src.Tags.Select(x => new TagResponse.PostTags { Name = x.TagName })));
            CreateMap<Tag, TagResponse.PostTags>();
        }
    }
}
