using Blog.API.Models.Domains;
using Blog.API.Models.DTOs;

namespace Blog.API.Services.Contract
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateAsync(CreateCategoryRequestDto createCategoryRequestDto);

        Task<IEnumerable<CategoryDto>> GetAllAsync();

        Task<CategoryDto> GetByIdAsync(Guid id);

        Task<CategoryDto?> EditAsync(Guid id, UpdateCategoryRequestDto updateCategoryRequestDto);

        Task<CategoryDto?> DeleteByIdAsync(Guid id);
    }
}
