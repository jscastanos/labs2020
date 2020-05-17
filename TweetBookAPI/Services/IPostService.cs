using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetBookAPI.Domain;

namespace TweetBookAPI.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync(PostFilters.GetAllPost filter = null, PaginationFilter paginationFilter = null);

        Task<Post> GetPostByIdAsync(Guid postId);

        Task<bool> CreatePostAsync(Post post);

        Task<bool> UpdatePostAsync(Post postToUpdate);

        Task<bool> DeletePostAsync(Guid postId);

        Task<bool> UserOwnsPostAsync(Guid postId, string userId);

        Task<List<Tag>> GetAllTagsAsync();

        Task<bool> CreateTagAsync(Tag tag);

        Task<Tag> GetTagByNameAsync(string tagName);

        Task<bool> DeleteTagAsync(string tagName);
    }
}