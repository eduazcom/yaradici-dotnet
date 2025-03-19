using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YaradiciEduAz.Abstractions.IServices;
using YaradiciEduAz.Contexts;
using YaradiciEduAz.DTOs.TeacherDTOs;
using YaradiciEduAz.Entities;
using YaradiciEduAz.Models;
using YaradiciEduAz.Validations.TeacherValidations;

namespace YaradiciEduAz.Implementations.Services;

public class TeacherService:ITeacherService
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;
    private readonly IFileStorageService _fileStorageService;

    public TeacherService(IMapper mapper, AppDbContext context, IFileStorageService fileStorageService)
    {
        _mapper = mapper;
        _context = context;
        _fileStorageService = fileStorageService;
    }
    public async Task<GenericResponseModel<List<TeacherGetDto>>> GetAllTeachers()
    {
        GenericResponseModel<List<TeacherGetDto>> response = new();
        var teachers = await _context.Teachers.ToListAsync();
        if(teachers.Count == 0) return response;
        response.Data = _mapper.Map<List<TeacherGetDto>>(teachers);
        response.StatusCode = 200;
        response.Message = "Teachers fetched successfully";
        return response;
    }

    public async Task<GenericResponseModel<TeacherGetDto>> GetTeacherById(int id)
    {
        GenericResponseModel<TeacherGetDto> response = new();
        var teacher = await _context.Teachers.FindAsync(id);
        if(teacher == null) return response;
        response.Data = _mapper.Map<TeacherGetDto>(teacher);
        response.StatusCode = 200;
        response.Message = "Teacher fetched successfully";
        return response;
    }
    
    public async Task<GenericResponseModel<bool>> CreateTeacher(TeacherCreateUpdateDto dto)
    {
        GenericResponseModel<bool> response = new();
        if (dto == null) return response;
        TeacherCreateUpdateDtoValidator validator = new TeacherCreateUpdateDtoValidator();
        var validationResult = await validator.ValidateAsync(dto);
        if (!validationResult.IsValid)
        {
            foreach (var failure in validationResult.Errors)
            {
                response.Message = failure.ErrorMessage;
            }
            response.StatusCode = 400;
            return response;
        }
        
        string? savedThumbnailUrl = null;
        if (!string.IsNullOrWhiteSpace(dto.Thumbnail))
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/teacher-thumbnails");
            savedThumbnailUrl = await _fileStorageService.SaveBase64AsImageAsync(dto.Thumbnail, directoryPath);
        }

        var teacher = _mapper.Map<Teacher>(dto);
        teacher.Thumbnail = savedThumbnailUrl;

        await _context.Teachers.AddAsync(teacher);
        var affectedRows = await _context.SaveChangesAsync();

        if (affectedRows == 0)
        {
            return new GenericResponseModel<bool>
            {
                StatusCode = 500,
                Message = "Something went wrong"
            };
        }

        return new GenericResponseModel<bool>
        {
            Data = true,
            StatusCode = 200,
            Message = "Teacher added successfully"
        };
    }
    
    public async Task<GenericResponseModel<bool>> UpdateTeacher(int id, TeacherCreateUpdateDto dto)
    {
        GenericResponseModel<bool> response = new();
        
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        {
            response.StatusCode = 404;
            response.Message = "Teacher not found";
            return response;
        }
        
        if (!string.IsNullOrWhiteSpace(dto.Thumbnail))
        {
            string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/teacher-thumbnails");
            string? savedThumbnailUrl = await _fileStorageService.SaveBase64AsImageAsync(dto.Thumbnail, directoryPath);
            teacher.Thumbnail = savedThumbnailUrl; 
        }
        
        _mapper.Map(dto, teacher);
        
        var affectedRows = await _context.SaveChangesAsync();
        if (affectedRows == 0)
        {
            response.StatusCode = 500;
            response.Message = "Something went wrong";
            return response;
        }

        response.Data = true;
        response.StatusCode = 200;
        response.Message = "Teacher updated successfully";
        return response;
    }

    public async Task<GenericResponseModel<bool>> DeleteTeacher(int id)
    {
        GenericResponseModel<bool> response = new();
        var teacher = await _context.Teachers.FindAsync(id);
        if(teacher == null) return response;
        _context.Teachers.Remove(teacher);
        var affectedRows = await _context.SaveChangesAsync();
        if (affectedRows == 0)
        {
            response.StatusCode = 500;
            response.Message = "Something went wrong";
            return response;
        }
        response.Data = true;
        response.StatusCode = 200;
        response.Message = "Teacher deleted successfully";
        return response;
    }
}