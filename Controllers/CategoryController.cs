using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YaradiciEduAz.Abstractions.IServices;
using YaradiciEduAz.DTOs.CategoryDTOs;

namespace YaradiciEduAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await _categoryService.GetAllCategories();
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryService.GetCategoryById(id);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateUpdateDto dto)
        {
            var response = await _categoryService.CreateCategory(dto);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryCreateUpdateDto category)
        {
            var response = await _categoryService.UpdateCategory(id, category);
            return StatusCode(response.StatusCode, response);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return StatusCode(response.StatusCode, response);
        }

    }
}
