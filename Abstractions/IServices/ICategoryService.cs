using YaradiciEduAz.DTOs.CategoryDTOs;
using YaradiciEduAz.Entities;
using YaradiciEduAz.Models;

namespace YaradiciEduAz.Abstractions.IServices
{
    public interface ICategoryService
    {
        public Task<GenericResponseModel<List<CategoryGetDto>>> GetAllCategories();
        public Task<GenericResponseModel<CategoryGetDto>> GetCategoryById(int id);
        public Task<GenericResponseModel<CategoryCreateUpdateDto>> CreateCategory(CategoryCreateUpdateDto dto);
        public Task<GenericResponseModel<bool>> UpdateCategory(int id, CategoryCreateUpdateDto category);
        public Task<GenericResponseModel<bool>> DeleteCategory(int id);
    }
}
