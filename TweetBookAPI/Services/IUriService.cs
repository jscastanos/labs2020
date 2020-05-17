using System;
using TweetBook.Contracts.v1.Requests.Queries;

namespace TweetBookAPI.Services
{
    public interface IUriService
    {
        Uri GetPostUri(string postId);

        Uri GetAllPostUri(PaginationQuery pagination = null);
    }
}