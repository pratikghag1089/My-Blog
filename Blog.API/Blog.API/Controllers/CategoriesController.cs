using AutoMapper;
using Blog.API.Data;
using Blog.API.Models.Domains;
using Blog.API.Models.DTOs;
using Blog.API.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto createCategoryRequestDto)
        {
            var categoryDto = await _categoryService.CreateAsync(createCategoryRequestDto);

            return Ok(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categoryDtos = await _categoryService.GetAllAsync();

            return Ok(categoryDtos);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCategoryById([FromRoute]Guid id)
        {
            var categoryDtos = await _categoryService.GetByIdAsync(id);

            if (categoryDtos == null)
            {
                return NotFound();
            }

            return Ok(categoryDtos);
        }

        [HttpPut("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> EditCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            var categoryDto = await _categoryService.EditAsync(id, updateCategoryRequestDto);

            return Ok(categoryDto);
        }

        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteCategoryById([FromRoute] Guid id)
        {
            var categoryDtos = await _categoryService.DeleteByIdAsync(id);

            if (categoryDtos == null)
            {
                return NotFound();
            }

            return Ok(categoryDtos);
        }
    }
}
