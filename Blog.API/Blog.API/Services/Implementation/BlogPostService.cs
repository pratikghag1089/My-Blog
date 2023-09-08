using AutoMapper;
using Blog.API.Data;
using Blog.API.Models.Domains;
using Blog.API.Models.DTOs;
using Blog.API.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.Services.Implementation
{
    public class BlogPostService : IBlogPostService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public BlogPostService(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<BlogPostDto> CreateAsync(CreateBlogPostRequestDto createBlogPostRequestDto)
        {
            var BlogPost = _mapper.Map<BlogPost>(createBlogPostRequestDto);
            BlogPost.Categories = new List<Category>();

            foreach (var categoryId in createBlogPostRequestDto.CategoryIds)
            {
                var existingCategory = await _applicationDbContext.Categories.FirstOrDefaultAsync(e => e.Id == categoryId);
                if (existingCategory is not null)
                {
                    BlogPost.Categories.Add(existingCategory);
                }
            }

            await _applicationDbContext.AddAsync(BlogPost);
            await _applicationDbContext.SaveChangesAsync();

            var BlogPostDto = _mapper.Map<BlogPostDto>(BlogPost);

            return BlogPostDto;
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllAsync()
        {
            var blogPosts = await _applicationDbContext.BlogPosts.Include(e => e.Categories).ToListAsync();

            var BlogPostDtos = _mapper.Map<IEnumerable<BlogPostDto>>(blogPosts);

            return BlogPostDtos;
        }

        public async Task<BlogPostDto> GetByIdAsync(Guid id)
        {
            var BlogPost = await _applicationDbContext.BlogPosts.Include(e => e.Categories).FirstOrDefaultAsync(e => e.Id == id);

            var BlogPostDto = _mapper.Map<BlogPostDto>(BlogPost);

            return BlogPostDto;
        }
        
        public async Task<BlogPostDto> GetByUrlAsync(string urlHandle)
        {
            var BlogPost = await _applicationDbContext.BlogPosts.Include(e => e.Categories).FirstOrDefaultAsync(e => e.UrlHandle.ToLower() == urlHandle.ToLower());

            var BlogPostDto = _mapper.Map<BlogPostDto>(BlogPost);

            return BlogPostDto;
        }
        
        public async Task<BlogPostDto> EditAsync(Guid id, UpdateBlogPostRequestDto updateBlogPostRequestDto)
        {
            var BlogPost = _mapper.Map<BlogPost>(updateBlogPostRequestDto);
            BlogPost.Id = id;
            BlogPost.Categories = new List<Category>();


            var existingBlogPost = await _applicationDbContext.BlogPosts.Include(e => e.Categories).FirstOrDefaultAsync(e => e.Id == id);

            foreach (var categoryId in updateBlogPostRequestDto.CategoryIds)
            {
                var existingCategory = await _applicationDbContext.Categories.FirstOrDefaultAsync(e => e.Id == categoryId);
                if (existingCategory is not null)
                {
                    BlogPost.Categories.Add(existingCategory);
                }
            }

            if (existingBlogPost != null)
            {
                _applicationDbContext.Entry(existingBlogPost).CurrentValues.SetValues(BlogPost);
                existingBlogPost.Categories = BlogPost.Categories;

                await _applicationDbContext.SaveChangesAsync();

                var BlogPostDto = _mapper.Map<BlogPostDto>(BlogPost);
                return BlogPostDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<BlogPostDto> DeleteByIdAsync(Guid id)
        {
            var BlogPost = await _applicationDbContext.BlogPosts.FirstOrDefaultAsync(e => e.Id == id);

            if (BlogPost != null)
            {
                _applicationDbContext.BlogPosts.Remove(BlogPost);
                await _applicationDbContext.SaveChangesAsync();

                var BlogPostDto = _mapper.Map<BlogPostDto>(BlogPost);
                return BlogPostDto;
            }
            else
            {
                return null;
            }
        }
    }
}
