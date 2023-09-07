using Blog.API.Models.DTOs;
using Blog.API.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostsController : ControllerBase
    {
        private readonly IBlogPostService _BlogPostService;

        public BlogPostsController(IBlogPostService BlogPostService)
        {
            _BlogPostService = BlogPostService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogPost(CreateBlogPostRequestDto createBlogPostRequestDto)
        {
            var BlogPostDto = await _BlogPostService.CreateAsync(createBlogPostRequestDto);

            return Ok(BlogPostDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var BlogPostDtos = await _BlogPostService.GetAllAsync();

            return Ok(BlogPostDtos);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            var BlogPostDtos = await _BlogPostService.GetByIdAsync(id);

            if (BlogPostDtos == null)
            {
                return NotFound();
            }

            return Ok(BlogPostDtos);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> EditBlogPost([FromRoute] Guid id, [FromBody] UpdateBlogPostRequestDto updateBlogPostRequestDto)
        {
            var BlogPostDto = await _BlogPostService.EditAsync(id, updateBlogPostRequestDto);

            return Ok(BlogPostDto);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBlogPostById([FromRoute] Guid id)
        {
            var BlogPostDtos = await _BlogPostService.DeleteByIdAsync(id);

            if (BlogPostDtos == null)
            {
                return NotFound();
            }

            return Ok(BlogPostDtos);
        }
    }
}
