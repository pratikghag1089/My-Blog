using Blog.API.Models.Domains;

namespace Blog.API.Services.Contract
{
    public interface IImageService
    {
        Task<BlogImage> Upload(IFormFile file, string fileName, string title);

        Task<IEnumerable<BlogImage>> GetAll();
    }
}
