using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1.Requests;
using TweetBookAPI.Contracts.v1.Responses;

namespace TweetBook.SDK
{
    [Headers("Authorization: Bearer")]
    public interface ITweetBookAPI
    {
        [Get("/api/v1/posts")]
        Task<ApiResponse<List<PostResponse.Post>>> GetAllAsync();

        [Get("/api/v1/posts/{postId}")]
        Task<ApiResponse<PostResponse.Post>> GetAsync(Guid postId);

        [Post("/api/v1/posts/")]
        Task<ApiResponse<PostResponse.Post>> CreateAsync([Body] PostRequest.CreatePost createRequest);

        [Put("/api/v1/posts/{postId}")]
        Task<ApiResponse<PostResponse.Post>> UpdateAsync(Guid postId, [Body] PostRequest.UpdatePost updateRequest);

        [Delete("/api/v1/posts/{postId}")]
        Task<ApiResponse<string>> DeleteAsync(Guid postId);
    }
}
