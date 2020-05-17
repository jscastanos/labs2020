using FluentAssertions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TweetBook.Contracts.v1.Responses;
using TweetBookAPI.Contracts.v1;
using TweetBookAPI.Contracts.v1.Requests;
using TweetBookAPI.Contracts.v1.Responses;
using Xunit;

namespace TweetBook.IntegrationTests
{
    public class PostsControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithoutAnyPosts_ReturnsEmptyResponse()
        {
            // Arrange
            await AuthenticateAsync();

            // Act
            var response = await TestClient.GetAsync(ApiRoutes.Posts.GetAll);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<PagedResponse<PostResponse>>()).Data.Should().BeEmpty();
        }

        [Fact]
        public async Task Get_ReturnsPost_WhenPostExistsInTheDatabase()
        {
            //Arrange
            await AuthenticateAsync();
            var createdPost = await CreatePostAsync(new PostRequest.CreatePost { Name = "Test post", Tags = new[] { "tag1" } });

            //Act
            var response = await TestClient.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", createdPost.Data.Id.ToString()));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedPost = await response.Content.ReadAsAsync<Response<PostResponse.Post>>();
            returnedPost.Data.Id.Should().Be(createdPost.Data.Id);
            returnedPost.Data.Name.Should().Be("Test post");
            returnedPost.Data.Tags.Single().Name.Should().Be("tag1");
        }
    }
}