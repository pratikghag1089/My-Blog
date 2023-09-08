using AutoMapper;
using Blog.API.Models.Domains;
using Blog.API.Models.DTOs;
using Blog.API.Services.Contract;
using Blog.API.Services.Implementation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService _IImageService;
        private readonly IMapper _mapper;

        public ImagesController(IImageService IImageService, IMapper mapper)
        {
            _IImageService = IImageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogImages = await _IImageService.GetAll();

            return Ok(_mapper.Map<List<BlogImageDto>>(blogImages));
        }


        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, [FromForm] string fileName, [FromForm] string title)
        {
            ValidateFileUpload(file);

            if (ModelState.IsValid)
            {
                var blogImage = await _IImageService.Upload(file, fileName, title);
                return Ok(_mapper.Map<BlogImageDto>(blogImage));
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private void ValidateFileUpload(IFormFile file)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(file.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file format");
            }

            if (file.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size cannot be more then 10 MB");
            }
        }
    }
}
