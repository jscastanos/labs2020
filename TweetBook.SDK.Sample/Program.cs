using Refit;
using System;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1.Requests;

namespace TweetBook.SDK.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cachedToken = string.Empty;

            var identityApi = RestService.For<IIdentityAPI>("https://localhost:5001");
            var tweetBookApi = RestService.For<ITweetBookAPI>("https://localhost:5001", new RefitSettings
            {
                AuthorizationHeaderValueGetter = () => Task.FromResult(cachedToken)
            });

            var registerResponse = await identityApi.RegisterAsync(new IdentityRequest.UserRegistration
            {
                Email = "some@email.com",
                Password = "Test12345!"
            });

            var loginResponse = await identityApi.LoginAsync(new IdentityRequest.UserLogin
            {
                Email = "some@email.com",
                Password = "Test12345!"
            });

            cachedToken = loginResponse.Content.Token;

            var allPosts = await tweetBookApi.GetAllAsync();

            var createdPost = await tweetBookApi.CreateAsync(new PostRequest.CreatePost
            {
                Name = "this is created by the SDK",
                Tags = new[] { "sdk" }
            });

            var retrievedPost = await tweetBookApi.GetAsync(createdPost.Content.Id);

            var updatedPost = await tweetBookApi.UpdateAsync(createdPost.Content.Id, new PostRequest.UpdatePost
            {
                Name = "This is updated by the SDK"
            });

            var deletedPost = await tweetBookApi.DeleteAsync(createdPost.Content.Id);
        }
    }
}