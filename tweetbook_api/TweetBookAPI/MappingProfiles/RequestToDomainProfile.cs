using AutoMapper;
using TweetBook.Contracts.v1.Requests.Queries;
using TweetBookAPI.Domain;

namespace TweetBookAPI.MappingProfiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<PostQueries.GetAllPosts, PostFilters.GetAllPost>();
        }
    }
}