using AutoMapper;
using Blog.API.Data;
using Blog.API.Models.Domains;
using Blog.API.Models.DTOs;
using Blog.API.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryRequestDto createCategoryRequestDto)
        {
            var category = _mapper.Map<Category>(createCategoryRequestDto);

            await _applicationDbContext.AddAsync(category);
            await _applicationDbContext.SaveChangesAsync();

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _applicationDbContext.Categories.ToListAsync();

            var categoryDtos = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoryDtos;
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(e => e.Id == id);

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return categoryDto;
        }
        
        public async Task<CategoryDto> EditAsync(Guid id, UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            var category = _mapper.Map<Category>(updateCategoryRequestDto);
            category.Id = id;

            var existingCategory = await _applicationDbContext.Categories.FirstOrDefaultAsync(e => e.Id == id);

            if (existingCategory != null)
            {
                _applicationDbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await _applicationDbContext.SaveChangesAsync();

                var categoryDto = _mapper.Map<CategoryDto>(category);
                return categoryDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<CategoryDto> DeleteByIdAsync(Guid id)
        {
            var category = await _applicationDbContext.Categories.FirstOrDefaultAsync(e => e.Id == id);

            if (category != null)
            {
                _applicationDbContext.Categories.Remove(category);
                await _applicationDbContext.SaveChangesAsync();

                var categoryDto = _mapper.Map<CategoryDto>(category);
                return categoryDto;
            }
            else
            {
                return null;
            }
        }
    }
}
