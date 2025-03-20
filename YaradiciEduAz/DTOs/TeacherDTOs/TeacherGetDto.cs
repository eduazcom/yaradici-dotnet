using System.Security.Principal;

namespace YaradiciEduAz.DTOs.TeacherDTOs;

public class TeacherGetDto
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Thumbnail { get; set; }
    public string? Link { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}