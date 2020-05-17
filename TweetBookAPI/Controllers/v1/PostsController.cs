using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetBook.Contracts.v1.Requests.Queries;
using TweetBook.Contracts.v1.Responses;
using TweetBookAPI.Cache;
using TweetBookAPI.Contracts.v1;
using TweetBookAPI.Contracts.v1.Requests;
using TweetBookAPI.Contracts.v1.Responses;
using TweetBookAPI.Domain;
using TweetBookAPI.Extensions;
using TweetBookAPI.Helpers;
using TweetBookAPI.Services;

namespace TweetBookAPI.Controllers.v1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public PostsController(IPostService postService, IMapper mapper, IUriService uriService)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(ApiRoutes.Posts.GetAll)]
        [Cached(600)]
        public async Task<IActionResult> GetAll([FromQuery]PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var posts = await _postService.GetPostsAsync(pagination);
            var postsResponse = _mapper.Map<List<PostResponse.Post>>(posts);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<PostResponse.Post>(postsResponse));
            }

            var paginationResponse = PaginationHelpers.createPaginationResponse(_uriService, pagination, postsResponse);

            return Ok(paginationResponse);
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        [Cached(600)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);

            if (post == null)
                return NotFound();

            return Ok(new Response<PostResponse.Post>(_mapper.Map<PostResponse.Post>(post)));
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] PostRequest.CreatePost request)
        {
            var newPostId = Guid.NewGuid();
            var post = new Post
            {
                Id = newPostId,
                Name = request.Name,
                UserId = HttpContext.GetUserId(),
                Tags = request.Tags.Select(x => new PostTag { PostId = newPostId, TagName = x }).ToList()
            };

            await _postService.CreatePostAsync(post);

            var locationUri = _uriService.GetPostUri(post.Id.ToString());

            return Created(locationUri, new Response<PostResponse.Post>(_mapper.Map<PostResponse.Post>(post)));
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] PostRequest.UpdatePost request)
        {
            var userOwnsPost = await _postService.UserOwnsPostAsync(postId, HttpContext.GetUserId());

            if (!userOwnsPost)
                return BadRequest(new { error = "You are not authorized to make changes in this post" });

            var post = await _postService.GetPostByIdAsync(postId);

            post.Name = request.Name;

            var updated = await _postService.UpdatePostAsync(post);

            if (updated)
                return Ok(new Response<PostResponse.Post>(_mapper.Map<PostResponse.Post>(post)));

            return NotFound();
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {
            var userOwnsPost = await _postService.UserOwnsPostAsync(postId, HttpContext.GetUserId());

            if (!userOwnsPost)
                return BadRequest(new { error = "You are not authorized to make changes in this post" });

            var deleted = await _postService.DeletePostAsync(postId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}