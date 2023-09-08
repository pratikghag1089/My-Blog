using Blog.API.Data;
using Blog.API.Models.Domains;
using Blog.API.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Services.Implementation
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _applicationDbContext;

        public ImageService(IWebHostEnvironment webHostEnvironment,
            IHttpContextAccessor httpContextAccessor,
            ApplicationDbContext applicationDbContext)
        {
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<BlogImage>> GetAll()
        {
            return await _applicationDbContext.BlogImages.ToListAsync();
        }

        public async Task<BlogImage> Upload(IFormFile file, string fileName, string title)
        {
            var blogImage = new BlogImage
            {
                FileExtension = Path.GetExtension(file.FileName),
                FileName = fileName,
                Title = title,
                DateCreated = DateTime.UtcNow,
            };

            var localPath = Path.Combine(_webHostEnvironment.ContentRootPath, "images", $"{blogImage.FileName}{blogImage.FileExtension}");

            using (var stream = new FileStream(localPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var httpRequest = _httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/images/{blogImage.FileName}{blogImage.FileExtension}";
            
            blogImage.Url = urlPath;

            await _applicationDbContext.BlogImages.AddAsync(blogImage);
            await _applicationDbContext.SaveChangesAsync();

            return blogImage;
        }
    }
}
