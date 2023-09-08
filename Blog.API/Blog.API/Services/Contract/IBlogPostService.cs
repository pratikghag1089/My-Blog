using Blog.API.Models.Domains;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.Contract
{
    public interface IBlogPostService
    {
        Task<BlogPostDto> CreateAsync(CreateBlogPostRequestDto createBlogPostRequestDto);

        Task<IEnumerable<BlogPostDto>> GetAllAsync();

        Task<BlogPostDto> GetByIdAsync(Guid id);

        Task<BlogPostDto> GetByUrlAsync(string urlHandle);

        Task<BlogPostDto?> EditAsync(Guid id, UpdateBlogPostRequestDto updateBlogPostRequestDto);

        Task<BlogPostDto?> DeleteByIdAsync(Guid id);
    }
}
