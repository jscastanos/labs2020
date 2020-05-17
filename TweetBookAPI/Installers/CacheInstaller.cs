using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TweetBookAPI.Cache;
using TweetBookAPI.Services;

namespace TweetBookAPI.Installers
{
    public class CacheInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configuration.Bind(nameof(RedisCacheSettings), redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return;
            }

            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}