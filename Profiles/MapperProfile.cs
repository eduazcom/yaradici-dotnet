using AutoMapper;
using YaradiciEduAz.DTOs.CategoryDTOs;
using YaradiciEduAz.Entities;

namespace YaradiciEduAz.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<CategoryCreateUpdateDto, Category>().ReverseMap();
        }
    }
}
