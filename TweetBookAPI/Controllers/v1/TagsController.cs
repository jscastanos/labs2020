using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetBookAPI.Contracts.v1;
using TweetBookAPI.Contracts.v1.Requests;
using TweetBookAPI.Contracts.v1.Responses;
using TweetBookAPI.Domain;
using TweetBookAPI.Extensions;
using TweetBookAPI.Services;

namespace TweetBookAPI.Controllers.v1
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin,Poster")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    public class TagsController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public TagsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Tags.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _postService.GetAllTagsAsync();
            return Ok(_mapper.Map<List<TagResponse.TagName>>(tags));
        }

        /// <summary>
        /// Returns all the tags in the system
        /// </summary>
        /// <response code="200">Returns all the tags in the system 200</response>
        /// <response code="404">Not found</response>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Tags.Get)]
        [ProducesResponseType(typeof(TagResponse.TagName), 200)]
        public async Task<IActionResult> Get([FromRoute] string tagName)
        {
            var tag = await _postService.GetTagByNameAsync(tagName);

            if (tag == null)
                return NotFound();

            return Ok(_mapper.Map<TagResponse.TagName>(tag));
        }

        [HttpPost(ApiRoutes.Tags.Create)]
        public async Task<IActionResult> Create([FromBody] TagRequest.CreateTag request)
        {
            var newTag = new Tag
            {
                Name = request.TagName,
                CreatorId = HttpContext.GetUserId(),
            };

            var created = await _postService.CreateTagAsync(newTag);
            if (!created)
                return BadRequest(new { error = "Unable to create a tag" });

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Tags.Get.Replace("{tagName}", newTag.Name);

            return Created(locationUri, _mapper.Map<TagResponse.TagName>(newTag));
        }

        [HttpDelete(ApiRoutes.Tags.Delete)]
        // [Authorize(Roles = "Admin")]
        [Authorize(Policy = "MustWorkForZeck")]
        public async Task<IActionResult> Delete([FromRoute] string tagName)
        {
            var deleted = await _postService.DeleteTagAsync(tagName);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}