using System;
using System.Threading.Tasks;

namespace TweetBookAPI.Services
{
    public interface IResponseCacheService
    {
        Task CachedResponseAsync(string cacheKey, object response, TimeSpan timeToLive);

        Task<string> GetCacheResponseAsync(string cacheKey);
    }
}