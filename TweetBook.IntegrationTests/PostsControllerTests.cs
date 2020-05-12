using FluentAssertions;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1;
using TweetBookAPI.Contracts.v1.Requests;
using TweetBookAPI.Domain;
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
            (await response.Content.ReadAsAsync<List<Post>>()).Should().BeEmpty();
        }

        [Fact]
        public async Task Get_ReturnsPost_WhenPostExistsInTheDatabase()
        {
            //Arrange
            await AuthenticateAsync();
            var createdPost = await CreatePostAsync(new PostRequest.CreatePost { Name = "Test post", Tags = new[] { "tag1" } });

            //Act
            var response = await TestClient.GetAsync(ApiRoutes.Posts.Get.Replace("{postId}", createdPost.Id.ToString()));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var returnedPost = await response.Content.ReadAsAsync<Post>();
            returnedPost.Id.Should().Be(createdPost.Id);
            returnedPost.Name.Should().Be("Test post");
        }
    }
}