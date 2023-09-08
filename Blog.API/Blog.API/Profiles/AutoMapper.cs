using AutoMapper;
using Blog.API.Models.Domains;
using Blog.API.Models.DTOs;

namespace Blog.API.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<CreateCategoryRequestDto, Category>();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<UpdateCategoryRequestDto, Category>();

            CreateMap<CreateBlogPostRequestDto, BlogPost>();
            CreateMap<BlogPost, BlogPostDto>().ReverseMap();
            CreateMap<UpdateBlogPostRequestDto, BlogPost>();
            
            CreateMap<BlogImageDto, BlogImage>().ReverseMap();
        }
    }
}
