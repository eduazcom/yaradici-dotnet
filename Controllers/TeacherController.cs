using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YaradiciEduAz.Abstractions.IServices;
using YaradiciEduAz.DTOs.TeacherDTOs;

namespace YaradiciEduAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var response = await _teacherService.GetAllTeachers();
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var response = await _teacherService.GetTeacherById(id);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher(TeacherCreateUpdateDto dto)
        {
            var response = await _teacherService.CreateTeacher(dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, TeacherCreateUpdateDto dto)
        {
            var response = await _teacherService.UpdateTeacher(id, dto);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var response = await _teacherService.DeleteTeacher(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
