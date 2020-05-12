using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TweetBookAPI.Services;

namespace TweetBookAPI.Installers
{
    public class ServicesInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}