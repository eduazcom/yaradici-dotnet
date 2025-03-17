using AutoMapper;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using YaradiciEduAz.Abstractions.IRepositories;
using YaradiciEduAz.Abstractions.IServices;
using YaradiciEduAz.Abstractions.IUnitOfWorks;
using YaradiciEduAz.DTOs.CategoryDTOs;
using YaradiciEduAz.Entities;
using YaradiciEduAz.Models;
using YaradiciEduAz.Validations.CategoryValidations;

namespace YaradiciEduAz.Implementations.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IGenericRepository<Category> _categoryRepo;
        CategoryCreateUpdateDtoValidator validator = new();

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _categoryRepo=_unitOfWork.GetRepository<Category>();
        }

        public async Task<GenericResponseModel<CategoryCreateUpdateDto>> CreateCategory(CategoryCreateUpdateDto dto)
        {
            GenericResponseModel<CategoryCreateUpdateDto> responseModel = new();
            if (dto == null) return responseModel;
            ValidationResult results = validator.Validate(dto);
            if (!results.IsValid)
            {
                foreach (var failure in results.Errors)
                {
                    responseModel.Message = failure.ErrorMessage;
                    responseModel.StatusCode = 400;
                }
                return responseModel;
            }
            Category category = _mapper.Map<Category>(dto);
            await _categoryRepo.Add(category);
            var affectedRows = await _unitOfWork.SaveAsync();
            if(affectedRows>0)
            {
                responseModel.Data = dto;
                responseModel.Message = "Category created successfully";
                responseModel.StatusCode = 200;
            }
            else
            {
                responseModel.Message = "Category creation failed";
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<GenericResponseModel<bool>> DeleteCategory(int id)
        {
            GenericResponseModel<bool> responseModel = new();
            var category = await _categoryRepo.GetById(id);
            if (category == null) return responseModel;
            await _categoryRepo.Delete(id);
            var affectedRows = await _unitOfWork.SaveAsync();
            if (affectedRows > 0)
            {
                responseModel.Data = true;
                responseModel.Message = "Category deleted successfully";
                responseModel.StatusCode = 200;
            }
            else
            {
                responseModel.Data = false;
                responseModel.Message = "Category deletion failed";
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }

        public async Task<GenericResponseModel<List<CategoryGetDto>>> GetAllCategories()
        {
            GenericResponseModel<List<CategoryGetDto>> responseModel = new();
            List<Category> categories = await _categoryRepo.GetAll().ToListAsync();
            if (categories == null) return responseModel;
            List<CategoryGetDto> data = _mapper.Map<List<CategoryGetDto>>(categories);
            responseModel.Data = data;
            responseModel.Message = "Categories fetched successfully";
            responseModel.StatusCode = 200;
            return responseModel;

        }

        public async Task<GenericResponseModel<CategoryGetDto>> GetCategoryById(int id)
        {
            GenericResponseModel<CategoryGetDto> responseModel = new();
            var category = await _categoryRepo.GetById(id);
            if (category == null) return responseModel;
            CategoryGetDto data = _mapper.Map<CategoryGetDto>(category);
            responseModel.Data = data;
            responseModel.Message = "Category fetched successfully";
            responseModel.StatusCode = 200;
            return responseModel;
        }

        public async Task<GenericResponseModel<bool>> UpdateCategory(int id, CategoryCreateUpdateDto category)
        {
            GenericResponseModel<bool> responseModel = new();
            var data = await _categoryRepo.GetById(id);
            if (data == null) return responseModel;
            data.Name = category.Name;
            data.Updated_At = DateTime.Now;
            await _categoryRepo.Update(data);
            var affectedRows = await _unitOfWork.SaveAsync();
            if (affectedRows > 0)
            {
                responseModel.Data = true;
                responseModel.Message = "Category updated successfully";
                responseModel.StatusCode = 200;
            }
            else
            {
                responseModel.Data = false;
                responseModel.Message = "Category update failed";
                responseModel.StatusCode = 500;
            }
            return responseModel;
        }
    }
}
