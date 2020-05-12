using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetBookAPI.Data;
using TweetBookAPI.Domain;

namespace TweetBookAPI.Services
{
    public class PostService : IPostService
    {
        private readonly DataContext _dataContext;

        public PostService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            return await _dataContext.Posts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _dataContext.Posts.Include(x => x.Tags).SingleOrDefaultAsync(x => x.Id == postId);
        }

        public async Task<bool> CreatePostAsync(Post post)
        {
            post.Tags?.ForEach(x => x.TagName = x.TagName.ToLower());

            await AddNewTags(post);
            _dataContext.Posts.Add(post);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdatePostAsync(Post postToUpdate)
        {
            postToUpdate.Tags?.ForEach(x => x.TagName = x.TagName.ToLower());
            await AddNewTags(postToUpdate);

            _dataContext.Posts.Update(postToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeletePostAsync(Guid postId)
        {
            var post = await GetPostByIdAsync(postId);

            if (post == null)
            {
                return false;
            }

            _dataContext.Posts.Remove(post);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> UserOwnsPostAsync(Guid postId, string userId)
        {
            return await _dataContext.Posts.AnyAsync(x => x.Id == postId && x.UserId == userId);
        }

        public async Task<List<Tag>> GetAllTagsAsync()
        {
            return await _dataContext.Tags.AsNoTracking().ToListAsync();
        }

        private async Task AddNewTags(Post post)
        {
            foreach (var tag in post.Tags)
            {
                var existingTag = await _dataContext.Tags.SingleOrDefaultAsync(x => x.Name == tag.TagName);
                if (existingTag != null)
                    continue;

                await _dataContext.Tags.AddAsync(new Tag
                {
                    Name = tag.TagName,
                    CreatedOn = DateTime.UtcNow,
                    CreatorId = post.UserId
                });
            }
        }
    }
}