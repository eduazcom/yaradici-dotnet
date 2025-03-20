using YaradiciEduAz.DTOs.TeacherDTOs;
using YaradiciEduAz.Models;

namespace YaradiciEduAz.Abstractions.IServices;

public interface ITeacherService
{
    public Task<GenericResponseModel<List<TeacherGetDto>> > GetAllTeachers();
    public Task<GenericResponseModel<TeacherGetDto>> GetTeacherById(int id);
    public Task<GenericResponseModel<bool>> CreateTeacher(TeacherCreateUpdateDto dto);
    public Task<GenericResponseModel<bool>> UpdateTeacher(int id,TeacherCreateUpdateDto dto);
    public Task<GenericResponseModel<bool>> DeleteTeacher(int id);
}